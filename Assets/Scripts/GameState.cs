using System;
using System.Linq;
using UnityEngine;
using Assets.Scripts;
using System.Collections.Generic;
using Random = System.Random;

//using Random = UnityEngine.Random;

// ReSharper disable once CheckNamespace
public class GameState : MonoBehaviour
{
    public List<AudioClip> OneShots = new List<AudioClip>();
    public List<AudioClip> Ambience = new List<AudioClip>();
    public List<Sprite> Backgrounds = new List<Sprite>(); 

    public static WeekendEvent ChosenEvent { get; set; }
    public static List<WeekendEvent> WeekendEvents { get; set; }
    private static readonly Queue<WeekendEvent> Choices = new Queue<WeekendEvent>(4); 

	public static int WeekendsLeft = 10;

    public static int PrepFollowers { get; set; }
    public static int NerdFollowers { get; set; }
    public static int JockFollowers { get; set; }
    public static int EmoFollowers { get; set; }
    public static int DramaFollowers { get; set; }
    public static int BandFollowers { get; set; }
    public static int StonerFollowers { get; set; }
    public static int ArtistFollowers { get; set; }


    // ReSharper disable once UnusedMember.Local
    private void Start()
    {
        LoadWeekendEvents();
    }

    // ReSharper disable once UnusedMember.Local
    private void OnLevelWasLoaded(int level)
    {
        const int choiceScene = 2;
        const int doScene = 3;

        switch (level)
        {
            case choiceScene:
                ChoiceScene();
                break;
            case doScene:
                DoScene();
                break;
        }
    }

    private static void ChoiceScene()
    {
        Shuffle(WeekendEvents);

        var chosenEvents = WeekendEvents.Take(4);
        foreach (var @event in chosenEvents)
        {
            Choices.Enqueue(@event);
        }
    }

    public static void Shuffle<T>(IList<T> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            var k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
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
        return Choices.Dequeue();
    }



    private void LoadWeekendEvents()
    {
        WeekendEvents = new List<WeekendEvent>
        {
			new WeekendEvent
			{
				ChoiceText = "Head on over to the water park.",
				EventNarrative = "Other than your nerd friend almost drowning, your time at the water park made quite the splash!",
				ResultNarrative = "Water park results...",
				PrepFollowersChange = 0,
				NerdFollowersChange = 0,
				JockFollowersChange = 0,
				EmoFollowersChange = 0,
				DramaFollowersChange = 0,
				BandFollowersChange = 0,
				StonerFollowersChange = 0,
				ArtistFollowersChange = 0,
                OneShot = "waterpark-oneshot",
                Ambience = "waterpark-ambience",
                Background = ""
			},
            new WeekendEvent
			{
				ChoiceText = "Plan a picnic",
				EventNarrative = "You and your friends had quite the enjoyable time at the picnic. Nothing could ruin the glorious day. The sun was shining. The sky was blue. Fun was had.",
				ResultNarrative = "Picnic results...",
				PrepFollowersChange = 0,
				NerdFollowersChange = 0,
				JockFollowersChange = 0,
				EmoFollowersChange = 0,
				DramaFollowersChange = 0,
				BandFollowersChange = 0,
				StonerFollowersChange = 0,
				ArtistFollowersChange = 0,
                OneShot = "picnic-dogbark-oneshot",
                Ambience = "picnic-ambience",
                Background = "picnic"
			},
			new WeekendEvent
			{
				ChoiceText = "Your friend's parents are going out of town. Time for a house party!",
				EventNarrative = "Went to house party!",
				ResultNarrative = "House party results...",
				PrepFollowersChange = 0,
				NerdFollowersChange = 0,
				JockFollowersChange = 0,
				EmoFollowersChange = 0,
				DramaFollowersChange = 0,
				BandFollowersChange = 0,
				StonerFollowersChange = 0,
				ArtistFollowersChange = 0,
                //OneShot = "-oneshot",
                //Ambience = "-ambience",
                //Background = ""
			},
			new WeekendEvent
			{
				ChoiceText = "There is a football game this weekend.",
				EventNarrative = "You watched the game. Hung out with your friends. Made some new ones. What more could you ask for?",
				ResultNarrative = "Football game results...",
				PrepFollowersChange = 10,
				NerdFollowersChange = -10,
				JockFollowersChange = 0,
				EmoFollowersChange = 0,
				DramaFollowersChange = 0,
				BandFollowersChange = 0,
				StonerFollowersChange = 0,
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
				PrepFollowersChange = 0.5f,
				NerdFollowersChange = 0,
				JockFollowersChange = 0,
				EmoFollowersChange = 0,
				DramaFollowersChange = 0,
				BandFollowersChange = 0,
				StonerFollowersChange = 0,
				ArtistFollowersChange = 0,
                //OneShot = "-oneshot",
                //Ambience = "-ambience",
                //Background = ""
			},
		};
    }
}
