using System.Collections;
using UnityEngine;

public interface ICombatController
{
	IEnumerator TakeTurn(CombatantInstance self);
}
