using Unity.Mathematics;
using UnityEngine;

public class ChildrenReloader : MonoBehaviour
{
    [SerializeField] private Rigidbody[] rbToReset;
    [SerializeField] private GameObject[] objectsToReset;
    [SerializeField] private ParentReloader parentReloader;

    private int _i;
    public void ResetItem()
    {
        for (_i = 0; _i < rbToReset.Length; _i++)
        {
            rbToReset[_i].velocity = Vector3.zero;        
            rbToReset[_i].angularVelocity = Vector3.zero;
            objectsToReset[_i].transform.localPosition = Vector3.zero;
            objectsToReset[_i].transform.localRotation = quaternion.identity;
            objectsToReset[_i].SetActive(false);
        }
        parentReloader.ResetItem();
    }
}
