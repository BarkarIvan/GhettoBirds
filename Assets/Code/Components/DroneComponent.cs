using Unity.Entities;
using Unity.Mathematics;

public struct DroneComponent : IComponentData
{
    public float3 Inertia;
    public float Sensitivity;
    public float MaxSpeed;
    public float RotationSpeed;
    public float RotationEnertiaFactor;
    public float RotationResistanceFactor;
    public float3 RotationVelocity;
}
