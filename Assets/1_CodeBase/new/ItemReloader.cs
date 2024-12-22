using Unity.Mathematics;
using UnityEngine;

public class ItemReloader : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private Rigidbody rigidBody;
    
    public void ResetItem()
    {
        transform.SetParent(parent.transform);
        rigidBody.velocity = Vector3.zero;        
        rigidBody.angularVelocity = Vector3.zero;
        transform.localPosition = Vector3.zero;
        transform.localRotation = quaternion.identity;
        gameObject.SetActive(false);
    }
}
