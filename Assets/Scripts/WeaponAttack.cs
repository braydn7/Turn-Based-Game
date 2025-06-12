using UnityEngine;

public class WeaponAttack : ScriptableObject
{
    public string attackName;
	public int baseDamage;
	public int diceMod;
	public int numDice;
	public int statMulti;
	public BaseStat statMod;
	public DamageType damageType;
}
