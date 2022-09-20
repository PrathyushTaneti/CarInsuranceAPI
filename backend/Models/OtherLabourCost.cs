using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeenFieldAPI.Models
{
    public partial class OtherLabourCost
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "BodyPart Required")]
        [StringLength(255, ErrorMessage = "Invalid Input for BodyPart")]
        public string? BodyPart { get; set; }

        [Required(ErrorMessage = "LowSeverity Required")]
        public float? LowSeverity { get; set; }

        [Required(ErrorMessage = "MediumSeverity Required")]
        public float? MediumSeverity { get; set; }

        [Required(ErrorMessage = "HightSeverity Required")]
        public float? HighSeverity { get; set; }

        [Required(ErrorMessage = "BodyPartId Required")]
        public float? BodyPartId { get; set; }

        [StringLength(2,ErrorMessage = "Invalid Input For CityCode")]
        [Required(ErrorMessage = "CityCode Required")]
        public string? CityCode { get; set; }
    }
}
