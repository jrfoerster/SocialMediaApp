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

        //// GET: api/Comment
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Comment/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // GET: api/Post/{id}/Comment
        [HttpGet]
        [Route("api/Post/{id}/Comment")]
        public IHttpActionResult GetAllByPostId([FromUri] int id)
        {
            var service = CreateCommentService();
            var comments = service.GetCommentsByPostId(id);
            return Ok(comments);
        }

        // GET: api/Author/{id}/Comment
        [HttpGet]
        [Route("api/Author/{id}/Comment")]
        public IHttpActionResult GetAllByAuthorId([FromUri] Guid id)
        {
            var service = CreateCommentService();
            var comments = service.GetCommentsByAuthorId(id);
            return Ok(comments);
        }

        // POST: api/Comment
        public IHttpActionResult Post([FromBody]CommentCreate comment)
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

        //// PUT: api/Comment/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Comment/5
        //public void Delete(int id)
        //{
        //}
    }
}
