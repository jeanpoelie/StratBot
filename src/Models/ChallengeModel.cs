using System;
using System.Collections.Generic;

namespace Stratbot
{
	public class ChallengeModel
	{
		public int? Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string Difficulty { get; set; }

		public string Side { get; set; }

		public string Credits { get; set; }

		public long? Likes { get; set; }

		public long? Dislikes { get; set; }

		public long? Reports { get; set; }

		public string GameName { get; set; }

		public int KeyboardAndMouse { get; set; }

		public int Controller { get; set; }

	    public int Disabled { get; set; }

        public int Suggested { get; set; }

        public int QuickRandom { get; set; }

        public List<string> GameModes { get; set; }

        public List<string> Maps { get; set; }
    }
}