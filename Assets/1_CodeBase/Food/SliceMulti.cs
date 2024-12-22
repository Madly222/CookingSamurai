using System;
using System.Collections;
using System.Collections.Generic;
using CartoonFX;
using UnityEngine;

public class SliceMulti : MonoBehaviour
{
    [SerializeField] private CFXR_ParticleText particleText;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private new Collider collider;
    [SerializeField] private GameObject sliced;
    [SerializeField] private ParticleSystem sliccingEffect;

    [SerializeField] private int necessarySlicing;
    [SerializeField] private float minDistance;
    [SerializeField] private float zoomSpeed;
    
    //private bool _oneTime;
    //private bool _coldown;
    public int _slicingCount;
    private Vector3 _initialPosition = new (0f, 1.3f, 0f);

    private bool animated;

    public void Update()
    {
        if(!animated)
            StartCoroutine(Test());
    }

    public void MultiCutting( )
    {
        
    }

    private void FinishCut()
    {
        meshRenderer.enabled = false;
        collider.enabled = false;
        sliced.SetActive(true);
    }

    private IEnumerator Test()
    {
        animated = true;
        sliccingEffect.Play();
        //particleText.UpdateText((necessarySlicing-_slicingCount).ToString());
        yield return new WaitForSeconds(0.5f);
        sliccingEffect.Stop();
        animated = false;
    }

    private IEnumerator ColdownTimer()
    {
        sliccingEffect.Play();
        particleText.UpdateText((necessarySlicing-_slicingCount).ToString());
        //_coldown = true;
        yield return new WaitForSeconds(0.5f);
        _slicingCount++;
        sliccingEffect.Stop();
        Debug.Log(_slicingCount);
    
        //_coldown = false;
    }
    private IEnumerator ZoomToObject(Camera playerCamera)
    {
        //_oneTime = true;
        var distanceToTarget = Vector3.Distance(playerCamera.transform.position, transform.position);
        Physics.simulationMode = SimulationMode.Script;

        while (distanceToTarget > minDistance)
        {
            playerCamera.transform.position = Vector3.MoveTowards(playerCamera.transform.position, transform.position, zoomSpeed * Time.deltaTime);
            
            distanceToTarget = Vector3.Distance(playerCamera.transform.position, transform.position);
            
            yield return null;
        }
    }
}
