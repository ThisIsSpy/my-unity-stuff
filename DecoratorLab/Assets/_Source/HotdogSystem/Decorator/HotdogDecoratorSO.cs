using UnityEngine;
using HotdogSystem.Decorator.DecoratorTypes;

namespace HotdogSystem.Decorator
{
    [CreateAssetMenu(fileName = "HotdogDecoratorSO", menuName = "SO/Hotdog Decorator SO", order = 1)]
    public class HotdogDecoratorSO : DataSO
    {
        [field: SerializeField] public DecoratorType Type { get; private set; }
    }
    
}
