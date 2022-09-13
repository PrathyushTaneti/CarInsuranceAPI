using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeenFieldAPI.Models
{
    public partial class VehicleRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string VehicleMake { get; set; } = null!;

        [Required]
        public string VehicleModel { get; set; } = null!;

        [Required]
        public string VehicleVariant { get; set; } = null!;

        [Required]
        public string? VehicleMakeCode { get; set; }

        [Required]
        public string? VehicleModelCode { get; set; }

        [Required]
        public string? VehicleVariantCode { get; set; }

        [Required]
        public string? VehicleTypeCode { get; set; }

        /*public VehicleRecord(string str)
        {
            this.VehicleModel = str;
        }*/
    }
}
