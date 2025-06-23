using UnityEngine;

public class AbilityManager
{
    public static int CalculateDamage(CombatantInstance attacker, CombatantInstance defender, Ability ability)
    {
        int damage = 0;
		int currentRoll;
        int rollTotal = 0;
		Debug.Log($"Calculating {attacker.characterName}'s {ability.abilityName} damage onto {defender.characterName}");
        for (int i = 0; i < ability.numDice; i++) {
			currentRoll = Random.Range(1, ability.diceMod);
            rollTotal += Random.Range(1, ability.diceMod);
			Debug.Log($"Rolling D {ability.diceMod}");
			Debug.Log($"Result: {currentRoll}");
        }
		Debug.Log("Dice Total: " + rollTotal);

        int statBonus = attacker.stats.Get(ability.statType) * ability.statBonus;
		Debug.Log($"Adding {ability.statType} time {statBonus} as Stat Bonus");
        damage += rollTotal + statBonus + ability.baseDamage;
		Debug.Log("Total before Weaknesses/Resistances");
        if (defender.typeResistances.Contains(ability.damageType) && !defender.typeWeaknesses.Contains(ability.damageType))
        {
			Debug.Log($"{defender.characterName} is resistant to {ability.damageType}! Halving damage");
            damage = damage / 2;
			Debug.Log($"New damage total: {damage}");

		}
        else if (defender.typeWeaknesses.Contains(ability.damageType) && !defender.typeResistances.Contains(ability.damageType))
        {
			Debug.Log($"{defender.characterName} is weak to {ability.damageType}! Doubling damage");
			damage = damage * 2;
			Debug.Log($"New damage total: {damage}");
        }
		Debug.Log($"Final damage total: {damage}");
        return damage;
    }

    public bool EnoughMana(CombatantInstance attacker, Ability ability)
    {
        if(attacker.currentMana - ability.manaCost >= 0)
        {
            return true;
        }
        else
        {
            Debug.Log(attacker.name + " does not have enough mana to cast " + ability.name);
			return false;
		}
    }
}
