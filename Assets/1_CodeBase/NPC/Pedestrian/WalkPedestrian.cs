using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class WalkPedestrian : MonoBehaviour
{
    [SerializeField] private Transform[] startPoint;
    [SerializeField] private Transform[] endPoint;
    
    [SerializeField] private float walkDuration = 20f;
    
    private int _point;
    private float _elapsedTime;

    private void OnEnable()
    {
        StartMovement();
    }
    
    private void StartMovement()
    {
        _point = Randomizer(0, startPoint.Length);
        transform.position = startPoint[_point].position;
        transform.rotation = startPoint[_point].rotation;
        
        StartCoroutine(MoveToTarget());
    }
    
    private IEnumerator MoveToTarget()
    {
        _elapsedTime = 0f;

        while (_elapsedTime < walkDuration)
        {
            transform.position = Vector3.Lerp(transform.position, endPoint[_point].position, _elapsedTime / walkDuration);
            _elapsedTime += Time.deltaTime;
            
            yield return null;
        }
        
        gameObject.SetActive(false);
    }
    
    private static int Randomizer(int min, int max)
    {
        return Random.Range(min, max);;
    }
    
}
