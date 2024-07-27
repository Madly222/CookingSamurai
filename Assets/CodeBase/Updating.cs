using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updating : MonoBehaviour
{
    private bool isDragging = false;
    private ItemController _itemController;

    void Update()
    {
#if UNITY_EDITOR
        HandleMouseInput();
#else
            HandleTouchInput();
#endif
    }

    private void HandleMouseInput()
    {
        // Логика для мыши
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            RaycastFromScreenPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            RaycastFromScreenPoint(Input.mousePosition);
        }
    }

    private void HandleTouchInput()
    {
        // Логика для сенсорного экрана
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                RaycastFromScreenPoint(touch.position);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
            }

            if (isDragging && (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary))
            {
                RaycastFromScreenPoint(touch.position);
            }
        }
    }

    private void RaycastFromScreenPoint(Vector3 screenPoint)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPoint);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            _itemController = hit.collider.GetComponent<ItemController>();
            if (_itemController != null)
            {
                _itemController.Cutting();
            }
        }
    }
}
