using System.Collections.Generic;
using UnityEngine;

public class CombatantInstance : MonoBehaviour
{
    public string characterName;
    public Stats stats;
    public int currentHP;
    public int currentMana;
    public int currentInitiative = 0;

    public List<DamageType> typeResistances;
    public List<DamageType> typeWeaknesses;
    public List<Item> inventory;

    public void Initialize(CombatantTemplate combatantTemplate)
    {
        characterName = combatantTemplate.Name;
        stats = combatantTemplate.stats;
        currentHP = MaxHP;
        currentMana = MaxMana;
        inventory = combatantTemplate.inventory;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int MaxHP => stats.Get(BaseStat.CON);
    public int MaxMana => stats.Get(BaseStat.INT);
    public int Speed => stats.Get(BaseStat.DEX);

    }
