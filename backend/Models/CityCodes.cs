using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BeenFieldAPI.Models
{
    public class CityCodes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "CityName Required")]
        [StringLength(100, ErrorMessage = "Invalid CityCode")]
        [NotNull]
        public string CityName { get; set; }

        [Required(ErrorMessage = "CityCode Required")]
        [StringLength(2,ErrorMessage = "Invalid CityCode")]
        [NotNull]
        public string CityCode { get; set; }
    }
}
