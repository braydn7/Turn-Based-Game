using System;
using UnityEngine;

[Serializable]
public class Stats
{
	public enum BaseStat
	{
		STR, DEX, INT, CON, WIS, CHA
	}

	[SerializeField] private int str;
	[SerializeField] private int dex;
	[SerializeField] private int @int;
	[SerializeField] private int con;
	[SerializeField] private int wis;
	[SerializeField] private int cha;

	public int Get(BaseStat stat)
	{
		return stat switch
		{
			BaseStat.STR => str,
			BaseStat.DEX => dex,
			BaseStat.INT => @int,
			BaseStat.CON => con,
			BaseStat.WIS => wis,
			BaseStat.CHA => cha,
			_ => 0
		};
	}

	public void Set(BaseStat stat, int value)
	{
		switch (stat)
		{
			case BaseStat.STR: str = value; break;
			case BaseStat.DEX: dex = value; break;
			case BaseStat.INT: @int = value; break;
			case BaseStat.CON: con = value; break;
			case BaseStat.WIS: wis = value; break;
			case BaseStat.CHA: cha = value; break;
		}
	}
}
