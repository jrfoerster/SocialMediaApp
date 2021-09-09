using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class ReplyCreate
    {
        [Required]
        [MaxLength(140, ErrorMessage = "Maximum character exceeded")]
        public string Text { get; set; }
        public Guid AuthorId { get; set; }
        public int CommentId { get; set; }
    }
}
