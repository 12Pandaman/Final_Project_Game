using TMPro;
using UnityEngine;
using System.Collections;

public class TreeSaleManager : MonoBehaviour
{
    public static TreeSaleManager Instance;

    public int totalTreesSold = 0;
    public TMP_Text treeSoldText;

    private Vector3 originalScale;
    private Color originalColor;
    public Color highlightColor = Color.yellow; // สีเน้นตอนขยาย

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (treeSoldText != null)
        {
            originalScale = treeSoldText.transform.localScale;
            originalColor = treeSoldText.color;
        }
    }

    public void AddSoldTree()
    {
        totalTreesSold++;
        UpdateTreeSoldUI();
        StartCoroutine(AnimateTextScaleAndColor());
    }

    void UpdateTreeSoldUI()
    {
        if (treeSoldText != null)
        {
            treeSoldText.text = totalTreesSold.ToString();
        }
    }

    IEnumerator AnimateTextScaleAndColor()
    {
        if (treeSoldText == null) yield break;

        float duration = 0.3f;
        float elapsed = 0f;
        Vector3 targetScale = originalScale * 1.5f;

        // ขยายใหญ่ + เปลี่ยนสีไปสี highlight
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            treeSoldText.transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            treeSoldText.color = Color.Lerp(originalColor, highlightColor, t);
            yield return null;
        }

        // รอครู่หนึ่งก่อนกลับ
        yield return new WaitForSeconds(0.1f);

        // ย่อกลับ + เปลี่ยนสีกลับสีเดิม
        elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            treeSoldText.transform.localScale = Vector3.Lerp(targetScale, originalScale, t);
            treeSoldText.color = Color.Lerp(highlightColor, originalColor, t);
            yield return null;
        }

        treeSoldText.transform.localScale = originalScale;
        treeSoldText.color = originalColor;
    }
}
