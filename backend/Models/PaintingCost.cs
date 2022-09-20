using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BeenFieldAPI.Models
{
    public partial class PaintingCost
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "PanelDescription Required")]
        [StringLength(255, ErrorMessage = "Invalid Input")]
        public string? PanelDescription { get; set; }

        [Required(ErrorMessage = "VehicleVariantCode Required")]
        [StringLength(10, ErrorMessage = "Invalid Input")]
        public string? VehicleVariantCode { get; set; }

        [Required(ErrorMessage = "Expense Required")]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid Input")]
        public int? Expense { get; set; }

        [Required(ErrorMessage = "CityCode Required")]
        [StringLength(2, ErrorMessage = "Invalid Input")]
        public string? CityCode { get; set; }


        [Required(ErrorMessage = "Paint Name Required")]
        [StringLength(30, ErrorMessage = "Invalid Input")]
        public string? Paint { get; set; }

        [Required(ErrorMessage = "Paint Id Required")]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid Input")]
        public int PaintId { get; set; }

        [Required(ErrorMessage = "Panel Id Required")]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid Input")]
        public int PanelId { get; set; }
    }
}
