using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class ApiKey
    {
        [Key]
        [Required]
        public string Key { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
