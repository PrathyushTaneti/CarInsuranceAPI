using System;
using System.Collections.Generic;

namespace BeenFieldAPI.Models
{
    public partial class RrLabour
    {
        public string? BodyPart { get; set; }
        public double? A { get; set; }
        public double? B { get; set; }
        public double? C { get; set; }
        public double? D { get; set; }
        public double? E { get; set; }
        public double? F { get; set; }
        public int Id { get; set; }
        public string? VehicleTypeCode { get; set; }
        public int? Expense { get; set; }
    }
}
