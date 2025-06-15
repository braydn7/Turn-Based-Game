using System.Collections.Generic;
using UnityEngine;

public class CombatantInstance : MonoBehaviour
{
    public string characterName;
    public Stats stats;
	public CombatClassData combatClassData;
	public TurnState turnState;
    public int currentHP;
    public int currentMana;
    public int currentInitiative = 0;
	public int moveSpeedBonuses = 0;
	public bool isActiveTurn = false;
	public Sprite sprite;
	public Vector3Int gridPos;

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
		turnState = new TurnState(MoveSpeed);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void StartTurn(int moveSpeed)
	{
		turnState.RefreshTurnState(moveSpeed);
		isActiveTurn = true;
	}

	public void EndTurn()
	{
		isActiveTurn = false;
	}

    public int MaxHP => stats.Get(BaseStat.CON);
    public int MaxMana => stats.Get(BaseStat.INT);
    public int InitiativeSpeed => stats.Get(BaseStat.DEX);

	public int MoveSpeed => combatClassData.baseMovementSpeed + moveSpeedBonuses;

    }
