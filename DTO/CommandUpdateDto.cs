using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class CommandUpdateDto
    {
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}