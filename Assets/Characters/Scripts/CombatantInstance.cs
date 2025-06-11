using UnityEngine;

public class CombatantInstance : MonoBehaviour
{
    public CombatantTemplate template;

    public int maxHP;
    public int currentHP;
    public Stats startingStats;


    public void Initialize(CombatantTemplate combatantTemplate)
    {
        template = combatantTemplate;
		maxHP = template.stats.Get(Stats.BaseStat.CON);
		currentHP = maxHP;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
