using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChoiceHeading : MonoBehaviour 
{
	// Use this for initialization
	void Start () {
		var text = GetComponent<Text>();
		text.text = string.Format("What do we do now? ({0} weeks til Prom)", GameState.WeekendsLeft);
	}
}
