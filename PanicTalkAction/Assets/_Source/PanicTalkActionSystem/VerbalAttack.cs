using Cysharp.Threading.Tasks;
using DG.Tweening;
using PanicTalkAction.DebaterSystem;
using UnityEngine;
using UnityEngine.UI;

namespace PanicTalkAction.PanicTalkActionSystem
{
    public class VerbalAttack : MonoBehaviour
    {
        [SerializeField] private Image targetImage;
        private bool isLockedOn;
        public bool IsLockedOn { get { return isLockedOn; } set { isLockedOn = value; targetImage.gameObject.SetActive(isLockedOn); } }
        private Tween storedTween;
        private bool destroyedFlag = false;

        private void Awake()
        {
            AttackAsync().Forget();
        }

        private void OnDestroy()
        {
            destroyedFlag = true;
            storedTween.Kill();
            Debug.Log("destroyed");
        }

        private async UniTask AttackAsync()
        {
            storedTween = transform.DOScale(1.5f, Random.Range(5f, 15f));
            await storedTween.ToUniTask();
            if (destroyedFlag) return;
            PlayerDebater playerDebater = FindFirstObjectByType<PlayerDebater>();
            playerDebater.HP.Value -= 10;
            Debug.Log("damage went through");
            Destroy(gameObject);
        }
    }
}
