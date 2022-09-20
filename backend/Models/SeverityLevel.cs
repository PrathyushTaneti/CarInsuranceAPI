using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace BeenFieldAPI.Models
{
    public class SeverityLevel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Feild Required")]
        public string?  SeverityLevelName { get; set; }

        [Required(ErrorMessage = "Feild Required")]
        public string? SeverityCode { get; set; }

    }
}
