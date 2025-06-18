using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatantInstance : MonoBehaviour
{
    public int currentInitiative = 0;
	public int moveSpeedBonuses = 0;
	public bool isActiveTurn = false;

	/* Assigned in the template */
	public string characterName;
	public int level;
	public CombatClassData combatClassData;
	public Sprite sprite;
	public List<Ability> abilities;
	public List<Item> inventory;
	public List<DamageType> typeResistances;
	public List<DamageType> typeWeaknesses;
	public Stats stats;

	/* Assigned in constructor */
	public TurnState turnState;
	public int currentHP;
	public int currentMana;

	/* Assigned in Inspector  */
	

	/* Assigned in CombatantSpawner */
	public MapManager mapManager;

	/* Assigned by GameManager */
	public Vector2Int gridPos;

	public void Initialize(CombatantTemplate combatantTemplate)
    {
        characterName = combatantTemplate.Name;
		stats = new Stats(combatantTemplate.stats);
		abilities = combatantTemplate.abilities;
		inventory = combatantTemplate.inventory;
		sprite = combatantTemplate.sprite;
		combatClassData = combatantTemplate.combatClassData;
		currentHP = MaxHP;
		currentMana = MaxMana;
		turnState = new TurnState(MoveSpeed, this);
		this.GetComponent<SpriteRenderer>().sprite = sprite;
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

	public IEnumerator TakeTurn()
	{
		yield return new WaitForSeconds(2f);
		Debug.Log($"{characterName} is taking their turn.");
		StartTurn(MoveSpeed);
		bool wantMove = true;
		bool wantAction = true;
		//bool wantBonusAction = true;
		Ability ability = abilities.Find(a => a.abilityName == "Fireball");
		int wantedMovement = 5;
		Vector2Int destination = new Vector2Int(Random.Range(-3, 3), Random.Range(-3, 3));
		if (wantMove)
		{
			if (turnState.remainingMovement >= wantedMovement)
			{
				mapManager.MoveCombatant(this, destination);
				turnState.SubtractMovement(wantedMovement);
				Debug.Log($"{characterName} should have moved");
				yield return new WaitForSeconds(.5f); 
			}
			else
			{
				Debug.Log("Not enough movement");

			}
		}
		
		if (wantAction)
		{
			if(!turnState.actionAvailable)
		{
				Debug.Log($"{characterName} has no more actions available!");
			}
			else
			{
				Debug.Log($"{characterName} casts {ability.abilityName}");
				turnState.UseAction();
			}

		}

		EndTurn();

		yield return null;
		/*if (wantBonusAction)
		{

		}
		return null; */
	}

	public void EndTurn()
	{
		isActiveTurn = false;
	}

	public void UseAction(Ability ability)
	{
		if (ability.costType == AbilityCostType.Action)
		{
			
		}
	}

    public int MaxHP => stats.Get(BaseStat.CON);
    public int MaxMana => stats.Get(BaseStat.INT);
    public int InitiativeSpeed => stats.Get(BaseStat.DEX);

	public int MoveSpeed => combatClassData.baseMovementSpeed + moveSpeedBonuses;

    }
