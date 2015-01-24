﻿using System.Linq;
using UnityEngine;
using Assets.Scripts;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
public class GameState : MonoBehaviour
{
    public List<AudioClip> OneShots = new List<AudioClip>();
    public List<AudioClip> Ambience = new List<AudioClip>();

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

    // ReSharper disable once UnusedMember.Local
    private void Start()
    {
        LoadWeekendEvents();
    }

    // ReSharper disable once UnusedMember.Local
    private void OnLevelWasLoaded(int level)
    {
        if (level == 3)
        {
            var audioSources = GetComponents<AudioSource>();

            var oneshot = OneShots.FirstOrDefault(x => x.name == ChosenEvent.OneShot);
            var ambience = Ambience.FirstOrDefault(x => x.name == ChosenEvent.Ambience);

            if (oneshot != null)
            {
                audioSources[0].PlayOneShot(oneshot);
            }
            if (ambience != null)
            {
                audioSources[1].clip = ambience;
                audioSources[1].Play();
            }
        }
    }

    private void LoadWeekendEvents()
    {
        WeekendEvents = new List<WeekendEvent>
        {
			new WeekendEvent
			{
				ChoiceText = "Water Park",
				EventNarrative = "Went to water park!",
				ResultNarrative = "Water park results...",
				PrepFollowersChange = 0,
				NerdFollowersChange = 0,
				JockFollowersChange = 0,
				EmoFollowersChange = 0,
				DramaFollowersChange = 0,
				BandFollowersChange = 0,
				StonerPreFollowersChange = 0,
				ArtistFollowersChange = 0,
			},
			new WeekendEvent
			{
				ChoiceText = "House party",
				EventNarrative = "Went to house party!",
				ResultNarrative = "House party results...",
				PrepFollowersChange = 0,
				NerdFollowersChange = 0,
				JockFollowersChange = 0,
				EmoFollowersChange = 0,
				DramaFollowersChange = 0,
				BandFollowersChange = 0,
				StonerPreFollowersChange = 0,
				ArtistFollowersChange = 0,
			},
			new WeekendEvent
			{
				ChoiceText = "Football Game",
				EventNarrative = "Went to football game!",
				ResultNarrative = "Football game results...",
				PrepFollowersChange = 0,
				NerdFollowersChange = 0,
				JockFollowersChange = 0,
				EmoFollowersChange = 0,
				DramaFollowersChange = 0,
				BandFollowersChange = 0,
				StonerPreFollowersChange = 0,
				ArtistFollowersChange = 0,
                OneShot = "football-oneshot",
                Ambience = "football-ambience",
			},
			new WeekendEvent
			{
				ChoiceText = "LAN Party",
				EventNarrative = "Went to LAN party!",
				ResultNarrative = "LAN party results...",
				PrepFollowersChange = 0,
				NerdFollowersChange = 0,
				JockFollowersChange = 0,
				EmoFollowersChange = 0,
				DramaFollowersChange = 0,
				BandFollowersChange = 0,
				StonerPreFollowersChange = 0,
				ArtistFollowersChange = 0,
			},
		};
    }
}
