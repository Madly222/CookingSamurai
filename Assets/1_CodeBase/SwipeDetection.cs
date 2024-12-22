using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private float MinimalDistance = 0.1f;
    private InputManager _inputManager;
    private Vector2 _startPosition;
    private Vector2 _endPosition;

    private void Awake()
    {
        _inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        _inputManager.OnStartTouch += SwipeStart;
        _inputManager.OnEndTouch += SwipeEnd;
    }
    private void OnDisable()
    {
        _inputManager.OnStartTouch -= SwipeStart;
        _inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        _startPosition = position;
    }
    private void SwipeEnd(Vector2 position, float time)
    {
        _endPosition = position;
        DetectSwipe();
    }
    private void DetectSwipe()
    {
        if (Vector3.Distance(_startPosition, _endPosition) >= MinimalDistance)
        {
            Debug.DrawLine(_startPosition,_endPosition, Color.red, 2f );
        }
    }
}
