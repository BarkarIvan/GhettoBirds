using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace GhettoBirds.Player.Movement
{
    public partial struct PlayerMovementSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PlayerTag>();
            state.RequireForUpdate<PlayerInput>();
            //state.RequireForUpdate<DroneMovement>();
            //config to future
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            
        }
    }
}