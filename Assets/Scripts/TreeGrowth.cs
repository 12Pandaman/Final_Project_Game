using UnityEngine;

public class TreeGrowth : MonoBehaviour
{
    public GameObject[] growthStages;  // GameObject ของแต่ละระยะ
    public GameObject rottenTree;  // GameObject ที่แทนต้นไม้เน่า
    public float[] growthChances;  // โอกาสรอด (%) ต่อการรดน้ำแต่ละครั้ง
    public float[] rotChances;  // โอกาสเน่าของแต่ละระยะ
    public Animator scissorAnimator;  // Animator ของกรรไกร
    public AudioSource audioSourcecut; // ตัวเล่นเสียง
    public AudioSource audioSourcewater;
    public AudioClip cutSound; // เสียงตัดต้นไม้
    public AudioClip waterSound;
    public Animator wateringAnimator;

    private int currentStage = 0;
    public bool isRotten = false;  // สถานะของต้นไม้ว่าเน่าหรือไม่
    private bool isWatered = false;  // ใช้เพื่อให้รดน้ำเพียงครั้งเดียว
    

    void Start()
    {
      
        // เปิดระยะแรก และซ่อนระยะอื่น
        if (growthStages != null)
        {
            for (int i = 0; i < growthStages.Length; i++)
            {
                growthStages[i].SetActive(i == 0);  // เปิดแค่ระยะแรก
            }
        }

        // ซ่อนต้นไม้เน่าหากยังไม่มีการเน่า
        if (rottenTree != null)
        {
            rottenTree.SetActive(false);
        }
    }

    public void WaterTree()
    {
        if (isRotten || currentStage >= growthStages.Length - 1 || isWatered) return;

        isWatered = true;  // ตั้งค่าสถานะการรดน้ำ

        float randomChance = Random.value;

        // เล่นเสียงน้ำถ้ามีการรดน้ำ
        if (audioSourcewater != null && waterSound != null)
        {
            if (!audioSourcewater.isPlaying)  // ถ้าเสียงน้ำยังไม่เล่น
            {
                audioSourcewater.PlayOneShot(waterSound);  // เล่นเสียงน้ำ
            }
        }

        // เช็คว่าต้นไม้จะเน่าหรือไม่
        if (rotChances != null && rotChances.Length > currentStage && Random.value < rotChances[currentStage])
        {
            BecomeRotten();
            return;
        }

        // ถ้าไม่เน่า ให้โตขึ้น
        if (growthChances != null && randomChance <= growthChances[currentStage] && !isRotten)
        {
            growthStages[currentStage].SetActive(false);  // ซ่อนระยะก่อนหน้า
            currentStage++;  // เปลี่ยนไปยังระยะถัดไป
            if (currentStage < growthStages.Length)
            {
                growthStages[currentStage].SetActive(true);  // เปิดระยะใหม่
            }
        }

        // รีเซ็ตสถานะการรดน้ำหลังจาก 1 วินาที
        Invoke(nameof(ResetWateredStatus), 1f);
    }


    void BecomeRotten()
    {
        isRotten = true;
        if (rottenTree != null)
        {
            rottenTree.SetActive(true);
        }
    }

    public void CutTree()
    {
       
        if (isRotten)
        {
            if (scissorAnimator != null)
            {
                
                scissorAnimator.SetTrigger("Cut");  // เล่น Animation ตัด
            }
            if (audioSourcecut != null && cutSound != null && !audioSourcecut.isPlaying)
            {
                audioSourcecut.PlayOneShot(cutSound);
            }
            Invoke(nameof(RecoverTree), 1f);  // หลังจากตัดแล้ว ให้ต้นไม้โตต่อ
        }
    }

    void RecoverTree()
    {
        // หลังตัดต้นไม้, ต้นไม้จะไม่เน่าในระยะนี้
        isRotten = false;
        if (rottenTree != null)
        {
            rottenTree.SetActive(false);
        }

        // ต้นไม้กลับมาโตต่อจากระยะปัจจุบัน
        if (currentStage < growthStages.Length)
        {
            growthStages[currentStage].SetActive(true);
        }

        // รีเซ็ตสถานะการรดน้ำเพื่อให้สามารถรดน้ำใหม่ได้
        isWatered = false;
    }

    void ResetWateredStatus()
    {
        isWatered = false;  // รีเซ็ตสถานะการรดน้ำ
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isRotten && other.CompareTag("Scissor"))
        {
            CutTree();  // ถ้ากรรไกรชนต้นไม้เน่า ให้ตัด
        }
    }
}
