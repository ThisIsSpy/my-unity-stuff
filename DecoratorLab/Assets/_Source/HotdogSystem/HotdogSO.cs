using HotdogSystem.HotdogTypes;
using UnityEngine;

namespace HotdogSystem
{
    [CreateAssetMenu(fileName = "HotdogSO", menuName = "SO/Hotdog SO", order = 1)]
    public class HotdogSO : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Cost { get; private set; }
        [field: SerializeField] public int Mass { get; private set; }
        [field: SerializeField] public HotdogType Type { get; private set; }
    }
    
}
