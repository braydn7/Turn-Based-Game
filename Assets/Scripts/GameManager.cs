using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	int numCombatants = 5;
	public CombatManager combatManager;
	public CombatantTemplate combatantTemplate;
	public CombatantSpawner combatantSpawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		SpawnCharacters();
		Debug.Log("Made it to StartCombat");
		combatManager.StartCombat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SpawnCharacters()
	{
		for (int i = 0; i < numCombatants; i++) 
		{
			combatantSpawner.SpawnCombatant(combatantTemplate, new Vector2Int(Random.Range(-4, 4), Random.Range(-4, 4)));
		}
		return;
	}
}