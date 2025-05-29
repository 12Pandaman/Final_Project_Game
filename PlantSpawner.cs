using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlantSpawner : MonoBehaviour
{
    [System.Serializable]
    public class PlantData
    {
        public GameObject plantPotPrefab;
        public Button newPlantButton;
        public int plantCost = 1;

        [HideInInspector] public bool isOnCooldown = false;
        [HideInInspector] public int purchaseCount = 0;
        [HideInInspector] public bool isAfterCooldownSpawn = false;
    }

    public List<PlantData> plants = new List<PlantData>();
    public Transform spawnPoint;
    public float spacing = 2.0f;
    public float cooldownTime = 10f;
    public int maxPurchasesBeforeCooldown = 5;
    public Vector3 resetPositionAfterCooldown = new Vector3(0.75f, -3.37f, 0f); // ตำแหน่งเกิดหลัง cooldown

    private Vector3 lastSpawnPosition;

    void Start()
    {
        lastSpawnPosition = spawnPoint.position; // เริ่มต้นที่ spawn point

        for (int i = 0; i < plants.Count; i++)
        {
            int index = i;
            if (plants[index].newPlantButton != null)
            {
                plants[index].newPlantButton.onClick.AddListener(() => TrySpawnPlant(index));
            }
            else
            {
                Debug.LogError($"Button for plant index {index} is not assigned!");
            }
        }
    }

    void TrySpawnPlant(int index)
    {
        PlantData plantData = plants[index];

        if (plantData.isOnCooldown)
        {
            Debug.Log($"ต้นไม้ชนิด {index} อยู่ในช่วง cooldown");
            return;
        }

        if (plantData.purchaseCount < maxPurchasesBeforeCooldown)
        {
            if (CoinManager.Instance.SpendCoins(plantData.plantCost))
            {
                if (plantData.isAfterCooldownSpawn)
                {
                    lastSpawnPosition = resetPositionAfterCooldown;
                    plantData.isAfterCooldownSpawn = false;
                }

                Vector3 spawnPosition = lastSpawnPosition;

                GameObject newPlant = Instantiate(plantData.plantPotPrefab, spawnPosition, Quaternion.identity);
                Vector3 defaultScale = new Vector3(0.392584f, 0.392584f, 0.392584f);
                newPlant.transform.localScale = defaultScale;

                PlantSizeAdjust plantScript = newPlant.GetComponent<PlantSizeAdjust>();
                if (plantScript != null)
                {
                    plantScript.SetOriginalScale(defaultScale);
                }

                // เตรียมตำแหน่งใหม่สำหรับครั้งถัดไป
                lastSpawnPosition -= new Vector3(spacing, 0, 0);

                plantData.purchaseCount++;

                if (plantData.purchaseCount >= maxPurchasesBeforeCooldown)
                {
                    StartCoroutine(CooldownPlant(index));
                }
            }
            else
            {
                Debug.Log("ไม่พอ coin เพื่อซื้อต้นไม้");
            }
        }
    }

    IEnumerator CooldownPlant(int index)
    {
        PlantData plantData = plants[index];
        plantData.isOnCooldown = true;
        plantData.newPlantButton.interactable = false;

        Debug.Log($"ปุ่มสำหรับต้นไม้ {index} กำลัง cooldown...");

        yield return new WaitForSeconds(cooldownTime);

        plantData.purchaseCount = 0;
        plantData.isOnCooldown = false;
        plantData.newPlantButton.interactable = true;
        plantData.isAfterCooldownSpawn = true;

        Debug.Log($"ปุ่มสำหรับต้นไม้ {index} พร้อมใช้งานอีกครั้ง! ต้นต่อไปจะไปเกิดที่ตำแหน่งพิเศษ");
    }
}
