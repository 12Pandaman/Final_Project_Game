using UnityEngine;

public class WateringCan : MonoBehaviour
{
    public Animator animator; // อนิเมชันรดน้ำ
    public float waterRange = 1.5f; // ระยะรดน้ำ
    public LayerMask treeLayer; // Layer ของต้นไม้
    private Vector2 lastPosition; // ตำแหน่งก่อนหน้า
    private bool hasMoved = false; // เช็คว่ามีการเคลื่อนที่หรือไม่

    void Start()
    {
        lastPosition = transform.position; // ตั้งค่าตำแหน่งเริ่มต้น
    }

    void Update()
    {
        // เช็คว่าที่รดน้ำเคลื่อนที่หรือไม่
        if ((Vector2)transform.position != lastPosition)
        {
            hasMoved = true;
            lastPosition = transform.position;
        }

        if (hasMoved)
        {
            WaterTrees(); // รดน้ำเมื่อมีการเคลื่อนที่
        }
    }

    void WaterTrees()
    {
        Collider2D[] hitTrees = Physics2D.OverlapCircleAll(transform.position, waterRange, treeLayer);

        if (hitTrees.Length > 0)
        {
            animator.SetBool("IsWatering", true); // เปิดอนิเมชันรดน้ำ
        }
        else
        {
            animator.SetBool("IsWatering", false); // ปิดอนิเมชันถ้าไม่มีต้นไม้ในระยะ
        }

        foreach (Collider2D tree in hitTrees)
        {
            TreeGrowth treeGrowth = tree.GetComponent<TreeGrowth>();
            if (treeGrowth != null)
            {
                treeGrowth.WaterTree(); // ให้ต้นไม้รับการรดน้ำ
            }
        }

        hasMoved = false; // รีเซ็ตค่า ให้ต้องเคลื่อนที่อีกครั้งก่อนรดน้ำใหม่
    }

    void OnDrawGizmosSelected()
    {
        // แสดงระยะรดน้ำใน Editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, waterRange);
    }
}
