using UnityEngine;
[System.Flags]
public enum AbilityType
{
    Damage = 0,
    Heal = 1 << 0,
    Buff = 1 << 1,
    Debuff = 1 << 2,
    All = ~0
}
