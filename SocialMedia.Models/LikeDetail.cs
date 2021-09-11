using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
	public class LikeDetail
	{
        public int Id { get; set; }

        [Display(Name = "Post ID")]
        public int PostId { get; set; }

        [Display(Name = "Owner ID")]
        public Guid OwnerId { get; set; }
    }
}
