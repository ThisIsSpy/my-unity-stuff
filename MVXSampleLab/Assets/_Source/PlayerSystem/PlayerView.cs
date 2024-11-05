using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Sprite normalState;
        [SerializeField] private Sprite damagedState;
        [NonSerialized] public TextMeshProUGUI HPText;
        [NonSerialized] public PlayerModel PlayerModel;
        private SpriteRenderer playerSprite;
        private IEnumerator PlayerSpriteChangeCoroutine()
        {
            playerSprite.sprite = damagedState;
            yield return new WaitForSeconds(0.1f);
            playerSprite.sprite = normalState;
        }
        public void BootstrapAwake()
        {
            playerSprite = GetComponent<SpriteRenderer>();
            playerSprite.sprite = normalState;
            DisplayHP();
        }
        public void DisplayHP()
        {
            HPText.text = $"HP: {PlayerModel.HP}";
        }
        public void PlayerSpriteChangeOnHPChange()
        {
            StartCoroutine(PlayerSpriteChangeCoroutine());
        }
        public void PlayerSpriteChangeOnPlayerDeath()
        {
            playerSprite.sprite = damagedState;
        }
    }
}
