using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeenFieldAPI.Models
{
    public partial class VehicleRecord
    {

        [Key]
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
