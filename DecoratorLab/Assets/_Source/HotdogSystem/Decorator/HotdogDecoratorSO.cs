using UnityEngine;
using HotdogSystem.Decorator.DecoratorTypes;

namespace HotdogSystem.Decorator
{
    [CreateAssetMenu(fileName = "HotdogDecoratorSO", menuName = "SO/Hotdog Decorator SO", order = 1)]
    public class HotdogDecoratorSO : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Cost { get; private set; }
        [field: SerializeField] public int Mass { get; private set; }
        [field: SerializeField] public DecoratorType Type { get; private set; }
    }
    
}
