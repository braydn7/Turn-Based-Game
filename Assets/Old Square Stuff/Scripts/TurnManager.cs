using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// Method to manage the turn order of combatants
    public void ManageTurnOrder(Combatant[] combatants)
    {
		List<Combatant> turnOrder = getTurnOrder(combatants);
        foreach (Combatant currentCombatant in turnOrder)
        {
            if (currentCombatant.IsAlive())
            {
                // currentCombatant.takeTurn();
            }
        }
	}

    private List<Combatant> getTurnOrder(Combatant[] combatants)
    {
        List<Combatant> turnOrder = new List<Combatant>(combatants);
        turnOrder.Sort((a, b) => b.Speed.CompareTo(a.Speed)); // Sort by Speed in descending order
		return turnOrder;
	}
}
