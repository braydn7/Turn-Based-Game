using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Scriptable Objects/Ability")]
public class Ability : ScriptableObject
{
    string name;
    int cooldown;
    int manaCost;
    CombatClass combatClass;
}
