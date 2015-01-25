using UnityEngine;
using UnityEngine.UI;
using System;

// ReSharper disable once CheckNamespace
public class UpdateResults : MonoBehaviour
{
    public Text Preps;
    public Text Jocks;
    public Text Nerds;
    public Text Drama;
    public Text Band;
    public Text Emos;
    public Text Stoners;
    public Text Artists;

    // ReSharper disable once UnusedMember.Local
    private void Start()
    {
        var chosenEvent = GameState.ChosenEvent;

        GameState.PrepFollowers = UpdateFollowerCount(GameState.PrepFollowers, chosenEvent.PrepFollowersChange);
        GameState.JockFollowers = UpdateFollowerCount(GameState.JockFollowers, chosenEvent.JockFollowersChange);
        GameState.NerdFollowers = UpdateFollowerCount(GameState.NerdFollowers, chosenEvent.NerdFollowersChange);
        GameState.DramaFollowers = UpdateFollowerCount(GameState.DramaFollowers, chosenEvent.DramaFollowersChange);
        GameState.BandFollowers = UpdateFollowerCount(GameState.BandFollowers, chosenEvent.BandFollowersChange);
        GameState.EmoFollowers = UpdateFollowerCount(GameState.EmoFollowers, chosenEvent.EmoFollowersChange);
        GameState.ArtistFollowers = UpdateFollowerCount(GameState.ArtistFollowers, chosenEvent.ArtistFollowersChange);
        GameState.StonerFollowers = UpdateFollowerCount(GameState.StonerFollowers, chosenEvent.StonerFollowersChange);

        Preps.text = "Preps: " + BuildResultText(GameState.PrepFollowers, chosenEvent.PrepFollowersChange);
        Jocks.text = "Jocks: " + BuildResultText(GameState.JockFollowers, chosenEvent.JockFollowersChange);
        Artists.text = "Artists: " + BuildResultText(GameState.ArtistFollowers, chosenEvent.ArtistFollowersChange);
        Emos.text = "Emos: " + BuildResultText(GameState.EmoFollowers, chosenEvent.EmoFollowersChange);
        Nerds.text = "Nerds: " + BuildResultText(GameState.NerdFollowers, chosenEvent.NerdFollowersChange);
        Drama.text = "Drama: " + BuildResultText(GameState.DramaFollowers, chosenEvent.DramaFollowersChange);
        Band.text = "Band: " + BuildResultText(GameState.BandFollowers, chosenEvent.BandFollowersChange);
        Stoners.text = "Stoners: " + BuildResultText(GameState.StonerFollowers, chosenEvent.StonerFollowersChange);
    }

    private int UpdateFollowerCount(int currentCount, float change)
    {
        if (IsFractional(change))
            return (int)Math.Round(currentCount * change);
        return Math.Max(currentCount + (int)change, 0);
    }

    private bool IsFractional(float p)
    {
        return (p > 0 && p < 1);
    }

    private string BuildResultText(int totalFollowers, float followersChange)
    {
        int change;
        if (followersChange <= 0 || followersChange >= 1)
            change = (int)followersChange;
        else
            change = -1 * (int)Math.Round(totalFollowers / followersChange);

        var symbol = (followersChange >= 1) ? "+" : "";
        var text = string.Format("{0} ({1}{2})", totalFollowers, symbol, change);

        return text;
    }


}
