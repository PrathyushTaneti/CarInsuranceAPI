using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeenFieldAPI.Models
{
    public partial class RepairRefitCost
    {

        [Required]
        public string? BodyPart { get; set; }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Feild Required")]
        public string? VehicleTypeCode { get; set; }

        [Required(ErrorMessage = "Feild Required")]
        public int? Expense { get; set; }
    }
}
