using System.ComponentModel.DataAnnotations;


namespace api.Models
{
    public class Account
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
