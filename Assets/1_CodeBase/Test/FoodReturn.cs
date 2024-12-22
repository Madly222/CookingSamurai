using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodReturn : MonoBehaviour
{
    [SerializeField] private GameObject parent;

    private void OnDisable()
    {
        transform.SetParent(parent.transform);
    }
}
