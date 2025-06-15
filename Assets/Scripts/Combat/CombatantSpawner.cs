using UnityEngine;
using UnityEngine.Tilemaps;

public class CombatantSpawner : MonoBehaviour
{
	public static CombatantSpawner instance;
	public CombatManager combatManager;
	public MapManager mapManager;

	[Header("References")]
	public GameObject combatantPrefab;

	private int idCounter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public GameObject SpawnCombatant(GameObject prefab, Vector3Int gridPos)
	{
		Vector3 worldPos = mapManager.grid.CellToWorld(gridPos);
		GameObject newCombatant = Instantiate(prefab, worldPos, Quaternion.identity);
		newCombatant.transform.parent = mapManager.characterTileMap.transform; //I think this just keeps things organized in Inspector

		var instance = newCombatant.GetComponent<CombatantInstance>();
		instance.gridPos = gridPos;

		return newCombatant;
	}




}
