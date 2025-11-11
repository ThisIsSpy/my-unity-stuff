using Unity.Entities;
using UnityEngine;

public class MovementBaker : Baker<MovementAuthorization>
{
    public override void Bake(MovementAuthorization authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic | TransformUsageFlags.Renderable);
        AddComponent(entity, new MovementSpeed() { MinValue = authoring.MinMovementSpeed, MaxValue = authoring.MaxMovementSpeed } );
        AddComponent(entity, new RotationSpeed() { MinValue = authoring.MinRotationSpeed, MaxValue = authoring.MaxRotationSpeed });
    }
}