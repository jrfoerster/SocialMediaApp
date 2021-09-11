using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class LikeCreate
    {
        [Required]
        public int PostId { get; set; }
    }
}
