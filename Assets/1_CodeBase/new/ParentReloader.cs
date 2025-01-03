using Unity.Mathematics;
using UnityEngine;

public class ParentReloader : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    
    public void ResetItem()
    {
        rigidBody.velocity = Vector3.zero;        
        rigidBody.angularVelocity = Vector3.zero;
        transform.localPosition = Vector3.zero;
        transform.localRotation = quaternion.identity;
        gameObject.SetActive(false);
    }
}
