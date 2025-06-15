using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CombatManager : MonoBehaviour
{
    private List<CombatantInstance> activeCombatants = new();
    public Queue<CombatantInstance> turnQueue = new Queue<CombatantInstance>();
    public int initiativeThreshold = 100;
	public CombatantSpawner spawner;

	void Start()
	{
	}
    public void StartCombat(List<CombatantInstance> combatants)
    {
        activeCombatants = new List<CombatantInstance>(combatants);

    }

	public void SpawnCombatants()
	{
	}
    public void CombatTick()
    {
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
}
