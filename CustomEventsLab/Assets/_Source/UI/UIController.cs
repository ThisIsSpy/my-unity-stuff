using System.Collections;
using System.Collections.Generic;
using UI.Statemachine;
using UnityEngine;

namespace UI
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