using UnityEngine;
using System.Collections;

public class LeaveResultsScene : MonoBehaviour
{
	public void LoadNextWeekendOrProm()
	{
		if (GameState.WeekendsLeft > 0)
			Application.LoadLevel("Choice");
		else
			Application.LoadLevel("End");
	}
}
