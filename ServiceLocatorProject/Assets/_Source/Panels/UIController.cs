using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panels.Statemachine;

namespace Panels
{
    public abstract class UIController
    {
        protected IStatemachine switcher;

        public void InjectOwner(IStatemachine owner)
        {
            switcher = owner;
        }

        public abstract void Enter();
        public abstract void Exit();
    }
}