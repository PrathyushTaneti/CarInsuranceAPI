using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeenFieldAPI.Models
{
    public partial class PartsCost
    {
        public string? BodyPart { get; set; }

        [Key]
        public int Id { get; set; }

        public string? VehicleVariantCode { get; set; }

        public int? Cost { get; set; }

        public int BodyPartId { get; set; }
    }
}
