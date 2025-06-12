using UnityEngine;
[System.Flags]
public enum CombatClass
{
	None = 0,        // 0000
	Warrior = 1 << 0,   // 0001
	Mage = 1 << 1,   // 0010
	Healer = 1 << 2,   // 0100
	Ranger = 1 << 3,    // 1000
	All = ~0 //1111, shortcut to select all
}