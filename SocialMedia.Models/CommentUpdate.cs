using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
