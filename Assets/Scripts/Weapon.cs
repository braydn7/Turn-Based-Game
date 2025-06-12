using System.Collections.Generic;
using UnityEngine;

public enum FightingStyle{
    OneHanded,
    TwoHanded
}
public class Weapon : Item
{
	public bool isRanged;
	public FightingStyle style;
    public List<WeaponAttack> attacks;
    public int weaponBonusDamage;

    public List<StatRequirement> statRequirements;
    public List<StatBonus> statBonuses;
}
