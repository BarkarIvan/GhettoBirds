using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.VisualScripting;
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

            var player = SystemAPI.GetSingletonEntity<PlayerTag>();

            var transform = SystemAPI.GetAspect<PlayerAspect>(player);

            var dt = SystemAPI.Time.DeltaTime;
            var delta = input.TouchDelta;
            
            if (math.lengthsq(delta) > 0.0001f) // Используем квадрат длины для проверки, чтобы избежать квадратного корня
            {
                delta = math.normalize(delta) * transform.RotationSpeed;
            }
            else
            {
                delta = float2.zero;
            }
          
            //rotation
            float3 currentInertia = transform.Inertia; 
            var inertiaFactor = transform.RotationInertiaFactor;
            currentInertia.x = Mathf.Lerp(currentInertia.x, delta.x, inertiaFactor);
            currentInertia.y = Mathf.Lerp(currentInertia.y, -delta.y, inertiaFactor);
            transform.Inertia = currentInertia;

            var yaw = quaternion.EulerXYZ(0, currentInertia.x, 0);
            var pitch = quaternion.EulerXYZ(currentInertia.y, 0, 0);

            var currentRotation = transform.Rotation;
            var newRotation = math.mul(currentRotation, yaw);
            newRotation = math.mul(newRotation, pitch);
            newRotation = math.normalize(newRotation);
            
            transform.Rotation = math.slerp(math.normalize(currentRotation), math.normalize(newRotation),  dt);
        }
    }
}