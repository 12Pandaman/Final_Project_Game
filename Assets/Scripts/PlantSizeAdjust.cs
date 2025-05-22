using System.Collections;
using UnityEngine;

public class PlantSizeAdjust : MonoBehaviour
{
    private Vector3 originalScale;
    private Coroutine currentCoroutine;
    private Coroutine moveCoroutine;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void SetOriginalScale(Vector3 scale)
    {
        originalScale = scale;
        transform.localScale = scale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shelf"))
        {
            StartSizeChange(originalScale * 0.5f);

            // หาตำแหน่งจุดที่ใกล้ที่สุดบน Shelf ที่ชนกับวัตถุนี้
            Vector3 contactPoint = other.ClosestPoint(transform.position);

            // ดูดเข้าไปหาจุดนั้น
            StartMoveToShelf(contactPoint);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Shelf"))
        {
            StartSizeChange(originalScale);
        }
    }

    void StartSizeChange(Vector3 targetSize)
    {
        if (!gameObject.activeInHierarchy) return;

        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(ChangeSize(targetSize));
    }

    IEnumerator ChangeSize(Vector3 targetSize)
    {
        float duration = 0.2f;
        float time = 0;
        Vector3 startSize = transform.localScale;

        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(startSize, targetSize, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetSize;
    }

    void StartMoveToShelf(Vector3 targetPosition)
    {
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);

        moveCoroutine = StartCoroutine(MoveToPosition(targetPosition));
    }

    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        float duration = 0.2f;
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        // 🕐 ค้างไว้ 1 วินาที
        yield return new WaitForSeconds(2f);

        // คุณสามารถเพิ่ม logic ต่อจากนี้ได้ เช่น lock การเคลื่อนที่
    }
}
