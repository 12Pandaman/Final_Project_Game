using UnityEngine;

public class TreeGrowth : MonoBehaviour
{
    public GameObject[] growthStages;
    public GameObject rottenTree;
    public float[] growthChances;
    public float[] rotChances;

    public Animator scissorAnimator;
    public AudioSource audioSourcecut;
    public AudioSource audioSourcewater;
    public AudioClip cutSound;
    public AudioClip waterSound;
    public Animator wateringAnimator;

    private int currentStage = 0;
    public bool isRotten = false;
    private bool isWatered = false;

    void Start()
    {
        // เปิดระยะแรก และซ่อนระยะอื่น
        if (growthStages != null)
        {
            for (int i = 0; i < growthStages.Length; i++)
            {
                growthStages[i].SetActive(i == 0);
            }
        }

        // ซ่อนต้นไม้เน่าหากยังไม่มีการเน่า
        if (rottenTree != null)
        {
            rottenTree.SetActive(false);
        }
    }

    void Update()
    {
        // ตรวจสอบ animation การรดน้ำ เพื่อควบคุมเสียงให้วน/หยุด
        if (wateringAnimator != null && audioSourcewater != null && waterSound != null)
        {
            bool isWatering = wateringAnimator.GetBool("IsWatering");

            if (isWatering)
            {
                if (!audioSourcewater.isPlaying)
                {
                    audioSourcewater.clip = waterSound;
                    audioSourcewater.loop = true;
                    audioSourcewater.Play();
                }
            }
            else
            {
                if (audioSourcewater.isPlaying && audioSourcewater.loop)
                {
                    audioSourcewater.Stop();
                    audioSourcewater.loop = false;
                    audioSourcewater.clip = null;
                }
            }
        }
    }

    public void WaterTree()
    {
        if (isRotten || currentStage >= growthStages.Length - 1 || isWatered) return;

        isWatered = true;
        float randomChance = Random.value;

        // ตรวจสอบการเน่าของต้นไม้
        if (rotChances != null && rotChances.Length > currentStage && Random.value < rotChances[currentStage])
        {
            BecomeRotten();
            return;
        }

        // ตรวจสอบการเจริญเติบโต
        if (growthChances != null && randomChance <= growthChances[currentStage] && !isRotten)
        {
            growthStages[currentStage].SetActive(false);
            currentStage++;
            if (currentStage < growthStages.Length)
            {
                growthStages[currentStage].SetActive(true);
            }
        }

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
            // เล่น Animation ตัด
            if (scissorAnimator != null)
            {
                scissorAnimator.SetTrigger("cut 0");
            }

            // เล่นเสียงตัดทุกครั้งที่ตัด ไม่ต้องเช็คว่าเสียงกำลังเล่นอยู่
            if (audioSourcecut != null && cutSound != null)
            {
                audioSourcecut.PlayOneShot(cutSound);
            }

            // เรียกการฟื้นต้นไม้หลังจากดีเลย์
            Invoke(nameof(RecoverTree), 1f);
        }
    }


    void RecoverTree()
    {
        isRotten = false;

        if (rottenTree != null)
        {
            rottenTree.SetActive(false);
        }

        if (currentStage < growthStages.Length)
        {
            growthStages[currentStage].SetActive(true);
        }

        isWatered = false;
    }

    void ResetWateredStatus()
    {
        isWatered = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isRotten && other.CompareTag("Scissor"))
        {
            CutTree();
        }
    }
}
