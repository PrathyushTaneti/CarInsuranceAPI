using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeenFieldAPI.Models
{
    public partial class PartsCost
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "BodyPart Required")]
        [StringLength(255, ErrorMessage = "Invalid Input")]
        public string? BodyPart { get; set; }

        [Required(ErrorMessage = "VehicleVehicleCode Required")]
        [StringLength(10, ErrorMessage = "Invalid Input")]
        public string? VehicleVariantCode { get; set; }

        [Required(ErrorMessage = "Cost Feild Required")]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid Input")]
        public int? Cost { get; set; }

        [Required(ErrorMessage = "CityCode Required")]
        [StringLength(10, ErrorMessage = "Invalid Input")]
        public string? CityCode { get; set; }

        [Required(ErrorMessage = "BodyPartId Required")]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid Input")]
        public int BodyPartId { get; set; }
    }
}
