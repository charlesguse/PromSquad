using Scene;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceResolution : MonoBehaviour
{
    private Text _resolution;

    // ReSharper disable once UnusedMember.Local
    private void Start()
    {
        _resolution = GetComponent<Text>();
        _resolution.text = GameState.ChosenEvent.EventNarrative;
    }
}
