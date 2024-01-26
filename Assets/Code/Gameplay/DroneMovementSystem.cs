using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct DroneMovementSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<PlayerTag>();
        state.RequireForUpdate<PlayerInput>();
        //state.RequireForUpdate<DroneMovement>();
        //config to future
    }
    
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
       
        //to future
        //var config = SystemAPI.GetSingleton<Config>();
        
        var input = SystemAPI.GetSingleton<PlayerInput>();
        
        var player = SystemAPI.GetSingletonEntity<PlayerTag>();
        
        var transform = SystemAPI.GetAspect<PlayerAspect>(player);
       
       var newPos = transform.Position + new float3(input.TouchDelta,0) * SystemAPI.Time.DeltaTime;
       transform.Position = newPos;
        
    }
    
}

