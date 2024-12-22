using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceOne : MonoBehaviour
{
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip soundEffect; 
    
    [SerializeField] private float breakForce;

    [SerializeField] private GameObject firstPiece;
    [SerializeField] private Rigidbody firstRB;
    
    [SerializeField] private GameObject secondPiece;
    [SerializeField] private Rigidbody secondRB;

    public void FoodSlicing()
    {
        PlaySound();
        if (firstPiece)
        {
            firstPiece.SetActive(true);
            firstRB.AddForce(Vector3.up * breakForce, ForceMode.Impulse);
        }

        if (!secondPiece) return;
        secondPiece.SetActive(true);
        secondRB.AddForce(Vector3.down * breakForce, ForceMode.Impulse);
    }

    private void PlaySound()
    {
        soundSource.clip = soundEffect;
        soundSource.Play();
    }
}
