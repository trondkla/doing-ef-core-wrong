using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PlayingWithEF.Models
{
    public class Blob
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public long PersonInstanceId { get; set; }

        // Navigation properties for EF Core
        [JsonIgnore]
        public PersonInstance PersonInstance { get; set; }
    }
}
