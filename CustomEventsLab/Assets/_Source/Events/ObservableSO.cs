using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "ObservableSO", menuName = "SO/New Observable SO", order = 0)]
    public class ObservableSO : ScriptableObject
    {
        [SerializeField] private List<IGameEventListener> listeners = new();

        public void RegisterObserver(IGameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void RemoveObserver(IGameEventListener listener)
        {
            listeners.Remove(listener);
        }

        public void Notify()
        {
            foreach (var listener in listeners)
            {
                listener.OnEventHappened();
            }
        }
    }
}