using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable Objects/CombatantTemplate")]

public class CombatantTemplate : ScriptableObject
{
    public string Name;
    public int level;
   
	public Sprite sprite;
	public List<Ability> abilities;
    public List<Item> inventory;
    public Stats stats;
}
