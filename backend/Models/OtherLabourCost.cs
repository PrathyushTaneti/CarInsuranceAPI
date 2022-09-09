using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeenFieldAPI.Models
{
    public partial class OtherLabourCost
    {
        public double? PanelId { get; set; }
        public string? CarBodyPanel { get; set; }
        public double? LowSeverity { get; set; }
        public double? MediumSeverity { get; set; }
        public double? HighSeverity { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
