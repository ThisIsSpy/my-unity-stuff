using Leopotam.EcsLite;
using System.Threading;
using UnityEngine;

public class MoveSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();
        var poolMove = world.GetPool<MoveComponent>();
        var poolView = world.GetPool<ViewReference>();
        var filter = world.Filter<MoveComponent>().Inc<ViewReference>().End();

        foreach (var entity in filter)
        {
            ref MoveComponent move = ref poolMove.Get(entity);
            ref ViewReference view = ref poolView.Get(entity);
            Vector3 initPos = view.transform.position;
            float xOffset = Mathf.Sin(Time.deltaTime * move.frequency) * move.amplitude;
            float zPosition = initPos.z + (move.direction * (Time.deltaTime * move.forwardSpeed));
            view.transform.position = new Vector3(initPos.x + xOffset, initPos.y, zPosition);
            move.timer += Time.deltaTime;
            if(move.timer >= move.timerLimit)
            {
                move.direction *= -1;
                move.timer = 0f;
            }
        }
    }
}
