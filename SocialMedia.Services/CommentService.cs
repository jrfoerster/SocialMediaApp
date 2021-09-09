using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;

namespace SocialMedia.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
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
    }
}
