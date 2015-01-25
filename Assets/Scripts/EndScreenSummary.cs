using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScreenSummary : MonoBehaviour {
	public int TwoStarFollowerCount= 10;
	public int ThreeStarFollowerCount = 20;

	// Use this for initialization
	void Start () {
		var text = GetComponent<Text>();

		var count = FollowerCount();

		if (count == 0)
			text.text = "Ugh! Having not even a single friend as Prom begins, you can't bring yourself to even leave your room.";
		else if (count < TwoStarFollowerCount)
			text.text = string.Format("Well, your entourage is only {0} other people, but at least Prom is sortof fun. You guess.", FollowerCount());
		else if (count < ThreeStarFollowerCount)
			text.text = string.Format("Prom is awesome. You were hoping for a bit more than the {0} people you came with, but still - good times!", FollowerCount());
		else
			text.text = string.Format("A crown on your head before you even open the doors, you roll in to prom {0} deep. Helllll yeah!", FollowerCount());
	}

	private int FollowerCount()
	{
		return GameState.StonerFollowers +
			GameState.PrepFollowers +
			GameState.NerdFollowers +
			GameState.JockFollowers +
			GameState.EmoFollowers +
			GameState.DramaFollowers +
			GameState.BandFollowers +
			GameState.ArtistFollowers;
	}
	
	
}
