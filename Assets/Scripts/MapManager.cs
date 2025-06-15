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

	private Dictionary<Vector3Int, bool> occupiedPositions = new Dictionary<Vector3Int, bool>();


	void Awake()
	{
		instance = this;
	}

	public Vector3 GetWorldPosition(Vector2Int gridPosition)
	{
		return grid.CellToWorld((Vector3Int)gridPosition) + grid.cellSize / 2f;
	}


	public void MoveCombatant(GameObject combatant,  Vector3Int newGridPos)
	{
		Vector3 newWorldPos = grid.CellToWorld(newGridPos);
		combatant.transform.position = newWorldPos;
		combatant.GetComponent<CombatantInstance>().gridPos = newGridPos;
	}

	public bool CanPlaceChar(Vector3Int cellPosition)
	{
		if (!IsGroundPassable(cellPosition))
		{
			return false;
		}
		return false;
	}

	public bool IsGroundPassable(Vector3Int cellPosition)
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

	public GroundTile getGroundTile(Vector3Int cellPosition)
	{
		TileBase tileBase = groundTileMap.GetTile(cellPosition);
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
