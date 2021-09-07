using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
        public virtual List<Like> Likes { get; set; } = new List<Like>();
        public Guid AuthorId { get; set; }
    }
}
