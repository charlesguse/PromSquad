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
        const int titleScene = 0;
        const int choiceScene = 2;
        const int doScene = 3;

        switch (level)
        {
            case titleScene:
                TitleScene();
                break;
            case choiceScene:
                ChoiceScene();
                break;
            case doScene:
                DoScene();
                break;
        }
    }

    private void TitleScene()
    {
        WeekendsLeft = 10;
        PrepFollowers = 0;
        NerdFollowers = 0;
        JockFollowers = 0;
        EmoFollowers = 0;
        DramaFollowers = 0;
        BandFollowers = 0;
        StonerFollowers = 0;
        ArtistFollowers = 0;
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

    private const int LargeIncrease = 6;
    private const int MediumIncrease = 3;
    private const int SmallIncrease = 1;
    private const int SmallDecrease = -1;
    private const int MediumDecrease = -3;
    private const float LargeDecrease = .5f;


    private void LoadWeekendEvents()
    {
        WeekendEvents = new List<WeekendEvent>
        {
			new WeekendEvent
			{
				ChoiceText = "Night-time pool party? Yes please.",
				EventNarrative = "Other than your nerd friend drowning, your time in the pool " +
				                 "made quite the splash!",
				PrepFollowersChange = LargeIncrease,
				NerdFollowersChange = SmallDecrease,
				JockFollowersChange = MediumIncrease,
				EmoFollowersChange = SmallIncrease,
				DramaFollowersChange = SmallIncrease,
				BandFollowersChange = SmallIncrease,
				StonerFollowersChange = SmallIncrease,
				ArtistFollowersChange = SmallIncrease,
                OneShot = "poolparty-oneshot",
                Ambience = "poolparty-ambience",
                Background = "pool"
			},
			new WeekendEvent
			{
				ChoiceText = "Your friend's parents are going out of town. Time for a house party!",
				EventNarrative = "The party was a complete success! Um, aside from all the " +
				                 "family pictures that suddenly went missing...",
				PrepFollowersChange = MediumIncrease,
				NerdFollowersChange = LargeDecrease,
				JockFollowersChange = LargeIncrease,
				EmoFollowersChange = MediumDecrease,
				DramaFollowersChange = SmallIncrease,
				BandFollowersChange = MediumDecrease,
				StonerFollowersChange = SmallIncrease,
				ArtistFollowersChange = MediumDecrease,
                OneShot = "houseparty-oneshot",
                Ambience = "houseparty-ambience",
                //Background = "houseparty"
			},
            new WeekendEvent
			{
				ChoiceText = "Nice weather for a picnic.",
				EventNarrative = "You and your friends had a lovely time at the picnic. " +
				                 "Nothing could ruin such a glorious day. The sky was blue. " +
				                 "The sun was shining. The ants were merciful.",
				PrepFollowersChange = LargeDecrease,
				NerdFollowersChange = MediumIncrease,
				JockFollowersChange = LargeDecrease,
				EmoFollowersChange = SmallDecrease,
				DramaFollowersChange = SmallIncrease,
				BandFollowersChange = MediumIncrease,
				StonerFollowersChange = SmallIncrease,
				ArtistFollowersChange = LargeIncrease,
                OneShot = "picnic-dogbark-oneshot",
                Ambience = "picnic-ambience",
                Background = "picnic"
			},
			new WeekendEvent
			{
				ChoiceText = "There is a football game this weekend.",
				EventNarrative = "You watched the game, hung out with your friends, and made " +
				                 "some new ones. What more could you ask for?",
				PrepFollowersChange = MediumIncrease,
				NerdFollowersChange = MediumDecrease,
				JockFollowersChange = LargeIncrease,
				EmoFollowersChange = LargeDecrease,
				DramaFollowersChange = MediumDecrease,
				BandFollowersChange = LargeIncrease,
				StonerFollowersChange = LargeDecrease,
				ArtistFollowersChange = LargeDecrease,
                OneShot = "football-oneshot",
                Ambience = "football-ambience",
                Background = "football"
			},
			new WeekendEvent
			{
				ChoiceText = "Play some CS:GO, some HOTS, and maybe some Civ5 if you're feeling squirrelly.",
				EventNarrative = "Do you even know what you just chose? Are you really " +
				                 "going to prom in a few weeks?",
				PrepFollowersChange = LargeDecrease,
				NerdFollowersChange = LargeIncrease,
				JockFollowersChange = LargeDecrease,
				EmoFollowersChange = SmallIncrease,
				DramaFollowersChange = SmallDecrease,
				BandFollowersChange = SmallDecrease,
				StonerFollowersChange = MediumIncrease,
				ArtistFollowersChange = SmallDecrease,
                OneShot = "lanparty-oneshot",
                Ambience = "lanparty-ambience",
                //Background = ""
			},
            new WeekendEvent
			{
				ChoiceText = "Stay home",
				EventNarrative = "You had a quiet night watching horror movies about jello.",
				PrepFollowersChange = LargeDecrease,
				NerdFollowersChange = MediumIncrease,
				JockFollowersChange = LargeDecrease,
				EmoFollowersChange = LargeIncrease,
				DramaFollowersChange = LargeIncrease,
				BandFollowersChange = SmallDecrease,
				StonerFollowersChange = LargeIncrease,
				ArtistFollowersChange = MediumIncrease,
                //OneShot = "-oneshot",
                Ambience = "stayhome-ambience",
                Background = "Choice"
			},
            new WeekendEvent
			{
				ChoiceText = "Go to the library",
				EventNarrative = "You and your more intellectual friends had a great time learning " +
				                 "about everything from dire wolves to dragons.",
				PrepFollowersChange = LargeDecrease,
				NerdFollowersChange = LargeIncrease,
				JockFollowersChange = LargeDecrease,
				EmoFollowersChange = MediumIncrease,
				DramaFollowersChange = SmallIncrease,
				BandFollowersChange = SmallIncrease,
				StonerFollowersChange = SmallDecrease,
				ArtistFollowersChange = MediumIncrease,
                OneShot = "library-oneshot",
                Ambience = "library-ambience",
                //Background = "library"
			},
		};
    }
}
