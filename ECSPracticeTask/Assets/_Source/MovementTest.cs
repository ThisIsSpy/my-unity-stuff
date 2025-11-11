using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    private float timer = 0f;
    private float timerLimit = 2f;
    Quaternion targetRotation;

    private void Start()
    {
        targetRotation = transform.rotation * Quaternion.AngleAxis(90f, Vector3.up);
    }

    void Update()
    {
        timer += Time.deltaTime * 5;
        Debug.Log(timer);
        if (timer < timerLimit)
        {
            Debug.Log("Check failed");
            return;
        }
        if (true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5);
        }
        float deltaXPos = UnityEngine.Random.Range(-5f, 5f);
        float deltaZPos = UnityEngine.Random.Range(-5f, 5f);
        float3 newPosition = new(transform.position.x + deltaXPos, transform.position.y, transform.position.z + deltaZPos);
        float moveSpeed = UnityEngine.Random.Range(0.3f, 0.7f);
        transform.position = math.lerp(transform.position, newPosition, moveSpeed);
        timer = 0;
    }
}
