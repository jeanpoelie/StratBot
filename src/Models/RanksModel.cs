﻿using Newtonsoft.Json;

namespace StratBot.Models
{
    public class RanksModel
    {

        [JsonProperty("apac")]
        public ApacModel apac { get; set; }

        [JsonProperty("emea")]
        public EmeaModel emea { get; set; }

        [JsonProperty("ncsa")]
        public NcsaModel ncsa { get; set; }
    }
}
