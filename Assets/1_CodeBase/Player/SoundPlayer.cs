using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer Instance; 
    
    [SerializeField] private AudioSource[] soundSource;
    [SerializeField] private GameObject[] soundPoint;

    private int _soundIndex;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayEffect(AudioClip soundEffect, Transform soundPosition)
    {
        for (_soundIndex = 0; _soundIndex < soundPoint.Length; _soundIndex++)
        {
            if (soundSource[_soundIndex].isPlaying) continue;

            soundSource[_soundIndex].clip = soundEffect;
            soundPoint[_soundIndex].transform.position = soundPosition.position;

            soundSource[_soundIndex].Play();
            return;
        }
    }
}
