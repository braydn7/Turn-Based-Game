using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.Tilemaps;

public class Game : MonoBehaviour
{
    private Grid gameGrid;
    private Tilemap playerTileMap;
    private bool isCombat;
    private Combatant player;
    private List<Combatant> npcs;
    private InputSystemUIInputModule inputTracker;
    private bool isTileHighlighted = false;
    private Vector3Int lastHighlightedTile;
    private Color highlightColor = new Color(Color.yellow.r, Color.yellow.g, Color.yellow.b, 0.6f); // Semi-transparent yellow
    private Color defaultColor = new Color(0f, 0f, 0f, .2f);

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the z-coordinate is set to 0

        Vector3Int cellPosition = gameGrid.WorldToCell(mousePosition);
        Debug.Log($"Mouse Position: {mousePosition}, Cell Position: {cellPosition}");

        Tile tile = playerTileMap.GetTile<Tile>(cellPosition);
		
        if (tile != null)
        {
            if(isTileHighlighted && cellPosition != lastHighlightedTile)
            {
                playerTileMap.SetColor(lastHighlightedTile, Color.)
			}
            //Debug.Log($"Tile at {gridPosition} is {tile.name}");
        }
        else
        {
            //Debug.Log($"No tile at {gridPosition}");
		}



	}
}
