using ResourceSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ResourceSystem.Data;
using Core;
using System.Runtime.CompilerServices;

namespace ResourceSystem.View
{
    public class ResourceButton : MonoBehaviour
    {
        public ResourceType Type;
        public Game Game;
        public Button Button;
        public float ActiveTime;
        public float InactiveTime;
        public ResourceTimer Timer;
        [SerializeField] private Image resourceIcon;
        public Coroutine cor;

        private IEnumerator HalfLifeTimerCoroutine()
        {
            ResourceViewService.Instance.SetActiveIcon(resourceIcon, Type);
            Timer.StartTimer(ActiveTime);
            yield return new WaitForSeconds(ActiveTime);
            Game.GameOver();
        }
        private IEnumerator InactiveTimerCoroutine()
        {
            ResourceViewService.Instance.SetInactiveIcon(resourceIcon, Type);
            Timer.StartTimer(InactiveTime);
            Button.interactable = false;
            yield return new WaitForSeconds(InactiveTime);
            Button.interactable = true;
            StartHalfLife();
        }
        public void StartHalfLife()
        {
            cor = StartCoroutine(HalfLifeTimerCoroutine());
        }
        public void StopHalfLife()
        {
            StopCoroutine(cor);
            StartCoroutine(InactiveTimerCoroutine());
        }
    }
}