using Unity.Entities;
using Unity.Mathematics;
 
public struct PlayerInput : IComponentData
{
    public float2 Move;
    public float2 TouchDelta;
    public int Accelerate;
}