using UnityEngine;

public class TurnState
{
	private CombatantInstance combatant;
    public int remainingMovement;
    public bool actionAvailable;
    public bool bonusActionAvailable;
	// public bool reactionAvailable? (unsure how to implement this properly)

	public TurnState(int moveSpeed, CombatantInstance combatant)
	{
		remainingMovement = moveSpeed;
		actionAvailable = true;
		bonusActionAvailable = true;
		this.combatant = combatant;
	}

	public void RefreshTurnState(int moveSpeed)
	{
		remainingMovement = moveSpeed;
		actionAvailable = true;
		bonusActionAvailable = true;
	}

	public void SubtractMovement(int usedMovement)
	{
		remainingMovement -= usedMovement;
		return;
	}

	public void UseAction()
	{
		actionAvailable = false;
	}
}
