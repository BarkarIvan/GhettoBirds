
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


    public float3 Forward => _transform.ValueRO.Forward();

    public quaternion Rotation
    {
        get => _transform.ValueRO.Rotation;
        set => _transform.ValueRW.Rotation = value;
    }

    public float3 Velocity
    {
        get => _droneComponent.ValueRO.Velocity;
        set => _droneComponent.ValueRW.Velocity = value;
    }
    
    
    public float RotationSpeed
    {
        get => _droneComponent.ValueRO.RotationSpeed;
        set => _droneComponent.ValueRW.RotationSpeed = value;
    }
    
    public float RotationInertiaFactor
    {
        get => _droneComponent.ValueRO.RotationInertiaFactor;
        set => _droneComponent.ValueRW.RotationInertiaFactor = value;
    }
    
    
    public float DefaultSpeed
    {
        get => _droneComponent.ValueRO.DefaultSpeed;
        set => _droneComponent.ValueRW.DefaultSpeed = value;
    }
    
  
    public float3 Inertia
    {
        get => _droneComponent.ValueRO.Inertia;
        set => _droneComponent.ValueRW.Inertia = value;
    }
    
}