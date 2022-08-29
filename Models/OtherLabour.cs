using System;
using System.Collections.Generic;

namespace BeenFieldAPI.Models
{
    public partial class OtherLabour
    {
        public double? PanelId { get; set; }
        public string? CarBodyPanel { get; set; }
        public double? LowSeverity { get; set; }
        public double? MediumSeverity { get; set; }
        public double? HighSeverity { get; set; }
        public int Id { get; set; }
    }
}
