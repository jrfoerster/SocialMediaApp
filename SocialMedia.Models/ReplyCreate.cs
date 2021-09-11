using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class ReplyCreate
    {
        [Required]
        [MaxLength(140, ErrorMessage = "Maximum character exceeded")]
        public string Text { get; set; }

        [Required]
        public int CommentId { get; set; }
    }
}
