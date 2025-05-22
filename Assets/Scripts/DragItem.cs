using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    private Vector3 offset;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        offset = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
        transform.SetAsLastSibling(); // เพิ่มบรรทัดนี้เพื่อให้วัตถุที่ลากอยู่ข้างบนสุด
    }

    void OnMouseDrag()
    {
        transform.position = cam.ScreenToWorldPoint(Input.mousePosition) + offset;
    }
}
