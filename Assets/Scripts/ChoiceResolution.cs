using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
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
