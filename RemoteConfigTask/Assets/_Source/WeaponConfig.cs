using System;
using UnityEngine;

[Serializable]
public class WeaponConfig
{
    public string ID { get; private set; }
    public int Damage { get; private set; }
    public float Cooldown {  get; private set; }

    public WeaponConfig(string iD, int damage, float cooldown)
    {
        ID = iD;
        Damage = damage;
        Cooldown = cooldown;

        if (Damage <= 0) Damage = 1;
        if (Cooldown < 0) Cooldown = 0;
    }
}
