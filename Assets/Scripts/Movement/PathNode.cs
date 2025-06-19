using UnityEngine;

public class PathNode
{
	public Vector2Int position;
	public PathNode parent;
	public int currentPathCost;
	public int heuristicCost;
	public int finalCost => currentPathCost + heuristicCost;

	public PathNode(Vector2Int position)
	{
		this.position = position;
	}

}
