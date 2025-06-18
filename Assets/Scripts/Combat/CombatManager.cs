using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

public class CombatManager : MonoBehaviour
{
	private List<CombatantInstance> activeCombatants = new();
    private Queue<CombatantInstance> turnQueue = new Queue<CombatantInstance>();
    private int initiativeThreshold = 100;
	public CombatantSpawner spawner;

	void Start()
	{
	}
    public void StartCombat()
    {
		Debug.Log("Attempting to start CombatLoop");
		StartCoroutine(CombatLoop());
    }

	private IEnumerator CombatLoop()
	{
		while (true)
		{
			Debug.Log("Attempting to perform CombatTick");
			CombatTick();

			while (turnQueue.Count > 0)
			{
				CombatantInstance combatant = turnQueue.Dequeue();
				yield return StartCoroutine(combatant.TakeTurn());
			}

			yield return null;
		}
	}

    public void CombatTick()
    {
		Debug.Log("CombatTick forloop");
        foreach (CombatantInstance c in activeCombatants)
        {
			c.currentInitiative += c.InitiativeSpeed;
        }

        activeCombatants = activeCombatants.OrderByDescending(c => c.currentInitiative).ToList();

        while (activeCombatants[0].currentInitiative >= initiativeThreshold)
        {
            var actingCombatant = activeCombatants[0];
            actingCombatant.currentInitiative -= initiativeThreshold;
            turnQueue.Enqueue(actingCombatant);
        }
    }

	public void addCombatantToCombat(CombatantInstance combatant)
	{
		activeCombatants.Add(combatant);
		return;
	}
}
