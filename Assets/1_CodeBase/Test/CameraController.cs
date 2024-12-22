using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float rotatingTime = 1f;
    
    private Quaternion _targetRotation;
    private bool _isRotating;
    private float _elapsedTime;
    //[SerializeField] private Updating updating;
    /*[SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;
    [SerializeField] private GameObject spawnButton;
    private bool _waitSell;*/
    /*public void OnButtonClick()
    {
        if (!_isRotating)
        {
            StartCoroutine(HandleRotation());
        }
    }*/

    /*private IEnumerator HandleRotation()
    {
        if (rotatedToNpc)
        {
            rightButton.SetActive(false);
            yield return StartCoroutine(RotateCamera(90));
            updating.CanSlice(rotatedToNpc);
            spawnButton.SetActive(true);
            leftButton.SetActive(true);
            rotatedToNpc = false;
        }
        else
        {
            
            updating.CanSlice(rotatedToNpc);
            leftButton.SetActive(false);
            spawnButton.SetActive(false);
            yield return StartCoroutine(RotateCamera(-90));
            if(!_waitSell)
                rightButton.SetActive(true);
            rotatedToNpc = true;
        }
    }*/

    public float RotateCamera(bool toNpc)
    {
        if(_isRotating) return 0f;

        StartCoroutine(SmoothRotate(toNpc));
        return rotatingTime;
    }
    private IEnumerator SmoothRotate(bool toNpc)
    {
        _isRotating = true;
        _elapsedTime = 0;
        
        if(toNpc)
            _targetRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
        else
            _targetRotation = transform.rotation * Quaternion.Euler(0, -90, 0);
        
        var startRotation = transform.rotation;

        while (_elapsedTime < rotatingTime)
        {
            transform.rotation = Quaternion.Slerp(startRotation, _targetRotation, _elapsedTime / rotatingTime);
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        transform.rotation = _targetRotation;

        _isRotating = false;
    }
}
