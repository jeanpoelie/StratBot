﻿using StratBot.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StratBot.Enums
{
    public enum PlatformEnum
    { 
        [PlatformInformation("PC", "pc")]
        PC = 0,

        [PlatformInformation("Xbox 1", "xbox")]
        XBOX = 1,

        [PlatformInformation("Playstation 4", "ps4")]
        PS4 = 2
    }
}
