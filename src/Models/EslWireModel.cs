using System;
using System.Collections.Generic;
using System.Text;

namespace StratBot.Models
{
    public class ESLWireModel
    {
        public string PlayerName { get; set; }

        public string TeamInitials { get; set; }

        public List<string> CheckInOrOutDate { get; set; }
    }
}
