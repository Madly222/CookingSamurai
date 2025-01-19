using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Material[] materialPool;
    [SerializeField] private Renderer thisItem;

    private int _randomIndex;

    private void OnEnable()
    {
        thisItem.material = GetRandomMaterial();
    }

    private Material GetRandomMaterial()
    {
        _randomIndex = Random.Range(0, materialPool.Length);
        return materialPool[_randomIndex];
    }
}
