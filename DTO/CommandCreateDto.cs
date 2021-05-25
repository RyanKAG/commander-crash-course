using System.ComponentModel.DataAnnotations;


//external representation for the internal domain implementation
namespace DTO
{
    public class CommandCreateDto
    {
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}