using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    public TextMeshProUGUI coinText;
    public int coinCount = 5; // กำหนดค่าเริ่มต้น

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateCoinUI();
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        UpdateCoinUI();
    }

    public bool SpendCoins(int amount)
    {
        if (coinCount >= amount)
        {
            coinCount -= amount;
            UpdateCoinUI();
            return true;
        }
        Debug.Log("Coin ไม่พอ!");
        return false;
    }

    private void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = coinCount.ToString();
        }
    }
}
