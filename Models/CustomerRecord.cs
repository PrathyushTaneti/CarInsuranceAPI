using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeenFieldAPI.Models
{
    public partial class CustomerRecord
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [StringLength(50,ErrorMessage ="Invalid Input")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Address Required")]
        [StringLength(200, ErrorMessage = "Invalid Input")]
        public string? Address { get; set; }
    }
}
