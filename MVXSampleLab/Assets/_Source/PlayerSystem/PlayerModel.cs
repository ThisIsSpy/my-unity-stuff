using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerModel
    {
        private int _hp;
        private int _maxHp;
        public static event System.Action OnHealthChange;
        public static event System.Action OnPlayerDeath;

        public PlayerModel(int maxHp)
        {
            _maxHp = maxHp;
            _hp = _maxHp;
        }
        public int HP
        {
            get
            {
                return _hp;
            }
            set
            {
                if (value > 0)
                {
                    OnHealthChange?.Invoke();
                    _hp = value;
                }
                if(value <= 0)
                {
                    OnPlayerDeath?.Invoke();
                    _hp = 0;
                }
                
            }
        }
    }
}
