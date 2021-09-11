using System;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class ReplyEdit
    {
        [Required]
        public int ReplyId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
