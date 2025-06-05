using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Grid gameGrid;
    [SerializeField]
    private Tilemap tilemap;
    private bool isCombat;
    private Combatant player;
    private List<Combatant> npcs;
    private bool isTileHighlighted = false;
    private Vector3Int lastHighlightedTile = Vector3Int.zero;
    private Color highlightColor = new Color(Color.yellow.r, Color.yellow.g, Color.yellow.b, 0.6f); // Semi-transparent yellow
    private Color defaultColor = new Color(0f, 0f, 0f, .2f);
	[SerializeField] private Camera mainCamera;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		// Get the mouse position in screen coordinates
		Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
		Debug.Log($"Mouse Screen Position: {mouseScreenPos}");

		// Convert screen position to world position
		Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, tilemap.transform.position.z - mainCamera.transform.position.z));
		Debug.Log($"Mouse World Position: {mouseWorldPos}");

		// Convert world position to Tilemap cell position
		Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);
		Debug.Log($"Cell Position: {cellPosition}");

		// Check if there's a tile at the cell position
		TileBase tile = tilemap.GetTile(cellPosition);

		// Output the result
		if (tile != null)
		{
			Debug.Log($"Mouse is over tile at grid position: {cellPosition}, Tile: {tile.name}");
		}
		else
		{
			Debug.Log($"No tile at grid position: {cellPosition}");
		}

		// Additional debug: Check if any tiles exist in the Tilemap
		BoundsInt bounds = tilemap.cellBounds;
		Debug.Log($"Tilemap Bounds: {bounds}");
		TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
		int tileCount = 0;
		foreach (TileBase t in allTiles)
		{
			if (t != null) tileCount++;
		}
		Debug.Log($"Total tiles in Tilemap: {tileCount}");
	}
}
