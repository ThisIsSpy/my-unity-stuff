using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class MovementJobSetup : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int objectCount;
    [SerializeField] private float movementRadius;
    [SerializeField] private float speed;

    private TransformAccessArray _transformAccessArray;
    private JobHandle _jobHandle;

    void Awake()
    {
        Setup();
    }

    void Update()
    {
        InitJob();
    }

    void LateUpdate()
    {
        _jobHandle.Complete();
    }

    void OnDestroy()
    {
        _transformAccessArray.Dispose();
    }

    private void Setup()
    {
        _transformAccessArray = new TransformAccessArray(objectCount);

        for(int i = 0; i < objectCount; i++)
        {
            var instance = Instantiate(prefab, UnityEngine.Random.insideUnitSphere * movementRadius, Quaternion.identity);
            _transformAccessArray.Add(instance.transform);
        }
    }

    private void InitJob()
    {
        var moveJob = new MoveJob()
        {
            Time = Time.deltaTime,
            Radius = movementRadius,
            Speed = speed,
        };

        _jobHandle = moveJob.Schedule(_transformAccessArray);
    }
}
