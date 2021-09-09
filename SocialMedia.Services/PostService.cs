using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.Data;

namespace SocialMedia.Services
{
    public class PostService
    {
        private readonly Guid _authorId;

        public PostService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreatePost(PostCreate Model)
        {
            var entity =
                new Post()
                {
                    Id = Model.Id,
                    Title = Model.Title,
                    Text = Model.Text,
                    AuthorId = _authorId,
                    Comments = Model.Comments,
                    Likes = Model.Likes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
