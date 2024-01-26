using GhettoBirds.Input;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class GameInputSystem : SystemBase, GameInput.IPlayerCustomActions //GameInput - имя задал при кодогене
{
    private GameInput _gameInput;
    private float2 _move;
    private float2 _touchDelta;
    private bool _accelerate;

    private Plane _plane;
    private Camera _mainCamera;

    private EntityQuery _playerInputQuery;


    protected override void OnCreate()
    {
        _gameInput = new GameInput();
        _gameInput.PlayerCustom.SetCallbacks(this);
        _playerInputQuery = GetEntityQuery(typeof(PlayerInput));
    }

    protected override void OnStartRunning() => _gameInput.Enable();
    protected override void OnStopRunning() => _gameInput.Disable();
  

    protected override void OnUpdate()
    {
        if (_playerInputQuery.CalculateEntityCount() == 0) EntityManager.CreateEntity(typeof(PlayerInput));
        _playerInputQuery.SetSingleton(new PlayerInput
        {
            TouchDelta =  _touchDelta
        });

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _touchDelta = context.ReadValue<Vector2>();
    }
    
    public void OnAccelerate(InputAction.CallbackContext context)
    {
        _accelerate = context.performed;
    }
}



