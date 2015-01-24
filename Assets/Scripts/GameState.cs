using System;
using System.Linq;
using UnityEngine;
using Assets.Scripts;
using System.Collections.Generic;
using Random = UnityEngine.Random;

// ReSharper disable once CheckNamespace
public class GameState : MonoBehaviour
{
    public List<AudioClip> OneShots = new List<AudioClip>();
    public List<AudioClip> Ambience = new List<AudioClip>();
    public List<Sprite> Backgrounds = new List<Sprite>(); 

    public static WeekendEvent ChosenEvent { get; set; }
    public static List<WeekendEvent> WeekendEvents { get; set; }
    private static readonly Queue<WeekendEvent> choices = new Queue<WeekendEvent>(4); 

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
        const int ChoiceScene = 2;
        const int DoScene = 3;

        switch (level)
        {
            case ChoiceScene:
                GameState.ChoiceScene();
                break;
            case DoScene:
                this.DoScene();
                break;
        }
    }

    private static void ChoiceScene()
    {
        var availableEvents = WeekendEvents.OrderBy(x => Random.Range(int.MinValue, int.MaxValue)).Select(x => x).ToList();

        foreach (var @event in availableEvents)
        {
            choices.Enqueue(@event);
        }
    }

    private void DoScene()
    {
        var audioSources = GetComponents<AudioSource>();
        var spriteRenderer = GameObject.Find("Background").GetComponent<SpriteRenderer>();

        var oneshot =
            OneShots.FirstOrDefault(
                x => String.Equals(x.name, ChosenEvent.OneShot, StringComparison.CurrentCultureIgnoreCase));
        var ambience =
            Ambience.FirstOrDefault(
                x => String.Equals(x.name, ChosenEvent.Ambience, StringComparison.CurrentCultureIgnoreCase));
        var background =
            Backgrounds.FirstOrDefault(
                x => String.Equals(x.name, ChosenEvent.Background, StringComparison.CurrentCultureIgnoreCase));

        if (oneshot != null)
        {
            audioSources[0].PlayOneShot(oneshot);
        }
        if (ambience != null)
        {
            audioSources[1].clip = ambience;
            audioSources[1].Play();
        }
        if (background != null)
        {
            spriteRenderer.sprite = background;
        }
    }

    public static WeekendEvent ChooseRandomWeekendEvent()
    {
        return choices.Dequeue();
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
                Background = "football"
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
