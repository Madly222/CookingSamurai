using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour
{
    [SerializeField] private SoundPlayer soundPlayer;
    [SerializeField] private AudioClip sliceSound;

    [SerializeField] private int sliceNeed;
    private int _sliceCount;
    
    [SerializeField] private float breakForce;

    [SerializeField] private GameObject firstPiece;
    [SerializeField] private Rigidbody firstRb;
    
    [SerializeField] private GameObject secondPiece;
    [SerializeField] private Rigidbody secondRb;

    private void OnEnable()
    {
        _sliceCount = 0;
    }

    public void ItemSlicing()
    {
        PlaySound();
        
        if (firstPiece)
        {
            firstPiece.SetActive(true);
            firstRb.AddForce(Vector3.up * breakForce, ForceMode.Impulse);
        }

        if (!secondPiece) return;
        secondPiece.SetActive(true);
        secondRb.AddForce(Vector3.down * breakForce, ForceMode.Impulse);
    }

    public bool ItemMultiSlicing()
    {
        PlaySound();
        //Logger.Log("need:" + sliceNeed + "  count:" + _sliceCount, gameObject);
        return _sliceCount >= sliceNeed;
    }

    private void PlaySound()
    {
        SoundPlayer.Instance.PlayEffect(sliceSound, transform);
    }
}
