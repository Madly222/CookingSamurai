using Unity.Mathematics;
using UnityEngine;

public class ItemHider : MonoBehaviour
{
    private void OnDisable()
    {
        gameObject.SetActive(false);
    }
}
