using Unity.Entities;
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
            AddComponent<DroneTag>(droneEntity);
            AddComponent<PlayerInput>(droneEntity);
        }
    }
}

public struct DroneTag : IComponentData
{ }