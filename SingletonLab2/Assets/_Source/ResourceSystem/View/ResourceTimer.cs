using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Core;

namespace ResourceSystem.View
{
    public class ResourceTimer : MonoBehaviour
    {
        public TextMeshProUGUI TimerText;
        public Game Game;
        private Coroutine cor;

        public IEnumerator TimerTextCoroutine(float time)
        {
            for(float i = time; i >= 0; i--)
            {
                TimerText.text = time.ToString();
                yield return new WaitForSeconds(1);
                time--;
            }
            yield return null;
        }
        public void StartTimer(float time)
        {
            cor = StartCoroutine(TimerTextCoroutine(time));
        }
        public void StopTimer()
        {
            StopCoroutine(cor);
        }
    }
}