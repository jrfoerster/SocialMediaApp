using Microsoft.AspNet.Identity;
using SocialMedia.Models;
using SocialMedia.Services;
using System;
using System.Web.Http;

namespace SocialMedia.WebApi.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new CommentService(userId);
        }

        // GET: api/Comment/{id}
        public IHttpActionResult Get(int id)
        {
            var service = CreateCommentService();
            var comment = service.GetCommentById(id);

            if (comment is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(comment);
            }
        }

        // GET: api/Comment?postId={postId}
        [HttpGet]
        public IHttpActionResult GetAllByPostId([FromUri] int postId)
        {
            var service = CreateCommentService();
            var comments = service.GetCommentsByPostId(postId);
            return Ok(comments);
        }

        // GET: api/Comment?authorId={authorId}
        [HttpGet]
        public IHttpActionResult GetAllByAuthorId([FromUri] Guid authorId)
        {
            var service = CreateCommentService();
            var comments = service.GetCommentsByAuthorId(authorId);
            return Ok(comments);
        }

        // POST: api/Comment
        public IHttpActionResult Post([FromBody] CommentCreate comment)
        {
            if (comment is null)
            {
                return BadRequest("Http Request Body cannot be empty!");
            }

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var service = CreateCommentService();

            if (service.PostIdExists(comment.PostId) == false)
            {
                return NotFound();
            }

            if (service.CreateComment(comment))
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        // PUT: api/Comment
        public IHttpActionResult Put([FromBody] CommentUpdate comment)
        {
            if (comment is null)
            {
                return BadRequest("Http Request Body cannot be empty!");
            }

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var service = CreateCommentService();

            if (service.UpdateComment(comment))
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE: api/Comment/{id}
        public IHttpActionResult Delete([FromUri] int id)
        {
            var service = CreateCommentService();

            if (service.DeleteComment(id))
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
    }
}
