using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SocialMedia.Models;
using SocialMedia.Services;

namespace SocialMedia.WebApi.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        private PostService CreatePostService()
        {
            var authorId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(authorId);
            return postService;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetPosts();
            return Ok(posts);
        }

        public IHttpActionResult Get(Guid authorId)
        {
            PostService postService = CreatePostService();
            var post = postService.GetPostsByAuthorId(authorId);
            return Ok(post);
        }

        // POST api/<controller>
        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();
        }

        //// PUT api/<controller>/
        public IHttpActionResult Update(PostUpdate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.UpdatePost(post))
                return InternalServerError();

            return Ok();
        }



        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<controller>/5
        public IHttpActionResult Delete (int id)
        {
            var service = CreatePostService();

            if (!service.DeletePost(id))
                return InternalServerError();

            return Ok();
        }


        //public void Delete(int id)
        //{
        //}
    }
}