using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class ApiCall
    {
        [Key]
        public int ApiCallId { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        public string? Endpoint { get; set; }
        [Required]
        [ForeignKey("Key")]
        public string? ApiKey { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public string? UserId { get; set; }
        [Required]
        public string? IpAddress { get; set; }
    }
}
