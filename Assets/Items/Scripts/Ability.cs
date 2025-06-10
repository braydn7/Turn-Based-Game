using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Ability")]
public class Ability : ScriptableObject
{
	public string abilityName;
    public int cooldown;
    public int manaCost;
    public CombatClass combatClass;
	public AbilityType abilityType;
}
