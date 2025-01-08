using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodData : MonoBehaviour
{
    [SerializeField] private CookController cookController;
    [SerializeField] private ChildrenReloader childrenReloader;

    [SerializeField] public string itemName;
    [SerializeField] public GameObject cookedVersion;
    
    [SerializeField] private SoundPlayer soundPlayer;
    [SerializeField] private AudioClip soundEffect;

    private bool _canClaim;
    
    public void ClaimItem()
    {
        _canClaim = cookController.SpawnPreparedPiece(cookedVersion, itemName);
        childrenReloader.ResetItem();
        if(!_canClaim)
            return;
        
        SoundPlayer.Instance.PlayEffect(soundEffect, transform);
    }
}
