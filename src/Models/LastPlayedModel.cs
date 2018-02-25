﻿using Newtonsoft.Json;
using System;

namespace StratBot.Models
{
    public class LastPlayedModel
    {

        [JsonProperty("casual")]
        public int? casual { get; set; }

        [JsonProperty("ranked")]
        public int? ranked { get; set; }

        [JsonProperty("last_played")]
        public DateTime? last_played { get; set; }
    }
}
