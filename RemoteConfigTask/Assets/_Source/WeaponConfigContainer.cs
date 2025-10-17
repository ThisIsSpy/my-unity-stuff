using System.Collections.Generic;
using UnityEngine;

public class WeaponConfigContainer
{
    public List<WeaponConfig> WeaponConfigs {  get; private set; }

    public WeaponConfigContainer(List<WeaponConfig> WeaponConfigs)
    {
        this.WeaponConfigs = WeaponConfigs;
    }
}
