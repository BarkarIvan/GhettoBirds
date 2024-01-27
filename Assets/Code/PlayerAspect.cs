
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

readonly partial struct PlayerAspect : IAspect
{
    public readonly Entity Self;
    private readonly RefRW<LocalTransform> _transform;
    private readonly RefRW<DroneComponent> _droneComponent;

    public float3 Position
    {
        get => _transform.ValueRO.Position;
        set => _transform.ValueRW.Position = value;
    }

    public quaternion Rotation
    {
        get => _transform.ValueRO.Rotation;
        set => _transform.ValueRW.Rotation = value;
    }

    public float3 RotationVelocity
    {
        get => _droneComponent.ValueRO.RotationVelocity;
        set => _droneComponent.ValueRW.RotationVelocity = value;
    }
    
    
    public float RotationSpeed
    {
        get => _droneComponent.ValueRO.RotationSpeed;
        set => _droneComponent.ValueRW.RotationSpeed = value;
    }
    
    public float RotationInertiaFactor
    {
        get => _droneComponent.ValueRO.RotationEnertiaFactor;
        set => _droneComponent.ValueRW.RotationEnertiaFactor = value;
    }
    
    public float RotationResistance
    {
        get => _droneComponent.ValueRO.RotationResistanceFactor;
        set => _droneComponent.ValueRW.RotationResistanceFactor = value;
    }
    
    public float MaxSpeed
    {
        get => _droneComponent.ValueRO.MaxSpeed;
        set => _droneComponent.ValueRW.MaxSpeed = value;
    }
    
    public float Sensitivity
    {
        get => _droneComponent.ValueRO.Sensitivity;
        set => _droneComponent.ValueRW.Sensitivity = value;
    }
    
    public float3 Inertia
    {
        get => _droneComponent.ValueRO.Inertia;
        set => _droneComponent.ValueRW.Inertia = value;
    }
    
}