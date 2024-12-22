using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviourSingleton<InputManager>
{
    #region Events

    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;

    #endregion
    private PlayerInputs playerInputs;
    private Camera mainCamera;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }
    private void OnDisable()
    {
        playerInputs.Disable();
    }

    void Start()
    {
        playerInputs.Touch.StartTouch.started += ctx => StartPlayerTouch(ctx);
        playerInputs.Touch.StartTouch.canceled += ctx => EndPlayerTouch(ctx);
    }

    private void StartPlayerTouch(InputAction.CallbackContext context)
    {
        
        if (OnStartTouch != null)
            OnStartTouch(InputUtils.ScreenToWorld(mainCamera, playerInputs.Touch.StartPosition.ReadValue<Vector2>()), (float)context.startTime);
            
    }
    private void EndPlayerTouch(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null)
            OnEndTouch(InputUtils.ScreenToWorld(mainCamera, playerInputs.Touch.StartPosition.ReadValue<Vector2>()), (float)context.time);
            
    }

    public Vector2 PrimaryPosition()
    {
        return InputUtils.ScreenToWorld(mainCamera, playerInputs.Touch.StartPosition.ReadValue<Vector2>());
    }
}
