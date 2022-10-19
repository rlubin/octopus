using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class ApiKey
    {
        [Key]
        public int ApiKeyId { get; set; }
        [Required]
        public string? Key { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
