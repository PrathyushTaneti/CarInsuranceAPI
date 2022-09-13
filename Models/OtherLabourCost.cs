using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeenFieldAPI.Models
{
    public partial class OtherLabourCost
    {

        [Required(ErrorMessage = "PanelId Required")]
        [StringLength(50, ErrorMessage = "Invalid Input")]
        public double? PanelId { get; set; }

        [Required(ErrorMessage = "Feild Required")]
        public string? CarBodyPanel { get; set; }

        [Required(ErrorMessage = "Feild Required")]
        public double? LowSeverity { get; set; }

        [Required(ErrorMessage = "Feild Required")]
        public double? MediumSeverity { get; set; }

        [Required(ErrorMessage = "Feild Required")]
        public double? HighSeverity { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
