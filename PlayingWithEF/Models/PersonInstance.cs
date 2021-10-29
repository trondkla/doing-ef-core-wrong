using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PlayingWithEF.Models
{
    public class PersonInstance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [JsonIgnore] public Blob Blob { get; set; } = new Blob(); // TODO removing new Blob() fixes the problem
    }
}
