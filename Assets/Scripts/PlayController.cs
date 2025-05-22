using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public Animator animator;
    public float minCooldown = 3f;  // คูลดาวน์ต่ำสุด 3 วิ
    public float maxCooldown = 6f;  // คูลดาวน์สูงสุด 6 วิ

    private bool canBlink = true; // ตรวจสอบว่าแมวกะพริบตาได้ไหม

    void Start()
    {
        StartCoroutine(BlinkLoop());
    }

    IEnumerator BlinkLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minCooldown, maxCooldown));
            if (canBlink)
            {
                animator.SetTrigger("Blink"); // เล่นแอนิเมชันกระพริบตา
                canBlink = false; // ปิดการกระพริบตาชั่วคราว
                yield return new WaitForSeconds(0.5f); // รอให้แอนิเมชันเล่นจบ
                canBlink = true; // เปิดให้กระพริบตาใหม่
            }
        }
    }
}
