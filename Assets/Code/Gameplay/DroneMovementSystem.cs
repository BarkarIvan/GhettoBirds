using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.InputSystem;

public partial struct DroneMovementSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<PlayerInput>();
        // state.RequireForUpdate<DroneMovement>();
        //config to future
    }
    
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        //to future
        //var config = SystemAPI.GetSingleton<Config>();
        var input = SystemAPI.GetSingleton<PlayerInput>();
      

        foreach (var playerTransform in SystemAPI.Query<RefRW<LocalTransform>>()
                     .WithAll<DroneTag>())
        {
            var newPos = playerTransform.ValueRO.Position.xy + input.Move * SystemAPI.Time.DeltaTime;
            playerTransform.ValueRW.Position.xy = newPos;
        }
    }
}

