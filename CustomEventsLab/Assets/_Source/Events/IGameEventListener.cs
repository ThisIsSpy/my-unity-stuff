using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    public interface IGameEventListener
    {
        public List<ObservableSO> Observables { get { return null; } private set { } }
        public void OnEventHappened();
    }
}