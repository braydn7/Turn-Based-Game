using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class MapManager : MonoBehaviour
{
	public static MapManager instance;

	[Header("References")]
	public Grid grid;
	public Tilemap waterTileMap;
	public Tilemap groundTileMap;
	public Tilemap hillTileMap;
	public Tilemap characterTileMap;

	private Dictionary<Vector2Int, bool> occupiedPositions = new Dictionary<Vector2Int, bool>();


	void Awake()
	{
		instance = this;
	}

	public Vector3 GetWorldPosition(Vector2Int gridPosition)
	{
		return grid.CellToWorld((Vector3Int)gridPosition) + grid.cellSize / 2f;
	}
	public void MoveCombatant(CombatantInstance combatant,  Vector2Int newGridPos)
	{
		Vector2Int oldPosition = new Vector2Int();
		combatant.gridPos = oldPosition;
		occupiedPositions.Remove(oldPosition);
		if (occupiedPositions.ContainsKey(newGridPos)) {
			Debug.Log("That tile is occupied!");
			return;
		}
		else {
			Vector3 newWorldPos = GetWorldPosition(newGridPos);
			combatant.transform.position = newWorldPos;
			combatant.gridPos = newGridPos;
			occupiedPositions.Add(newGridPos, true);
		}
			
	}

	public bool CanPlaceChar(Vector2Int cellPosition)
	{
		if (!IsGroundPassable(cellPosition))
		{
			return false;
		}
		return false;
	}

	public bool IsGroundPassable(Vector2Int cellPosition)
	{
		GroundTile tile = getGroundTile(cellPosition);
		if(tile == null){
			Debug.Log("No ground tile at attempted location");
			return false;
		}
		else if (tile.isTraversable)
		{
			return true;
		}
		else
		{
			return false;
		}

	}

	public GroundTile getGroundTile(Vector2Int cellPosition)
	{
		TileBase tileBase = groundTileMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y, 0));
		return tileBase as GroundTile;
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		/*
		int idCounter = 1;
		SpawnCombatant(combatantPrefab, new Vector3Int(2, 3, 0));
		Wait(3f);
		SpawnCombatant(combatantPrefab, new Vector3Int(-2, -3, 0));
		Wait(3f);
		*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private IEnumerator Wait(float seconds)
	{
		yield return new WaitForSeconds(seconds);
	}
}
