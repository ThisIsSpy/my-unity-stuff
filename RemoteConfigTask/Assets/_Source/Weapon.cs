using UnityEngine;

public class Weapon
{
    public string ID { get; private set; }
    public int Damage { get; private set; }
    public float Cooldown { get; private set; }

    public Weapon(WeaponConfig config)
    {
        ID = config.ID;
        Damage = config.Damage;
        Cooldown = config.Cooldown;
    }

    public void DebugWeapon()
    {
        Debug.Log($"ID = {ID}; Damage = {Damage}; Cooldown = {Cooldown}");
    }
}
