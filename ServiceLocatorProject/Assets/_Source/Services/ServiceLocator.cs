using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Services
{

    public class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, object> services;

        public ServiceLocator(IFadeService fadeService, ISoundPlayer soundPlayer, ISaver saver)
        {
            services = new()
            {
                {typeof(IFadeService), fadeService },
                {typeof(ISoundPlayer), soundPlayer },
                {typeof(ISaver), saver },
            };
        }

        public bool GetService<T>(out T service)
        {
            service = default;
            if (!services.TryGetValue(typeof(T), out object objService)) { Debug.Log($"something went wrong, {service}"); return false; }
            else
            {
                service = (T)objService;
                return true;
            }
        }
    }

}
