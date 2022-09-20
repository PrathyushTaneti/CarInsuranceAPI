using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeenFieldAPI.Models
{
    public partial class RepairRefitCost
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "BodyPart Required")]
        public string? BodyPart { get; set; }

        [Required(ErrorMessage = "VehicleTypeCode Required")]
        public string? VehicleTypeCode { get; set; }

        [Required(ErrorMessage = "Expense Required")]
        [Range(0,int.MaxValue,ErrorMessage ="Invalid Input")]
        public int? Expense { get; set; }

        [Required(ErrorMessage ="CityCode Required")]
        [StringLength(2,ErrorMessage ="Input Invalid")]
        public string? CityCode { get; set; }

        [Required(ErrorMessage ="BodyPartId Required")]
        [Range(0,int.MaxValue,ErrorMessage ="Invalid Input")]
        public int? BodyPartId { get; set; }
    }
}
