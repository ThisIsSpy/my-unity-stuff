using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    
    public interface IServiceLocator
    {
        public bool GetService<T>(out T service);
    }
    
}
