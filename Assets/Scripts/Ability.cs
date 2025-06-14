using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Ability")]
public class Ability : ScriptableObject
{
	public string abilityName;
    public int cooldown;
    public int manaCost;
    public int baseDamage;
    public int diceMod;
    public int numDice;
    public int statBonus;
	public BaseStat statType;
	public DamageType damageType;
    public CombatClass combatClass;
	public AbilityType abilityType;
}
