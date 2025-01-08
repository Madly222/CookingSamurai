using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodController : MonoBehaviour
{
    private enum InteractType
    {
        SliceOne,
        SliceMulti
    }

    [SerializeField] private InteractType selectedType;

    [SerializeField] private Slice slice;
    
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Collider thisColl;
    [SerializeField] private Rigidbody rigidBody;

    [SerializeField] private float dropPower = 5f;

    [SerializeField] private float interactCooldown = 0.2f;
    private bool _isCooldown;
    

    private Vector3 _randomRotationAxis;
    private float _randomRotationSpeed;

    private IEnumerator ApplyImpulseWithDelay()
    {
        yield return new WaitForFixedUpdate();
        rigidBody.AddForce(transform.forward * dropPower, ForceMode.Impulse);
    }

    private void OnEnable()
    {
        meshRenderer.enabled = true;
        thisColl.enabled = true;
        rigidBody.angularVelocity = Random.onUnitSphere * Random.Range(50f, 90f) * Mathf.Deg2Rad;
        StartCoroutine(ApplyImpulseWithDelay());
    }
    
    public bool IsInteracted(string instrument)
    {
        if (_isCooldown) return false;
        StartCoroutine(Cooldown());
        switch (instrument)
        {
            case "knife":
                switch (selectedType)
                {
                    case InteractType.SliceOne:
                        RenderDeactivator();
                        slice.ItemSlicing();
                        return false;
                    case InteractType.SliceMulti:
                        //Logger.Log("Multi sliced", gameObject);
                        if (!slice.ItemMultiSlicing()) return true;
                        RenderDeactivator();
                        return false;
                    default:
                        //Logger.LogError("Interact type error", gameObject);
                        return false;
                }
            case "other":
                return false;
            default:
                //Logger.LogError("Instrument error", gameObject);
                return false; 
        }
    }

    private void RenderDeactivator()
    {
        meshRenderer.enabled = false;
        thisColl.enabled = false;
    }

    private IEnumerator Cooldown()
    {
        _isCooldown = true;
        yield return new WaitForSeconds(interactCooldown);
        _isCooldown = false;
    }
}
