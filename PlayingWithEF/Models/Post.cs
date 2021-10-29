using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PlayingWithEF
{
    public class Post
    {
        [Key]
        public long Id { get; set; }

        public long UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        public string Content { get; set; }
    }
}