using UnityEngine;
using System.Collections;

public class TreeGrowthV2 : MonoBehaviour
{
    public GameObject[] growthStages;
    public GameObject rottenTree;
    public float[] growthChances;
    public float[] rotChances;
    public float[] growthDelays; // ระบุ delay แต่ละ stage

    public Animator scissorAnimator;
    public AudioSource audioSourcecut;
    public AudioSource audioSourcewater;
    public AudioClip cutSound;
    public AudioClip waterSound;
    public Animator wateringAnimator;

    private int currentStage = 0;
    public bool isRotten = false;
    private bool isWatered = false;

    private Coroutine blinkingCoroutine;
    private Coroutine growCoroutine;

    void Start()
    {
        for (int i = 0; i < growthStages.Length; i++)
        {
            growthStages[i].SetActive(i == 0);
        }

        if (rottenTree != null)
            rottenTree.SetActive(false);

        StartBlinking(); // เริ่มกระพิบตั้งแต่เริ่มต้น
    }

    void Update()
    {
        if (wateringAnimator != null && audioSourcewater != null && waterSound != null)
        {
            bool isWatering = wateringAnimator.GetBool("IsWatering");

            if (isWatering && !audioSourcewater.isPlaying)
            {
                audioSourcewater.clip = waterSound;
                audioSourcewater.loop = true;
                audioSourcewater.Play();
            }
            else if (!isWatering && audioSourcewater.isPlaying)
            {
                audioSourcewater.Stop();
                audioSourcewater.loop = false;
                audioSourcewater.clip = null;
            }
        }
    }

    public void WaterTree()
    {
        if (isRotten || currentStage >= growthStages.Length - 1 || isWatered) return;

        isWatered = true;
        StopBlinking();

        if (rotChances != null && rotChances.Length > currentStage && Random.value < rotChances[currentStage])
        {
            BecomeRotten();
            return;
        }

        float delay = 1f;
        if (growthDelays != null && currentStage < growthDelays.Length)
        {
            delay = growthDelays[currentStage];
        }

        if (growCoroutine != null) StopCoroutine(growCoroutine);
        growCoroutine = StartCoroutine(GrowAfterDelay(delay));
    }

    IEnumerator GrowAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (growthChances != null && Random.value <= growthChances[currentStage] && !isRotten)
        {
            growthStages[currentStage].SetActive(false);
            currentStage++;

            if (currentStage < growthStages.Length)
            {
                growthStages[currentStage].SetActive(true);
            }
        }

        isWatered = false;

        if (!isRotten && currentStage < growthStages.Length - 1)
        {
            StartBlinking();
        }
    }

    void BecomeRotten()
    {
        isRotten = true;
        if (rottenTree != null)
            rottenTree.SetActive(true);

        if (growCoroutine != null) StopCoroutine(growCoroutine);
        StopBlinking();
    }

    public void CutTree()
    {
        if (!isRotten) return;

        if (scissorAnimator != null)
            scissorAnimator.SetTrigger("cut 0");

        if (audioSourcecut != null && cutSound != null)
            audioSourcecut.PlayOneShot(cutSound);

        Invoke(nameof(RecoverTree), 1f);
    }

    void RecoverTree()
    {
        isRotten = false;

        if (rottenTree != null)
            rottenTree.SetActive(false);

        if (currentStage < growthStages.Length)
            growthStages[currentStage].SetActive(true);

        isWatered = false;
        StartBlinking();
    }

    void StartBlinking()
    {
        if (blinkingCoroutine != null)
            StopCoroutine(blinkingCoroutine);
        blinkingCoroutine = StartCoroutine(Blink());
    }

    void StopBlinking()
    {
        if (blinkingCoroutine != null)
            StopCoroutine(blinkingCoroutine);

        SetStageAlpha(1f); // กลับมาเป็นปกติ
    }

    IEnumerator Blink()
    {
        while (true)
        {
            SetStageAlpha(0.5f); // ทำให้โปร่งใสเหมือนเทาๆ
            yield return new WaitForSeconds(0.3f);
            SetStageAlpha(1f); // กลับมาปกติ
            yield return new WaitForSeconds(0.3f);
        }
    }

    void SetStageAlpha(float alpha)
    {
        if (currentStage < growthStages.Length)
        {
            SpriteRenderer sr = growthStages[currentStage].GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                Color color = sr.color;
                color.a = alpha;
                sr.color = color;
            }
        }
    }

  private void OnTriggerEnter2D(Collider2D other)
{
    // ถ้าต้นไม้เน่า และโดนกรรไกร
    if (isRotten && other.CompareTag("Scissor"))
    {
        CutTree();
    }
    // ถ้าถูกชนโดย Jar (ที่รดน้ำ)
    else if (other.CompareTag("Jar"))
    {
        WaterTree();
    }
}
}
