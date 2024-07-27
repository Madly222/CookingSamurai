using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] public string ingredientName;

    [SerializeField] private float breakForce;

    [SerializeField] private GameObject firstPiece;
    [SerializeField] private Rigidbody firstRB;
    
    [SerializeField] private GameObject secondPiece;
    [SerializeField] private Rigidbody secondRB;
    
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Collider collider;

    public void Cutting()
    {
        meshRenderer.enabled = false;
        collider.enabled = false;
        
        firstPiece.SetActive(true);
        secondPiece.SetActive(true);
        
        firstRB.AddForce(Vector3.up * breakForce, ForceMode.Impulse);
        firstRB.AddForce(Vector3.left * breakForce/2, ForceMode.Impulse);
        
        secondRB.AddForce(Vector3.down * breakForce, ForceMode.Impulse);
        secondRB.AddForce(Vector3.right * breakForce/2, ForceMode.Impulse);
    }

    private void InCutting(GameObject piece)
    {
        piece.SetActive(true);
    }
    private void OnEnable()
    {
        StartCoroutine(Deleter());
    }
    
    private IEnumerator Deleter()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    }
}
