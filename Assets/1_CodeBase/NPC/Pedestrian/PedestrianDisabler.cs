using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianDisabler : MonoBehaviour
{
    [SerializeField] private float lifeTime = 20f;
    
    private void OnEnable()
    {
        StartCoroutine(LifeTimeCd());
    }

    private IEnumerator LifeTimeCd()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
}
