using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class MapManager : MonoBehaviour
{
	public static MapManager instance;

	[Header("References")]
	public PathFinder pathFinder;
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
		return grid.GetCellCenterWorld(new Vector3Int(gridPosition.x, gridPosition.y, 0));
	}
	public void MoveCombatant(CombatantInstance combatant,  Vector2Int newGridPos)
	{
		
		Vector3 newWorldPos = GetWorldPosition(newGridPos);
		if (combatant.transform.position.x < newWorldPos.x)
		{
			combatant.GetComponent<SpriteRenderer>().flipX = true;
		}
		else
		{
			combatant.GetComponent<SpriteRenderer>().flipX = false;
		}
		combatant.transform.position = newWorldPos;
		combatant.gridPos = newGridPos;
	}

	public IEnumerator MoveAlongPath(CombatantInstance combatant, List<Vector2Int> path, float moveDelay = 0.2f)
	{
		foreach (var step in path)
		{
			MoveCombatant(combatant, step);
			yield return new WaitForSeconds(moveDelay);
		}
	}

	public List<Vector2Int> FindPath(Vector2Int start,  Vector2Int destination)
	{
		var path = new List<Vector2Int>();
		path = pathFinder.FindPath(start, destination);
		return path;
	}
	public bool CanPlaceChar(Vector2Int cellPosition)
	{
		if (!IsCellPassable(cellPosition))
		{
			return false;
		}
		return false;
	}

	public bool IsCellPassable(Vector2Int cellPosition)
	{
		GroundTile tile = getGroundTile(cellPosition);
		if (tile == null)
		{
			// Debug.Log("No ground tile at attempted location");
			return false;
		}
		else if (!tile.isTraversable)
		{
			return false;
		}
		else if (occupiedPositions.ContainsKey(cellPosition))
		{
			return false;
		}
		else
		{
			return true;
		}

	}

	public void addOccupied(Vector2Int occupied)
	{
		if (!occupiedPositions.ContainsKey(occupied))
		{
			occupiedPositions.Add(occupied, true);
		}
	}

	public GroundTile getGroundTile(Vector2Int cellPosition)
	{
		TileBase tileBase = groundTileMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y, 0));
		Tile tile = groundTileMap.GetTile<GroundTile>(new Vector3Int(cellPosition.x, cellPosition.y, 0));
		
		return tileBase as GroundTile;
	}

	/* public GroundTile getWaterTile(Vector2Int cellPosition)
	{
		TileBase tileBase = waterTileMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y, 0));
		return tileBase as GroundTile;
	} */


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
