using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DiamondManager : MonoBehaviour
{
    public Button buy1Button;
    public Button ads1Button;
    public Button buy5Button;
    public Button ads5Button;
    public TextMeshProUGUI diamondText;

    public int diamonds = 0;

    public void Start()
    {
        buy1Button.onClick.AddListener(() => AddDiamonds(1));
        ads1Button.onClick.AddListener(() => WatchAdForDiamonds(1));
        buy5Button.onClick.AddListener(() => AddDiamonds(5));
        ads5Button.onClick.AddListener(() => WatchAdForDiamonds(5));
        UpdateDiamondUI();
    }

    void AddDiamonds(int amount)
    {
        diamonds += amount;
        UpdateDiamondUI();
        Debug.Log("Bought diamonds: " + amount + " | Total: " + diamonds);
    }

    void WatchAdForDiamonds(int amount)
    {
        // เรียกโฆษณา (สมมุติ)
        Debug.Log("Watching ad...");
        // หลังดูโฆษณาสำเร็จ:
        diamonds += amount;
        UpdateDiamondUI();
        Debug.Log("Received diamonds from ad: " + amount + " | Total: " + diamonds);
    }

    void UpdateDiamondUI()
    {
        diamondText.text = diamonds.ToString();
    }
}
