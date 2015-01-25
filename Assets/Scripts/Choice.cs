using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace Scene
{
    public class Choice : MonoBehaviour
    {
		private Text _choiceText;
		private WeekendEvent _eventChoice;		

        // ReSharper disable once UnusedMember.Local
        void Start()
        {
			_choiceText = GetComponent<Text>();
			if (_choiceText == null)
				throw new MissingComponentException("The Choice component needs to have an assoicated Text component on the same class.");

			_eventChoice = GameState.ChooseRandomWeekendEvent();
			_choiceText.text = _eventChoice.ChoiceText;
        }

        public void Choose()
        {
			GameState.ChosenEvent = _eventChoice;
			GameState.ChosenEvent.EventHasBeenChosen = true;
        }
    }
}
