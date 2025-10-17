using Unity.Entities;
using UnityEngine;

public partial struct MoveSystem : ISystem
{
    public void OnUpdate(ref SystemState systemState)
    {
        float time = (float)SystemAPI.Time.ElapsedTime;
        var moveJob = new MoveJob() { Time = time };
        moveJob.ScheduleParallel();
    }
}
