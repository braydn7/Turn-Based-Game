using System.Collections.Generic;
using UnityEngine;

public enum BaseStat
{
	STR,
	DEX,
	CON,
	INT,
	WIS,
	CHA
}

[System.Serializable]
public class Stats
{
	[System.Serializable]
	public class StatEntry
	{
		public BaseStat stat;
		public int value;
	}

	[SerializeField]
	private List<StatEntry> statEntries = new(); // Only for runtime start/inspector stuff. Ignore after start of game

	private Dictionary<BaseStat, int> statDict;

	public void Initialize()
	{
		statDict = new Dictionary<BaseStat, int>();

		// Populate from the serialized list
		foreach (var entry in statEntries)
		{
			statDict[entry.stat] = entry.value;
		}
	}

	public int Get(BaseStat stat)
	{

		return statDict[stat];
	}

	public void Set(BaseStat stat, int value)
	{

		statDict[stat] = value;

	}
}