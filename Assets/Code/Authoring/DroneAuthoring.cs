using Unity.Entities;
using UnityEngine;

public class DroneAuthoring : MonoBehaviour
{
    //config?
    
    private class Baker : Baker<DroneAuthoring>
    {
        public override void Bake(DroneAuthoring authoring)
        {
            var droneEntity = GetEntity(authoring.gameObject, TransformUsageFlags.Dynamic);
            AddComponent<PlayerTag>(droneEntity);
            //TODO from config
            AddComponent(droneEntity, new DroneComponent
            {
                Sensitivity = 1f,
                MaxSpeed = 5,
                RotationEnertiaFactor = 0.2f,
                RotationResistanceFactor = 0.2f,
                RotationSpeed = 2f,
                Inertia =  0
            });
        }
    } 
}

