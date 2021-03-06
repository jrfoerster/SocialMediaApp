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

        public CommentDetail GetCommentById(int id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var comment = context.Comments.FirstOrDefault(c => c.Id == id);
                
                if (comment is null)
                {
                    return null;
                }

                return new CommentDetail
                {
                    Id = comment.Id,
                    PostId = comment.PostId,
                    Text = comment.Text,
                    AuthorId = comment.AuthorId
                };
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

        public bool UpdateComment(CommentUpdate model)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var comment = context.Comments.FirstOrDefault(c => c.Id == model.CommentId && c.AuthorId == _userId);

                if (comment is null)
                {
                    return false;
                }

                comment.Text = model.Text;
                return context.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var comment = context.Comments.FirstOrDefault(c => c.Id == id && c.AuthorId == _userId);

                if (comment is null)
                {
                    return false;
                }

                context.Comments.Remove(comment);
                return context.SaveChanges() == 1;
            }
        }
    }
}
