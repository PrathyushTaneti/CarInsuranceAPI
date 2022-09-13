using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeenFieldAPI.Models
{
    public partial class PartsCost
    {
        [Required]
        public string? BodyPart { get; set; }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Feild Required")]
        public string? VehicleVariantCode { get; set; }

        [Required(ErrorMessage = "Feild Required")]
        public int? Cost { get; set; }

        [Required(ErrorMessage = "Feild Required")]
        public int BodyPartId { get; set; }
    }
}
