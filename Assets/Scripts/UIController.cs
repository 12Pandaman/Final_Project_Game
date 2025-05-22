using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject uiPanel;  // อ้างอิงไปยัง GameObject ของ UI ที่ต้องการปิด
    public GameObject uiShop;
    public GameObject uiStart;

    public void CloseUI()
    {
        // ทำให้ UI ซ่อน
        uiPanel.SetActive(false);
        uiShop.SetActive(true);
    }
    public void OpenUI()
    {
        // ทำให้ UI แสดง
        uiPanel.SetActive(true);
        uiShop.SetActive(false);

    }

    public void StartUI()
    {

        uiStart.SetActive(false);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // หยุดการเล่นใน Editor
#else
    Application.Quit(); // ปิดเกมใน Build จริง
#endif
    }
}