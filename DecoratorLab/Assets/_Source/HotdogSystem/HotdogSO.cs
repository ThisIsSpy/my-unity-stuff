using HotdogSystem.HotdogTypes;
using UnityEngine;

namespace HotdogSystem
{
    [CreateAssetMenu(fileName = "HotdogSO", menuName = "SO/Hotdog SO", order = 1)]
    public class HotdogSO : DataSO
    {
        [field: SerializeField] public HotdogType Type { get; private set; }
    }
    
}
