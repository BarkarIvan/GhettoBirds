using Unity.Entities;
using Unity.Mathematics;

public struct DroneComponent : IComponentData
{
    public float3 Inertia;
    public float DefaultSpeed;
    public float3 Velocity;
    public float RotationSpeed;
    public float RotationInertiaFactor;
}
