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
	public Stats (Stats other)
	{
		other.Initialize(); //Make sure other is up to date
		statDict = new Dictionary<BaseStat, int>();

		foreach (var entry in other.statEntries)
		{
			statDict[entry.stat] = entry.value;
		}
		// statDict = new Dictionary<BaseStat, int>(other.statDict);
	}
	[System.Serializable]
	public class StatEntry
	{
		public BaseStat stat;
		public int value;
	}

	[SerializeField]
	private List<StatEntry> statEntries = new(); //Exists for serialization, needs to be copied over to dictionary

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
		if (statDict.TryGetValue(stat, out var value))
			return value;

		Debug.LogWarning($"Stat {stat} not found in statDict!");
		return 0;
	}

	public void Set(BaseStat stat, int value)
	{

		statDict[stat] = value;

	}
}