using System.ComponentModel.DataAnnotations;

namespace MyHealthFirst.DTOs
{
    public class ChangeEmailRequestDto
    {
        [Required]
        public string NewEmail { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
