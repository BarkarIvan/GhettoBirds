using Unity.Entities;
using Unity.Physics;
using Unity.Physics.GraphicsIntegration;

public struct DroneControllerComponent : IComponentData
{
    public float MovementSpeed;
    public float MaxMovementSpeed;
    public float RotationSpeed;

    public bool AffectPhysicsBodies;
}

[WriteGroup(typeof(PhysicsGraphicalInterpolationBuffer))]
[WriteGroup(typeof(PhysicsGraphicalSmoothing))]
public struct DroneControllerInternal : IComponentData
{
    public PhysicsVelocity Velocity;
    public Entity Entity;
    
}
