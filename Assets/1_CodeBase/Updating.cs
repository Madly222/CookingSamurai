using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class Updating : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayerMask;
    [SerializeField] private LevelManager levelManager;
    private readonly Dictionary<Collider, FoodController> _cachedFoodControllers = new ();
    [SerializeField] private Camera playerCamera;

    [SerializeField] private TextMeshProUGUI fpsText;
    [SerializeField] private int targetFps;
    private float deltaTime;
    private float fpsUpdateTimer;

    [SerializeField] private GameObject slideEff;
    [SerializeField] private GameObject multiSlicingEff;
    [SerializeField] private float vfxDistanceFromCamera = 1f;

    public bool canSlice;
    
    private bool? _needEffect;
    void Start()
    {
        Application.targetFrameRate = targetFps;
        //ChangeSlideEffect();
    }
    
    private void Update()
    {
        HandleTouchInput();
        FpsCounter();
    }

    private void FpsCounter()
    {
        fpsUpdateTimer -= Time.deltaTime;

        if (fpsUpdateTimer <= 0f)
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
            float fps = 1.0f / deltaTime;

            if (fpsText != null)
            {
                fpsText.text = $"{fps:0.} FPS";
            }
        }
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount <= 0 || !canSlice) return;
        var touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                StartingMoveVFXToTouchPosition(touch.position);
                break;
            case TouchPhase.Moved:
            case TouchPhase.Stationary:
                RaycastFromScreenPoint(touch.position);
            break;
            case TouchPhase.Canceled:
            case TouchPhase.Ended:
                StartCoroutine(EffectDelay(0.2f, slideEff));
            break;
        }
    }

    private void RaycastFromScreenPoint(Vector3 screenPoint)
    {
        var ray = playerCamera.ScreenPointToRay(screenPoint);
        
        MoveVFXToTouchPosition(ray.GetPoint(vfxDistanceFromCamera));

        if (!Physics.Raycast(ray, out var hit, 20f, interactableLayerMask)) return;

        if (!_cachedFoodControllers.TryGetValue(hit.collider, out var foodController))
        {
            foodController = hit.collider.GetComponent<FoodController>();
            if (foodController)
                _cachedFoodControllers[hit.collider] = foodController;
        }

        _needEffect = foodController?.IsInteracted("knife");
        if (_needEffect != null && (bool)!_needEffect) return;
    }

    private void StartingMoveVFXToTouchPosition(Vector3 worldPosition)
    {
        slideEff.SetActive(false);
        slideEff.transform.position = worldPosition;
    }
    
    private void MoveVFXToTouchPosition(Vector3 worldPosition)
    {
        slideEff.transform.position = worldPosition;
        slideEff.SetActive(true);
    }
    
    private IEnumerator EffectDelay(float delay, GameObject effect)
    {
        yield return new WaitForSeconds(delay);
        effect.SetActive(false);
    }
}

