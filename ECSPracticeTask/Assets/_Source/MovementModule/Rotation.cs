using UnityEngine;
using Unity.Mathematics;

public static class Rotation
{
    public static quaternion RotateTowards(quaternion from, quaternion to, float maxDegreesDelta)
    {
        float num = Angle(from, to);
        return num < float.Epsilon ? to : math.slerp(from, to, math.min(1f, maxDegreesDelta / num));
    }

    public static float Angle(this quaternion q1, quaternion q2)
    {
        var dot = math.dot(q1, q2);
        return !(dot > 0.999998986721039) ? (float)(math.acos(math.min(math.abs(dot), 1f)) * 2.0) : 0.0f;
    }
}
