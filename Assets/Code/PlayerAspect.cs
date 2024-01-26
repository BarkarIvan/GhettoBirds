
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

readonly partial struct PlayerAspect : IAspect
{
    public readonly Entity Self;
    private readonly RefRW<LocalTransform> Transform;

    public float3 Position
    {
        get => Transform.ValueRO.Position;
        set => Transform.ValueRW.Position = value;
    }

    public quaternion Rotation
    {
        get => Transform.ValueRO.Rotation;
        set => Transform.ValueRW.Rotation = value;
    }

   // public float3 Speed
    //{
        //get form comp
  //  }
    
}