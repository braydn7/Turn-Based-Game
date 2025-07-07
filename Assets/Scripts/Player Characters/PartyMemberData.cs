using System.Collections.Generic;
using UnityEngine;

public class PartyMemberData
{
	public string characterName;
	public int level;
	public CombatClassData combatClassData;
	public Sprite sprite;
	public List<Ability> abilities;
	public List<Item> inventory;
	public List<DamageType> typeResistances;
	public List<DamageType> typeWeaknesses;
	public Stats stats;
}
