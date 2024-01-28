using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace GhettoBirds.Entities.Gameplay
{

    [UpdateAfter(typeof(TransformSystemGroup))]
    public partial class UpdateCameraTargetSystem : SystemBase
    {
        private Transform _cameraTarget;
        
        protected override void OnCreate()
        { 
            RequireForUpdate<PlayerTag>();
        }

        protected override void OnStartRunning()
        {
            //TODO какая-то шляпа
            _cameraTarget = GameObject.FindWithTag("CameraTarget").transform;
            base.OnStartRunning();
        }

        protected override void OnUpdate()
        {
            var player = SystemAPI.GetSingletonEntity<PlayerTag>();
            var playerAspect = SystemAPI.GetAspect<PlayerAspect>(player);
            _cameraTarget.position = playerAspect.Position;
            _cameraTarget.rotation = playerAspect.Rotation;
        }
    }
}
