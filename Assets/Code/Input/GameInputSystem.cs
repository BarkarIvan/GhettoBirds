using GhettoBirds.Input;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class GameInputSystem : SystemBase, GameInput.IPlayerCustomActions 
{
    private GameInput _gameInput;
    private float2 _touchDelta;
    private bool _accelerate;

    private Plane _plane;
    private Camera _mainCamera;

    private EntityQuery _playerInputQuery;
    private Entity _playerInput;


    protected override void OnCreate()
    {
        _gameInput = new GameInput();
        _gameInput.PlayerCustom.SetCallbacks(this);
        
        _playerInput = EntityManager.CreateEntity(typeof(PlayerInput));
    }

    protected override void OnStartRunning() => _gameInput.Enable();
    protected override void OnStopRunning() => _gameInput.Disable();
  

    protected override void OnUpdate()
    {
        var comp = SystemAPI.GetComponentRW<PlayerInput>(_playerInput);
        comp.ValueRW.TouchDelta = _touchDelta;
        comp.ValueRW.Accelerate = _accelerate;
    }
    

    public void OnPointerSwipe(InputAction.CallbackContext context)
    {
        _touchDelta = context.ReadValue<Vector2>();
    }
    
    public void OnPointerPress(InputAction.CallbackContext context)
    {
        _accelerate = context.performed;
    }
}



