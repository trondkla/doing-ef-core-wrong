using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PlayingWithEF
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        public long PostId { get; set; }

        [JsonIgnore] public Post Post { get; set; } = new Post();
    }
}