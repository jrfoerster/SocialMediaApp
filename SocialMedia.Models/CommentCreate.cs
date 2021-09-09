using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class CommentCreate
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
