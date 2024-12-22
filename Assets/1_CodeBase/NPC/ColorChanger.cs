using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private bool isSkin;
    [SerializeField] private List<Color> colors;

    private void Awake()
    {
        if(isSkin)
            ChangeSkinColor();
        else
            ChangeDressColor();
    }

    private void ChangeSkinColor()
    {
        Renderer renderer = GetComponent<Renderer>();
        
        if (renderer != null)
        {
            //renderer.material.color = newColor;
        }
    }
    
    private void ChangeDressColor()
    {
        
    }
}
