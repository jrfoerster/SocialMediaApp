using System;

namespace SocialMedia.Models
{
    public class CommentListItem
    {
        public string Text { get; set; }
        public Guid AuthorId { get; set; }
    }
}
