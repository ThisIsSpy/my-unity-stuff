using Unity.Entities;
using UnityEngine;

public class MovementAuthorization : MonoBehaviour
{
    public float MoveSpeed;
    public float Radius;
}

public struct MoveSpeed : IComponentData { public float Value; }

public struct Radius : IComponentData { public float Value; }

public class MovementBaker : Baker<MovementAuthorization>
{
    public override void Bake(MovementAuthorization authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic | TransformUsageFlags.Renderable);
        AddComponent(entity, new MoveSpeed() { Value = authoring.MoveSpeed });
        AddComponent(entity, new Radius() { Value = authoring.Radius });
    }
}
