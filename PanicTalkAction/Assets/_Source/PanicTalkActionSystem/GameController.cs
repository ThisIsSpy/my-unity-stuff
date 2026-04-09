using Cysharp.Threading.Tasks;
using PanicTalkAction.DebaterSystem;
using R3;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace PanicTalkAction.PanicTalkActionSystem
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private PlayableDirector playableDirector;
        [SerializeField] private PlayerDebater playerDebater;
        [SerializeField] private EnemyDebater enemyDebater;
        [SerializeField] private TextMeshProUGUI countdownDisplayer;
        [SerializeField] private List<Sprite> cutinAnimationImages;
        [SerializeField] private GameObject cutinObject, whiteScreen, realScreen; 
        [SerializeField] private ScreenExplosion shatterScreen;
        [SerializeField] private Image cutin;
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioClip wooshClip, breakClip, thisShouldProveItClip;

        private void Start()
        {
            enemyDebater.HP.Where(x => x <= 0).Subscribe(OnPlayerWin).AddTo(this);
            StartingCountdownAsync().Forget();
        }

        private async UniTask StartingCountdownAsync()
        {
            countdownDisplayer.text = "3";
            await UniTask.WaitForSeconds(1);
            countdownDisplayer.text = "2";
            await UniTask.WaitForSeconds(1);
            countdownDisplayer.text = "1";
            await UniTask.WaitForSeconds(1);
            countdownDisplayer.text = "Start!";
            await UniTask.WaitForSeconds(0.5f);
            countdownDisplayer.gameObject.SetActive(false);
            enemyDebater.Construct();
            playerDebater.Construct();
            playableDirector.Play();
        }

        private void OnPlayerWin(int _) => OnPlayerWinAsync().Forget();

        private async UniTask OnPlayerWinAsync()
        {
            playableDirector.Stop();
            playerDebater.Stop();
            enemyDebater.Stop();
            whiteScreen.SetActive(true);
            await UniTask.WaitForSeconds(0.075f);
            whiteScreen.SetActive(false);
            cutinObject.SetActive(true);
            sfxSource.PlayOneShot(wooshClip);
            sfxSource.PlayOneShot(thisShouldProveItClip);
            cutin.sprite = cutinAnimationImages[0];
            await UniTask.WaitForSeconds(0.175f);
            cutin.sprite = cutinAnimationImages[1];
            await UniTask.WaitForSeconds(0.175f);
            cutin.sprite = cutinAnimationImages[2];
            await UniTask.WaitForSeconds(0.45f);
            sfxSource.PlayOneShot(breakClip);
            whiteScreen.SetActive(true);
            await UniTask.WaitForSeconds(0.075f);
            cutinObject.SetActive(false);
            whiteScreen.SetActive(false);
            enemyDebater.AcceptDefeat();
            realScreen.SetActive(false);
            shatterScreen.gameObject.SetActive(true);
        }
    }
}
