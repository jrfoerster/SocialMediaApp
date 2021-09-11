using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class PostCreate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
