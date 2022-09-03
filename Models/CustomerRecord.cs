using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeenFieldAPI.Models
{
    public partial class CustomerRecord
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }
    }
}
