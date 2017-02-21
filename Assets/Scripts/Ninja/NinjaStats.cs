using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStats : BaseStatistics
{
    public bool meeleeWeaponEnabled { get; private set; }

    public void MeeleOrDistance()
    {
        meeleeWeaponEnabled = !meeleeWeaponEnabled;
    }
}
