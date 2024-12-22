using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailClearer : MonoBehaviour
{
    [SerializeField] private TrailRenderer trail;

    private void OnDisable()
    {
        trail.Clear();
    }
}
