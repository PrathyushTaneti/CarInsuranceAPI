using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeenFieldAPI.Models
{
    public partial class RepairRefitCost
    {
        public string? BodyPart { get; set; }

        [Key]
        public int Id { get; set; }
        public string? VehicleTypeCode { get; set; }
        public int? Expense { get; set; }
    }
}
