using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Combatant : MonoBehaviour
{
    public string Name;
	public int Speed;
    public int MaxHP;
    public int CurrentHP;
    public int AttackPower;
    [SerializeField]
    public Game game;
    [SerializeField]
    protected Tilemap tilemap;
    [SerializeField]
    protected Vector3Int currentTilePos;


	public virtual void Initialize(string name, int speed, int maxHP, int attackPower)
	{
		Name = name;
        Speed = speed;
		MaxHP = maxHP;
		CurrentHP = maxHP; // Start with full health
		AttackPower = attackPower;
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        currentTilePos = tilemap.WorldToCell(transform.position);
        transform.position = tilemap.GetCellCenterWorld(currentTilePos);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	// Method to take a turn, can be overridden by subclasses for specific behavior
    public virtual void TakeTurn()
    {

        // Default behavior can be defined here, or overridden in subclasses
        Debug.Log($"{Name} takes their turn.");
	}

	// Method to perform an attack on another combatant
	public virtual void Attack(Combatant target)
    {
        if (IsAlive() && target.IsAlive())
        {
            target.TakeDamage(AttackPower);
            Debug.Log($"{Name} attacks {target.Name} for {AttackPower} damage!");
        }
        else if (!IsAlive())
        {
            Debug.Log($"{Name} cannot attack because they are not alive.");
        }
        else if (!target.IsAlive())
		{
            Debug.Log($"{target.Name} cannot be attacked because they are not alive.");
		}
	}

	// Method to apply damage to the combatant
	public void TakeDamage(int damage)
    {
        CurrentHP -= damage;
        if (CurrentHP < 0)
        {
            CurrentHP = 0;
        }
    }
    // Method to check if the combatant is alive
    public bool IsAlive()
    {
        return CurrentHP > 0;
    }
    // Method to reset the combatant's health
    public void ResetHealth()
    {
        CurrentHP = MaxHP;
	}
}
