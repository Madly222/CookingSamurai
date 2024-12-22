using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraRotator : MonoBehaviour
{
    private bool _isRotating;

    [SerializeField] private float rotatingTime = 1f;
    private Quaternion _targetRotation;

    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;

    private bool _waitSell;
    public bool rotatedToNpc;
    
    public void OnButtonClick()
    {
        if (!_isRotating)
        {
            StartCoroutine(HandleRotation());
        }
    }

    private IEnumerator HandleRotation()
    {
        if (rotatedToNpc)
        {
            rightButton.SetActive(false);
            yield return StartCoroutine(RotateCamera(90));
            leftButton.SetActive(true);
            rotatedToNpc = false;
        }
        else
        {
            
            leftButton.SetActive(false);
            yield return StartCoroutine(RotateCamera(-90));
            if(!_waitSell)
                rightButton.SetActive(true);
            rotatedToNpc = true;
        }
    }

    public void EnableRightB(bool enable)
    {
        rightButton.SetActive(enable);
        _waitSell = !enable;
    }
    

    private IEnumerator RotateCamera(int rotation)
    {
        _isRotating = true;
        
        _targetRotation = transform.rotation * Quaternion.Euler(0, rotation, 0);
    
        var elapsedTime = 0f;
        var startRotation = transform.rotation;

        while (elapsedTime < rotatingTime)
        {
            transform.rotation = Quaternion.Slerp(startRotation, _targetRotation, elapsedTime / rotatingTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        transform.rotation = _targetRotation;

        _isRotating = false;
    }
}
