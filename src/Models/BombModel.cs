﻿using Newtonsoft.Json;

namespace StratBot.Models
{
    public class BombModel
    {

        [JsonProperty("bestScore")]
        public int? bestScore { get; set; }

        [JsonProperty("lost")]
        public int? lost { get; set; }

        [JsonProperty("played")]
        public int? played { get; set; }

        [JsonProperty("won")]
        public int? won { get; set; }
    }
}
