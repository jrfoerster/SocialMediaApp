using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class ReplyListItem
    {
        public string Text { get; set; }
        public Guid AuthorId { get; set; }
        public int CommentId { get; set; }
    }
}
