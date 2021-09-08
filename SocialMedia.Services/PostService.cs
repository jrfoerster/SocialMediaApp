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

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.AuthorId == _authorId)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    Id = e.Id,
                                    Title = e.Title,
                                    Text = e.Text,
                                    _authorId = e.AuthorId,
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
