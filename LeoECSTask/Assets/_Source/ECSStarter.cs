using Leopotam.EcsLite;
using UnityEngine;

public class ECSStarter : MonoBehaviour
{
    [SerializeField] private int ballStartingCount = 1000;
    [SerializeField] private Vector3 startingSpawnPos = Vector3.zero;
    [SerializeField] private GameObject prefab;
    [SerializeField] private float startingForwardSpeed;
    [SerializeField] private float startingAmplitude;
    [SerializeField] private float startingFrequency;
    [SerializeField] private float startingTimerLimit;
    private EcsWorld _world;
    private EcsSystems _systems;

    void Start()
    {
        _world = new();
        _systems = new(_world);
        _systems
            .Add(new CounterSystem())
            .Add(new MoveSystem());
        _systems.Init();

        var counterEntity = CreateCounterEntity();
        for(int i = 0; i < ballStartingCount; i++)
        {
            CreateMoveEntity();
        }
    }

    void Update()
    {
        _systems?.Run();
    }

    void OnDestroy()
    {
        _systems?.Destroy();
        _world?.Destroy();
    }

    private int CreateCounterEntity()
    {
        var entity = _world.NewEntity();
        var pool = _world.GetPool<CounterComponent>();
        ref var c = ref pool.Add(entity);
        //c.Value = 0;
        return entity;
    }

    private void CreateMoveEntity()
    {
        GameObject ball = Instantiate(prefab, startingSpawnPos, Quaternion.identity);
        var entity = _world.NewEntity();
        var poolMove = _world.GetPool<MoveComponent>();
        var poolView = _world.GetPool<ViewReference>();
        ref var move = ref poolMove.Add(entity);
        ref var view = ref poolView.Add(entity);
        move.forwardSpeed = startingForwardSpeed;
        move.amplitude = startingAmplitude;
        move.frequency = startingFrequency;
        move.direction = 1;
        move.timer = 0f;
        move.timerLimit = startingTimerLimit;
        view.transform = ball.transform;
        startingSpawnPos.x += 3;
    }
}