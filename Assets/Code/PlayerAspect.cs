
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

readonly partial struct PlayerAspect : IAspect
{
    public readonly Entity Self;
    private readonly RefRW<LocalTransform> _transform;
    private readonly RefRW<DroneControllerComponent> _droneComponent;
    private readonly RefRW<DroneControllerInternal> _droneInternalComponent;

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

    public PhysicsVelocity Velocity
    {
        get => _droneInternalComponent.ValueRO.Velocity;
        set => _droneInternalComponent.ValueRW.Velocity = value;
    }
    
    
    public float RotationSpeed
    {
        get => _droneComponent.ValueRO.RotationSpeed;
        set => _droneComponent.ValueRW.RotationSpeed = value;
    }
    
}