using UnityEngine;

public class CombatantInstance : MonoBehaviour
{
    public Stats baseStats;

    int currentHP;

    public void Initialize(CombatantTemplate combatantTemplate)
    {
        baseStats = combatantTemplate.stats;
        currentHP = MaxHP;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int MaxHP => baseStats.CON * 2;
}
