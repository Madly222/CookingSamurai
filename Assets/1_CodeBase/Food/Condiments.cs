using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condiments : MonoBehaviour
{
    [SerializeField] private CookController cookController;
    [SerializeField] private AudioClip claimSound;
    [SerializeField] private SoundPlayer soundPlayer;
    
    public void OnMouseDown()
    {
        cookController.CheckPreparing(name);
        ClaimSoundPlay();
    }
    
    private void ClaimSoundPlay()
    {
        SoundPlayer.Instance.PlayEffect(claimSound, transform);
    }
}
