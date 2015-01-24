using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
	public class WeekendEvent
	{
		public bool EventHasBeenChosen { get; set; }

		public string ChoiceText { get; set; }
		public string EventNarrative { get; set; }
		public string ResultNarrative { get; set; }

		public float PrepFollowersChange { get; set; }
		public float NerdFollowersChange { get; set; }
		public float JockFollowersChange { get; set; }
		public float EmoFollowersChange { get; set; }
		public float DramaFollowersChange { get; set; }
		public float BandFollowersChange { get; set; }
		public float StonerPreFollowersChange { get; set; }
		public float ArtistFollowersChange { get; set; }
	}
}
