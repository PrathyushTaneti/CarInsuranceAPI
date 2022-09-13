using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BeenFieldAPI.Models
{
    public partial class PaintingCost
    {
        public string? PanelDescription { get; set; }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "VehicleVariantCode Required")]
        public string? VehicleVariantCode { get; set; }

        [Required(ErrorMessage = "Expense Required")]
        public int? Expense { get; set; }

        [Required(ErrorMessage = "Paint Name Required")]
        public string? Paint { get; set; }

        [Range(0,int.MaxValue, ErrorMessage = "Please Enter A Valid Integer")]
        [Required(ErrorMessage = "Paint Id Required")]
        public int PaintId { get; set; }
    }
}
