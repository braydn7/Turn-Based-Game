using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using JetBrains.Annotations;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Grid gameGrid;
    [SerializeField]
    private Tilemap backgroundTilemap;
	[SerializeField] 
	private Tilemap outlineTilemap;
	[SerializeField]
	private Tilemap foregroundTileMap;
	[SerializeField]
	private Camera mainCamera;

	[SerializeField]
	public Vector3Int currentMouseTilePosition;
	public bool isCombat;
    public Player player;
	public List<Combatant> npcs;
    public bool isTileHighlighted = false;
	public Vector3Int invalidPosition = new Vector3Int(-1, -1, -1);
	public Vector3Int lastHighlightedTile = new Vector3Int(-1, -1, -1); // Initialize to an invalid position
	public Color highlightColor = new Color(Color.blue.r, Color.blue.g, Color.blue.b, 0.8f); 
    public Color defaultColor = new Color(1f, 1f, 1f, 1f);
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		mouseTileTrack();
		HighlightTiles(outlineTilemap);
		if (Mouse.current.leftButton.isPressed)
		{
			if (currentTile(backgroundTilemap) != null)
			{
				player.Move(currentMouseTilePosition);
			}
			else
			{
				Debug.Log("no tile where you clicked!");
			}
		}
		
	}

	public void HighlightTiles(Tilemap tilemap)
	{
		Tile tile = currentTile(tilemap);

		if(!isTileHighlighted || lastHighlightedTile != invalidPosition)
		{
			// If a tile was previously highlighted, reset its color
			if (lastHighlightedTile != invalidPosition)
			{
				tilemap.SetColor(lastHighlightedTile, defaultColor);
				tilemap.SetTileFlags(lastHighlightedTile, TileFlags.LockColor);
			}
			// Highlight the new tile
			if (tile != null)
			{
				tilemap.SetTileFlags(currentMouseTilePosition, TileFlags.None);
				tilemap.SetColor(currentMouseTilePosition, highlightColor);
				lastHighlightedTile = currentMouseTilePosition;
				isTileHighlighted = true;
			}
			else
			{
				isTileHighlighted = false;
				lastHighlightedTile = invalidPosition;
			}
		}
	}

	public Tile currentTile(Tilemap tilemap)
	{
		Tile tile = (Tile)tilemap.GetTile(currentMouseTilePosition);

		// Output the result
		if (tile != null)
		{
			Debug.Log($"Mouse is over tile at grid position: {currentMouseTilePosition}, Tile: {tile.name}");
		}
		else
		{
			Debug.Log($"No tile at grid position: {currentMouseTilePosition}");
		}
		return tile;
	}

	public void mouseTileTrack()
	{
		// Get the mouse position in screen coordinates
		Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
		Debug.Log($"Mouse Screen Position: {mouseScreenPos}");

		// Convert screen position to world position
		Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, gameGrid.transform.position.z - mainCamera.transform.position.z));
		Debug.Log($"Mouse World Position: {mouseWorldPos}");

		// Convert world position to grid cell position
		Vector3Int cellPosition = gameGrid.WorldToCell(mouseWorldPos);
		Debug.Log($"Cell Position: {cellPosition}");

		currentMouseTilePosition = cellPosition;
	}


}
