using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Scene
{
    public class Choice : MonoBehaviour
    {
		public GameState GameState;

		private Text _choiceText;
		private WeekendEvent _eventChoice;		

        // ReSharper disable once UnusedMember.Local
        void Start()
        {
			_choiceText = this.GetComponent<Text>();
			if (_choiceText == null)
				throw new MissingComponentException("The Choice component needs to have an assoicated Text component on the same class.");

			_eventChoice = ChooseRandomWeekendEvent();
			_choiceText.text = _eventChoice.ChoiceText;
        }

		private WeekendEvent ChooseRandomWeekendEvent()
		{
			var availableEvents = GameState.WeekendEvents.Where(x => !x.EventHasBeenChosen).ToList();
			return availableEvents[Random.Range(0, availableEvents.Count())];
		}

        public void Choose()
        {
			GameState.ChosenEvent = _eventChoice;
			GameState.ChosenEvent.EventHasBeenChosen = true;
        }
    }
}
