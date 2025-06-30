using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

	/* Assigned in Awake */
	SpriteRenderer renderer;

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
    }

	public void Awake()
	{
		renderer = this.AddComponent<SpriteRenderer>();
		renderer.sprite = sprite;
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



	public void StartTurn()
	{
		turnState.RefreshTurnState(MoveSpeed);
		isActiveTurn = true;
	}
	public IEnumerator TakeTurn()
	{
		yield return new WaitForSeconds(2f);
		Debug.Log($"{characterName} is taking their turn.");
		StartTurn();

		
		bool wantMove = true;
		bool wantAction = true;
		//bool wantBonusAction = true;
		Ability ability = abilities.Find(a => a.abilityName == "Fireball");
		


		if (wantMove)
		{
			Debug.Log("Attempting to move");
			var path = new List<Vector2Int>();
			Vector2Int destination = new Vector2Int(8, 0);
			path = mapManager.FindPath(gridPos, destination);
			if (path != null)
			{
				int wantedMovement = path.Count - 1;
				if (turnState.remainingMovement >= wantedMovement)
				{
					mapManager.StartCoroutine(mapManager.MoveAlongPath(this, path));
					mapManager.addOccupied(destination);
					turnState.SubtractMovement(wantedMovement);
					Debug.Log($"{characterName} should have moved");
					yield return new WaitForSeconds(.2f);
				}
				else
				{
					Debug.Log("Not enough movement");

				}
			}
			else
			{
				Debug.Log("No valid path found)");
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

	public int MoveSpeed => 9999; //combatClassData.baseMovementSpeed + moveSpeedBonuses;

    }
