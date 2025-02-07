using System.Collections;
using UnityEngine;

public class CustomerCatcher : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private GameObject prepareBoxes;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ColdownToEnable());
    }

    IEnumerator ColdownToEnable()
    {
        yield return new WaitForSeconds(1f);
        dialogBox.SetActive(true);
        prepareBoxes.SetActive(true);
    }
}
