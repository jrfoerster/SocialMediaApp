﻿using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var reply =
                new Reply()
                {
                    AuthorId = _userId,
                    CommentId = model.CommentId,
                    Text = model.Text
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(reply);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Replies
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                        e =>
                        new ReplyListItem
                        {
                            AuthorId = e.AuthorId,
                            Text = e.Text,
                            CommentId = e.CommentId
                        }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<ReplyListItem> GetRepliesByCommentId(int commentId)
        {
            using (var ctx = ApplicationDbContext.Create())
            {
                var query = ctx.Replies
                    .Where(e => e.CommentId == commentId)
                    .Select(e => new ReplyListItem
                    {
                        Text = e.Text,
                        CommentId = e.CommentId
                    });

                return query.ToArray();
            }
        }

        public bool UpdateReply(ReplyEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.CommentId == model.CommentId && e.AuthorId == _userId);
                
                entity.Text = model.Text;
                entity.CommentId = model.CommentId;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
