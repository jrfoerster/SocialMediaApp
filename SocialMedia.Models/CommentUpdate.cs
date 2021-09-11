using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class CommentUpdate
    {
        [Required]
        public int CommentId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
