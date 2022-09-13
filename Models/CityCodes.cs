using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BeenFieldAPI.Models
{
    public class CityCodes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "CityName Required")]
        public string? CityName { get; set; }

        [Required(ErrorMessage = "CityCode Required")]
        [StringLength(2,ErrorMessage = "Invalid CityCode")]
        public string? CityCode { get; set; }
    }
}
