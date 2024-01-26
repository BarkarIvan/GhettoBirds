using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class DroneAuthoring : MonoBehaviour
{
    public float Speed;
    //AABB
    
    private class Baker : Baker<DroneAuthoring>
    {
        public override void Bake(DroneAuthoring authoring)
        {
            var droneEntity = GetEntity(authoring.gameObject, TransformUsageFlags.Dynamic);
            AddComponent<PlayerTag>(droneEntity);
            AddComponent<PlayerInput>(droneEntity);
           // AddComponent<LocalTransform>(droneEntity);
        }
    }
}

public struct PlayerTag : IComponentData
{
   
}