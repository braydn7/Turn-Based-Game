using UnityEngine;

public class TurnState
{
    public int remainingMovement;
    public bool actionAvailable;
    public bool bonusActionAvailable;
	// public bool reactionAvailable? (unsure how to implement this properly)

	public TurnState(int moveSpeed)
	{
		remainingMovement = moveSpeed;
		actionAvailable = true;
		bonusActionAvailable = true;
	}

	public void RefreshTurnState(int moveSpeed)
	{
		remainingMovement = moveSpeed;
		actionAvailable = true;
		bonusActionAvailable = true;
	}
}
