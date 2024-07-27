using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraRotator : MonoBehaviour
{
    
     private bool _isRotating;
     private Quaternion _cookingRotation = Quaternion.Euler(0, 270, 0);
     private Quaternion _customerRotation = Quaternion.Euler(0, 180, 0);
     private float _rotatingTime = 0.75f;
     private Quaternion _targetRotation;
    
    [SerializeField] private GameObject rotatingButton;
    [SerializeField] private GameObject spawnButton;
    [SerializeField] private TMP_Text text;
    
    public void OnButtonClick()
    {
        if(!_isRotating)
            StartCoroutine(RotateCamera());
    }

    private IEnumerator RotateCamera()
    {
        _isRotating = true;
        var startRotation = transform.rotation;
        
        if (startRotation == _customerRotation)
        {
            _targetRotation = _cookingRotation;
        }
        else
        {
            text.text = "To cooking";
            spawnButton.SetActive(false);
        }
        
        rotatingButton.SetActive(false);
        
        var elapsedTime = 0f;
        while (elapsedTime < _rotatingTime)
        {
            transform.rotation = Quaternion.Slerp(startRotation, _targetRotation, elapsedTime / _rotatingTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = _targetRotation;
        _isRotating = false;
        rotatingButton.SetActive(true);
        
        if (_targetRotation != _cookingRotation) yield break;
        text.text = "To customers";
        spawnButton.SetActive(true);
        _targetRotation = _customerRotation;
    }
}
