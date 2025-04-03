using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Services
{

    public class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, object> services;

        public ServiceLocator(FadeService fadeService, SoundPlayer soundPlayer, PlayerPrefsSaver playerPrefsSaver, JSONSaver jsonSaver)
        {
            services = new()
            {
                {typeof(FadeService), fadeService },
                {typeof(SoundPlayer), soundPlayer },
                {typeof(PlayerPrefsSaver), playerPrefsSaver },
                {typeof(JSONSaver), jsonSaver },
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

        //public T GetService<T>()
        //{
        //    if (!services.TryGetValue(typeof(T), out object objService))
        //        throw new KeyNotFoundException("death");
        //    return (T)objService;
        //}
    }

}
