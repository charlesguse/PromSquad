using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;
using System;

public class GameState : MonoBehaviour {

	public static WeekendEvent ChosenEvent { get; set; }
	public static List<WeekendEvent> WeekendEvents { get; set; }

	public int PrepFollowers { get; set; }
	public int NerdFollowers { get; set; }
	public int JockFollowers { get; set; }
	public int EmoFollowers { get; set; }
	public int DramaFollowers { get; set; }
	public int BandFollowers { get; set; }
	public int StonerPreFollowers { get; set; }
	public int ArtistFollowers { get; set; }

	// Use this for initialization
	void Start () {
		LoadWeekendEvents();
	}

	private void LoadWeekendEvents()
	{
		
	}
}
