using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class LikeEdit
	{
        [Required]
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }
    }
}
