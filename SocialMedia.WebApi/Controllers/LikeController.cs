﻿using Microsoft.AspNet.Identity;
using SocialMedia.Models;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialMedia.WebApi.Controllers
{
    public class LikeController : ApiController
    {
        private LikeService CreateLikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var likeService = new LikeService(userId);
            return likeService;
        }

        // POST -- CREATE
        public IHttpActionResult Post(LikeCreate like)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLikeService();

            if (!service.CreateLike(like))
                return InternalServerError();
            return Ok();
        }

        // GET by id  -- READ by id
        public IHttpActionResult Get(int id)
        {
            LikeService likeService = CreateLikeService();
            var like = likeService.GetLikeById(id);
            return Ok(like);
        }

        // DELETE
        public IHttpActionResult Delete(int id)
        {
            var service = CreateLikeService();

            if (!service.DeleteLike(id))
                return InternalServerError();

            return Ok();
        }
    }
}