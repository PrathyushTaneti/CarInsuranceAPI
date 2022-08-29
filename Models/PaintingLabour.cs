using System;
using System.Collections.Generic;

namespace BeenFieldAPI.Models
{
    public partial class PaintingLabour
    {
        public string? PanelDescription { get; set; }
        
        public string? VehicleVariantCode { get; set; }

        public int? Expense { get; set; }
        public int Id { get; set; }
    }
}
