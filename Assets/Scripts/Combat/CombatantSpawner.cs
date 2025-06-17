using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CombatantSpawner : MonoBehaviour
{
	public static CombatantSpawner instance;
	public CombatManager combatManager;
	public MapManager mapManager;
	public List<CombatantInstance> combatantPrefabs;

	private int idCounter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SpawnCombatant(CombatantTemplate combatantTemplate, Vector2Int gridPos)
	{
		Vector3 worldPos = mapManager.GetWorldPosition(gridPos);
		CombatantInstance warriorPrefab = combatantPrefabs[0];
		CombatantInstance newCombatant = CombatantInstance.Instantiate(warriorPrefab, worldPos, Quaternion.identity);
		newCombatant.Initialize(combatantTemplate);
		newCombatant.transform.parent = mapManager.characterTileMap.transform; //I think this just keeps things organized in Inspector
		newCombatant.gridPos = gridPos;
		newCombatant.mapManager = mapManager;
		combatManager.addCombatantToCombat(newCombatant);
		mapManager.MoveCombatant(newCombatant, gridPos);
		return;
	}




}
