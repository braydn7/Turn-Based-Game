using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

	[SerializeField]
	private MapManager mapManager;

	public PathFinder (MapManager mapManager)
	{
		this.mapManager = mapManager;
	}
	public List<Vector2Int> FindPath(Vector2Int start, Vector2Int target)
	{
		List<PathNode> openSet = new List<PathNode>();
		HashSet<Vector2Int> closedSet = new HashSet<Vector2Int>();
		Dictionary<Vector2Int, PathNode> allNodes = new Dictionary<Vector2Int, PathNode>();

		PathNode startNode = new PathNode(start);
		startNode.currentPathCost = 0;
		startNode.heuristicCost = Heuristic(start, target);
		openSet.Add(startNode);
		allNodes[start] = startNode;

		while (openSet.Count > 0)
		{
			openSet.Sort((a, b) => a.finalCost.CompareTo(b.finalCost));
			var current = openSet[0];
			openSet.RemoveAt(0);
			closedSet.Add(current.position);

			if(current.position == target)
			{
				Debug.Log($"Full path found. Reconstructing Path");
				return ReconstructPath(current);
			}

			foreach (var neighborPos in GetNeighbors(current.position))
			{
				if (closedSet.Contains(neighborPos)) continue;
				if (neighborPos != start && !mapManager.IsCellPassable(neighborPos)) continue;

				int tentativeG = current.currentPathCost + 1;
				PathNode neighborNode;
				if (!allNodes.TryGetValue(neighborPos, out neighborNode))
				{
					neighborNode = new PathNode(neighborPos);
					allNodes[neighborPos] = neighborNode;
				}

				if (tentativeG < neighborNode.currentPathCost || !openSet.Contains(neighborNode))
				{
					neighborNode.currentPathCost = tentativeG;
					neighborNode.heuristicCost = Heuristic(neighborPos, target);
					neighborNode.parent = current;

					if (!openSet.Contains(neighborNode))
					{
						openSet.Add(neighborNode);
					}
				}

			}
		}

		return null; // No path found

	}

	private List<Vector2Int> ReconstructPath(PathNode node)
	{
		var path = new List<Vector2Int>();
		while (node != null)
		{
			path.Add(node.position);
			node = node.parent;
		}
		path.Reverse();
		Debug.Log($"Path created, path length = {path.Count}");
		return path;
	}


	private int Heuristic(Vector2Int a, Vector2Int b)
	{
		int dx = a.x - b.x;
		int dy = a.y - b.y;
		return Mathf.Max(Mathf.Abs(dx), Mathf.Abs(dy), Mathf.Abs(-dx - dy));
	}

	private static readonly Vector2Int[] HexDirections = new Vector2Int[]
{
	new Vector2Int( 1,  0), // East
    new Vector2Int( 1, -1), // South-East
    new Vector2Int( 0, -1), // South-West
    new Vector2Int(-1,  0), // West
    new Vector2Int(-1,  1), // North-West
    new Vector2Int( 0,  1), // North-East
};

	private List<Vector2Int> GetNeighbors(Vector2Int pos)
	{
		List<Vector2Int> neighbors = new List<Vector2Int>();
		foreach (var dir in HexDirections)
		{
			neighbors.Add(pos + dir);
		}
		return neighbors;
	}


}
