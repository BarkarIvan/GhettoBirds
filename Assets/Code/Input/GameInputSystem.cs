using GhettoBirds.Input;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = System.Numerics.Vector3;

public partial class GameInputSystem : SystemBase, GameInput.IPlayerCustomActions
{
    private GameInput _gameInput;
    private float2 _move;

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
            Move =  _move
        });

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
       Debug.Log("look");
    }

    public void OnFire(InputAction.CallbackContext context)
    {
       Debug.Log("onFire");
    }
}



