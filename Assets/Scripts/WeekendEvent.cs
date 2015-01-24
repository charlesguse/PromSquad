namespace Assets.Scripts
{
	public class WeekendEvent
	{
	    public WeekendEvent()
	    {
            ChoiceText = string.Empty;
            EventNarrative = string.Empty;
            ResultNarrative = string.Empty;
            OneShot = string.Empty;
            Ambience = string.Empty;
	    }

		public bool EventHasBeenChosen = false;

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

        public string OneShot { get; set; }
        public string Ambience { get; set; }
	}
}
