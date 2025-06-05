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
    private Tilemap playerTileMap;
    private bool isCombat;
    private Combatant player;
    private List<Combatant> npcs;
    private bool isTileHighlighted = false;
    private Vector3Int lastHighlightedTile = Vector3Int.zero;
    private Color highlightColor = new Color(Color.yellow.r, Color.yellow.g, Color.yellow.b, 0.6f); // Semi-transparent yellow
    private Color defaultColor = new Color(0f, 0f, 0f, .2f);
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousev2 = Mouse.current.position.ReadValue(); 
        Vector3 mousePosition = new Vector3(mousev2.x, mousev2.y, 0); // Convert to Vector3 with z = 0

        Vector3Int cellPosition = gameGrid.WorldToCell(mousePosition);
        //Debug.Log($"Mouse Position: {mousePosition}, Cell Position: {cellPosition}");

        TileBase tile = playerTileMap.GetTile<Tile>(cellPosition);
		
        if (tile != null)
        {
            if(isTileHighlighted && cellPosition != lastHighlightedTile)
            {
                playerTileMap.SetColor(lastHighlightedTile, defaultColor);
                isTileHighlighted = false;
			}

            if (!isTileHighlighted)
            {
                playerTileMap.SetColor(cellPosition, highlightColor);
                isTileHighlighted = true;
                lastHighlightedTile = cellPosition;
			}
            Debug.Log($"Tile at {cellPosition} is {tile.name}");
        }
        else
        {
            if(isTileHighlighted)
            {
                playerTileMap.SetColor(lastHighlightedTile, defaultColor);
                isTileHighlighted = false;
			}
			Debug.Log($"No tile at {cellPosition}");
		}



	}
}
