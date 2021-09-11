using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.Data;
using SocialMedia.Models;

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
                    Title = Model.Title,
                    Text = Model.Text,
                    AuthorId = _authorId,
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
                                    Title = e.Title,
                                    Text = e.Text,
                                    AuthorId = e.AuthorId,
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable <PostListItem> GetPostsByAuthorId(Guid authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.AuthorId == authorId)
                        .Select(e => 
                        
                    new PostListItem
                    {
                        Title = e.Title,
                        Text = e.Text
                    });
                return query.ToArray();
            }
        }

        public bool UpdatePost(PostUpdate model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var post =
                    ctx
                        .Posts.FirstOrDefault(p => p.Id == model.PostId && p.AuthorId == _authorId);
                post.Title = model.Title;
                post.Text = model.Text;
             
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var post =
                    ctx
                        .Posts.FirstOrDefault(p => p.Id == id && p.AuthorId == _authorId);

                ctx.Posts.Remove(post);

                return ctx.SaveChanges() == 1;

            }
        }
    }
}
