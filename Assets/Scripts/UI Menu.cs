
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public GameObject uidiamond; 
    public GameObject uisetting;
    public GameObject uiopen1;
    public GameObject uiyes1;
    public GameObject uino1;
    public GameObject uiopenads1;
    public GameObject uiyesads1;
    public GameObject uinoads1;
    public float cooldownTime = 10f; // Cooldown 10 วินาที
    private float nextAvailableTime = 0f;


    public void CloseUI()
    {
        // ทำให้ UI ซ่อน
        uisetting.SetActive(false);
       
    }
    public void OpenUI()
    {
        // ทำให้ UI แสดง
        uisetting.SetActive(true);
        
    }

    public void Closeuidiamond()
    {
        // ทำให้ UI ซ่อน
        uidiamond.SetActive(false);
       
    }

    public void Openuidiamond()
    {
        // ทำให้ UI แสดง
        uidiamond.SetActive(true);
        
    }

    public void openbuy1()
    {
        uiopen1.SetActive(true);
        uiyes1.SetActive(true);
        uino1.SetActive(true);
    }
    public void yesbuy1()
    {
        uiyes1.SetActive(false);
        uiopen1.SetActive(false);
    }
    public void nobuy1()
    {
        uino1.SetActive(false);
        uiopen1.SetActive(false);
    }

    public void openbuyads1()
    {
        if (Time.time >= nextAvailableTime)
        {
            uiopenads1.SetActive(true);
            uiyesads1.SetActive(true);
            uinoads1.SetActive(true);

            nextAvailableTime = Time.time + cooldownTime; // ตั้งเวลา cooldown ใหม่
        }
        else
        {
            Debug.Log("ยังไม่ครบเวลา Cooldown");
        }
    }
    public void yesbuyads1()
    {
        uiyesads1.SetActive(false);
        uiopenads1.SetActive(false);
    }
    public void nobuyads1()
    {
        uinoads1.SetActive(false);
        uiopenads1.SetActive(false);
    }
}