using Unity.Jobs;
using UnityEngine;

public struct RandomLogarithmJob : IJob
{
    public float Number;
    public void Execute()
    {
        Debug.Log($"Logarithm of {Number} is {Mathf.Log(Number)}");
    }
}
