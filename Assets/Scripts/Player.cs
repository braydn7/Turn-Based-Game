using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : Combatant
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    /*
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    */

    public void Move(Vector3Int clickPosition)
    {
        Vector3 centerClickPosition = tilemap.GetCellCenterWorld(clickPosition);
        transform.position = centerClickPosition;
    }
}
