using StratBot.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StratBot.Enums
{
    public enum RegionEnum
    {
        [RegionInformation("Europe")]
        EMEA = 0,

        [RegionInformation("America")]
        NCSA = 1,

        [RegionInformation("ASIA")]
        APAC = 2,
    }
}
