using UnityEngine;

public class AbilityManager
{
    public static int CalculateDamage(CombatantInstance attacker, CombatantInstance defender, Ability ability)
    {
        int damage = 0;
        int rollTotal = 0;
        for (int i = 0; i < ability.numDice; i++) {
            rollTotal += Random.Range(1, ability.diceMod);
        }
        int statBonus = attacker.stats.Get(ability.statType) * ability.statBonus;
        damage += rollTotal + statBonus + ability.baseDamage;
        if (defender.typeResistances.Contains(ability.damageType) && !defender.typeWeaknesses.Contains(ability.damageType))
        {
            damage = damage / 2;
        }
        else if (defender.typeWeaknesses.Contains(ability.damageType) && !defender.typeResistances.Contains(ability.damageType))
        {
            damage = damage * 2;
        }
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
