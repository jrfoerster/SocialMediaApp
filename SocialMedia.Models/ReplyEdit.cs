using System;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class ReplyEdit
    {
        [Required]
        public int CommentId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public Guid AuthorId { get; set; }
    }
}
