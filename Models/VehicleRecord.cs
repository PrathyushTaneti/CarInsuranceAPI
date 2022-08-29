using System;
using System.Collections.Generic;

namespace BeenFieldAPI.Models
{
    public partial class VehicleRecord
    {
        public int Id { get; set; }
        public string VehicleMake { get; set; } = null!;
        public string VehicleModel { get; set; } = null!;
        public string VehicleVariant { get; set; } = null!;
        public string? VehicleMakeCode { get; set; }
        public string? VehicleModelCode { get; set; }
        public string? VehicleVariantCode { get; set; }
        public string? VehicleTypeCode { get; set; }
    }
}
