using System;
using Unity.Entities;
using UnityEngine;

[Serializable]
public class DroneControllerAuthoring : MonoBehaviour
{
    public float MovementSpeed = 2.5f;
    public float MaxMovementSpeed = 10.0f;
    public float RotationSpeed = 2.5f;

    public bool AffectPhysicsBodies = true;
    
    private class Baker : Baker<DroneControllerAuthoring>
    {
        public override void Bake(DroneControllerAuthoring authoring)
        {
            var droneEntity = GetEntity(authoring.gameObject, TransformUsageFlags.Dynamic);
            AddComponent<PlayerTag>(droneEntity);
          
            //TODO from config
            AddComponent(droneEntity, new DroneControllerComponent
            {
                MovementSpeed =  authoring.MovementSpeed,
                MaxMovementSpeed = authoring.MaxMovementSpeed,
                RotationSpeed = authoring.RotationSpeed,
                AffectPhysicsBodies = authoring.AffectPhysicsBodies
            });
        }
    } 
}

