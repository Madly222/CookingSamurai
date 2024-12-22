using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodData : MonoBehaviour
{
    [SerializeField] private CookController cookController;
    [SerializeField] private ItemReloader reloadParent;

    [SerializeField] public string itemName;
    [SerializeField] public GameObject cookedVersion;
    
    [SerializeField] private SoundPlayer soundPlayer;
    [SerializeField] private AudioClip soundEffect; 
    
    public void ClaimItem()
    {
        SoundPlayer.Instance.PlayEffect(soundEffect, transform);
        cookController.SpawnPreparedPiece(cookedVersion, itemName);
        
        reloadParent.ResetItem();
        gameObject.SetActive(false);
    }
}
