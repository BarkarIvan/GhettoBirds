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
            //to future
            //var config = SystemAPI.GetSingleton<Config>();

            var input = SystemAPI.GetSingleton<PlayerInput>();
            if (!input.Accelerate) return;
            
            var playerTag = SystemAPI.GetSingletonEntity<PlayerTag>();

            var player = SystemAPI.GetAspect<PlayerAspect>(playerTag);

            var dt = SystemAPI.Time.DeltaTime;
            var delta = input.TouchDelta;
            
            delta *= player.RotationSpeed;
            
            //rotation
            float3 currentInertia = player.Inertia; 
            var inertiaFactor = player.RotationInertiaFactor;
            currentInertia.x = Mathf.Lerp(currentInertia.x, delta.x, inertiaFactor);
            currentInertia.y = Mathf.Lerp(currentInertia.y, -delta.y, inertiaFactor);
            player.Inertia = currentInertia;

            var yaw = quaternion.EulerXYZ(0, currentInertia.x, 0);
            var pitch = quaternion.EulerXYZ(currentInertia.y, 0, 0);

            var currentRotation = player.Rotation;
            var newRotation = math.mul(currentRotation, yaw);
            newRotation = math.mul(newRotation, pitch);
            newRotation = math.normalize(newRotation);
            
            player.Rotation = math.slerp(math.normalize(currentRotation), math.normalize(newRotation),  dt);
           
            player.Position += player.Forward * player.DefaultSpeed * dt;
        }
    }
}