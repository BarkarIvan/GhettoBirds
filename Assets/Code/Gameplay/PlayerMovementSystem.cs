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


            //rotation
            var delta = input.TouchDelta * SystemAPI.Time.DeltaTime;
            var yaw = quaternion.EulerXYZ(0, delta.x, 0);
            var pitch = quaternion.EulerXYZ(-delta.y, 0, 0);

            var currentRotation = transform.Rotation;
            var currentYawPitch = new quaternion(currentRotation.value.x,
                currentRotation.value.y, 0,
                currentRotation.value.w);
           
            var newRotation = math.mul(yaw, currentYawPitch);
            newRotation = math.mul(pitch, newRotation);
            
            newRotation = new quaternion(newRotation.value.x,
                newRotation.value.y, currentYawPitch.value.z,
                newRotation.value.w);
            newRotation = math.normalize(newRotation);
            transform.Rotation = newRotation;
        }
    }
}