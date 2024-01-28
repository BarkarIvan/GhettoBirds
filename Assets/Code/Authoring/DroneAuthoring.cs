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
                DefaultSpeed = 5f, //config
                RotationInertiaFactor = 0.2f, //config
                RotationSpeed = 3f, //config
                Inertia =  0,
                Velocity = 0
            });
        }
    } 
}

