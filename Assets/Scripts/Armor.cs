using System.Collections.Generic;
using UnityEngine;

public enum ArmorSlot
{
    Head,
    Chest,
    Legs,
    Hands,
    Feet,
    Neck,
    Ring
}
public class Armor
{
    public ArmorSlot armorSlot;
    public List<CombatClass> wearableClasses;

    public List<StatRequirement> statRequirements;
    public List<StatBonus> statBonuses;
}
