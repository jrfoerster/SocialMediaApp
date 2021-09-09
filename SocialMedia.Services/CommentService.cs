using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool PostIdExists(int postId)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var post = context.Posts.Find(postId);
                return post != null;
            }
        }

        public bool CreateComment(CommentCreate model)
        {
            var comment = new Comment()
            {
                AuthorId = _userId,
                PostId = model.PostId,
                Text = model.Text
            };

            using (var context = ApplicationDbContext.Create())
            {
                context.Comments.Add(comment);
                return context.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetCommentsByPostId(int postId)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var query = context.Comments
                    .Where(c => c.PostId == postId)
                    .Select(c => new CommentListItem
                    {
                        Text = c.Text,
                        AuthorId = c.AuthorId
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<CommentListItem> GetCommentsByAuthorId(Guid authorId)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var query = context.Comments
                    .Where(c => c.AuthorId.Equals(authorId))
                    .Select(c => new CommentListItem
                    {
                        Text = c.Text,
                        AuthorId = c.AuthorId
                    });

                return query.ToArray();
            }
        }
    }
}
