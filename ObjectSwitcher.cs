using System.Collections;
using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;
    public float delay = 2f; // เวลาหน่วงในการสลับ

    private void Start()
    {
        StartCoroutine(SwitchObjectsLoop());
    }

    IEnumerator SwitchObjectsLoop()
    {
        while (true)
        {
            objectA.SetActive(true);
            objectB.SetActive(false);
            yield return new WaitForSeconds(delay);

            objectA.SetActive(false);
            objectB.SetActive(true);
            yield return new WaitForSeconds(delay);
        }
    }
}
