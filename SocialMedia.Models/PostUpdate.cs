using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class PostUpdate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int PostId { get; set; }
    }
}
