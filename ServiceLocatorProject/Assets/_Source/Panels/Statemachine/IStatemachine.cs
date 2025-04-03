using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Panels.Statemachine
{
    public interface IStatemachine
    {
        bool ChangeState<T>() where T : UIController;
    }   
}