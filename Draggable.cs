using TMPro;
using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isDragging = false;
    private bool isAbsorbing = false;

    public LayerMask validLayers;
    public LayerMask shelfLayer;
    public LayerMask tableLayer;
    public LayerMask holeLayer;
    public AudioSource audioSource;
    public Vector2 overlapSize = new Vector2(1f, 1f);
    public bool returnToOriginalPosition = false;

    private TreeGrowth treeGrowthScript;

    // กำหนดราคาของแต่ละ stage ตาม index
    // ตัวอย่างสมมติมี 5 stages
    public int[] coinRewardsPerStage = new int[] { 0, 0, 0, 2, 1 };
    // index 3 คือราคา stage ปกติ (healthy) = 2 coins
    // index 4 คือราคา stage เน่า (rotten) = 1 coin

    void Start()
    {
        originalPosition = transform.position;
        treeGrowthScript = GetComponent<TreeGrowth>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAbsorbing)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, validLayers);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
            }
        }

        if (isDragging)
        {
            FollowMouse();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;

            if (IsOnHole())
            {
                StartCoroutine(AbsorbIntoHole());
            }
            else if (returnToOriginalPosition)
            {
                StartCoroutine(ReturnToStartPosition());
            }
            else if (!IsOnShelf() && !IsOnTable())
            {
                transform.position = originalPosition;
            }
            else
            {
                originalPosition = transform.position;
            }
        }
    }

    IEnumerator AbsorbIntoHole()
    {
        if (treeGrowthScript != null && treeGrowthScript.isRotten)
        {
            Debug.Log("ไม่สามารถดูดต้นไม้เน่าได้!");
            yield break;
        }

        isAbsorbing = true;
        yield return new WaitForSeconds(0.5f);

        if (treeGrowthScript != null)
        {
            bool coinAdded = false;

            for (int i = 0; i < treeGrowthScript.growthStages.Length; i++)
            {
                if (treeGrowthScript.growthStages[i].activeSelf)
                {
                    if (i < coinRewardsPerStage.Length)
                    {
                        int reward = coinRewardsPerStage[i];
                        if (reward > 0)
                        {
                            CoinManager.Instance.AddCoins(reward);
                            Debug.Log($"ขายต้นไม้ระยะที่ {i} + เพิ่ม {reward} Coin");

                            // ✅ เพิ่มจำนวนต้นไม้ที่ขาย
                            TreeSaleManager.Instance.AddSoldTree();

                            coinAdded = true;
                            break;
                        }
                    }
                }
            }

            if (!coinAdded)
            {
                Debug.Log("ต้นไม้นี้ไม่ได้ระยะที่กำหนด → ไม่ได้ Coin");
            }
        }

        Destroy(gameObject); // ทำลายต้นไม้หลังขาย
    }

    void FollowMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
    }

    IEnumerator ReturnToStartPosition()
    {
        float duration = 0.2f;
        float elapsedTime = 0;
        Vector3 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, originalPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
    }

    bool IsOnShelf()
    {
        return Physics2D.OverlapBox(transform.position, overlapSize, 0, shelfLayer) != null;
    }

    bool IsOnTable()
    {
        return Physics2D.OverlapBox(transform.position, overlapSize, 0, tableLayer) != null;
    }

    bool IsOnHole()
    {
        return Physics2D.OverlapBox(transform.position, overlapSize, 0, holeLayer) != null;
    }
}
