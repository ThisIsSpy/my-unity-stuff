using Leopotam.EcsLite;
using UnityEngine;

public class CounterSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();
        var pool = world.GetPool<CounterComponent>();
        var filter = world.Filter<CounterComponent>().End();

        foreach (var entity in filter)
        {
            ref var c = ref pool.Get(entity);
            c.Value++;
            Debug.Log(c.Value);
        }
    }
}
