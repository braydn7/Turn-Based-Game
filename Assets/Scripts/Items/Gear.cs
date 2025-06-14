using System.Collections.Generic;
using UnityEngine;

public enum GearSlot
{
    Head,
    Chest,
    Legs,
    Hands,
    Feet,
    Neck,
    Ring,
    MainHand,
    Offhand
}
public class Gear : Item
{
    public GearSlot gearSlot;
    public List<CombatClass> wearableClasses;

    public List<StatRequirement> statRequirements;
    public List<StatBonus> statBonuses;
}
