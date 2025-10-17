using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class EntityGizomsDrawer : MonoBehaviour
{
    [SerializeField] private int maxDraw;
    [SerializeField] private Color color;

    public void OnDrawGizmos()
    {
        if(!Application.isPlaying) return;

        var world = World.DefaultGameObjectInjectionWorld;
        if (world == null) return;

        var entityManager = world.EntityManager;
        if (entityManager == null) return;
        var query = entityManager.CreateEntityQuery(typeof(LocalTransform));
        int count = query.CalculateEntityCount();
        if(count == 0) return;

        Gizmos.color = color;
        using (var transforms = query.ToComponentDataArray<LocalTransform>(Allocator.Temp))
        {
            int sample = math.min(maxDraw, transforms.Length);
            int step = math.max(1, transforms.Length / sample);
            int drawn = 0;

            for(int i = 0; i < transforms.Length &&  drawn < sample; i += step)
            {
                var pos = transforms[i].Position;
                Gizmos.DrawWireCube(new Vector3(pos.x, pos.y, pos.z), Vector3.one);
                drawn++;
            }
        }
    }
}
