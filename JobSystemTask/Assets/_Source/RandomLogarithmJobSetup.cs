using System;
using Unity.Jobs;
using UnityEngine;

public class RandomLogarithmJobSetup : MonoBehaviour
{
    [SerializeField] private float interval;
    private float timer = 0f;

    private JobHandle _jobHandle;

    void Update()
    {
        InitJob();
    }

    void LateUpdate()
    {
        _jobHandle.Complete();
    }

    private void InitJob()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;
            var randomLogJob = new RandomLogarithmJob()
            {
                Number = UnityEngine.Random.Range(1, 100)
            };
            _jobHandle = randomLogJob.Schedule();
        }
    }
}
