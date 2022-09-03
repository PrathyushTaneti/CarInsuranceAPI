using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeenFieldAPI.Models
{
    public partial class PaintingCost
    {
        public string? PanelDescription { get; set; }

        [Key]
        public int Id { get; set; }
        public string? VehicleVariantCode { get; set; }
        public int? Expense { get; set; }
    }
}
