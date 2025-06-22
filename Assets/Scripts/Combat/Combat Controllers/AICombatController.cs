using System.Collections;
using UnityEngine;

public class AICombatController : ICombatController
{	public IEnumerator TakeTurn(CombatantInstance self)
	{
		self.StartTurn();
		return null;
	}

}
