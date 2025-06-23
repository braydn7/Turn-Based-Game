using UnityEngine;

public class PathNode
{
	public Vector2Int position;
	public PathNode parent;
	public int currentPathCost;
	public float heuristicCost;
	public float FinalCost => currentPathCost + heuristicCost;

	public PathNode(Vector2Int position)
	{
		this.position = position;
	}

}
