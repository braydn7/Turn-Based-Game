using UnityEngine;

public enum AbilityCostType
{
	Action,
	BonusAction
}
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
	public AbilityCostType costType;
	public BaseStat statType;
	public DamageType damageType;
    public CombatClass combatClass;
	public AbilityType abilityType;
}
