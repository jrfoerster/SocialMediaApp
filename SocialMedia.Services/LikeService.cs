using SocialMedia.Models;
using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
	public class LikeService
	{
		private readonly Guid _userId;

		public LikeService(Guid userId)
		{
			_userId = userId;
		}

		// POST -- CREATE
		public bool CreateLike(LikeCreate model)
		{
			var entity =
				new Like()
				{
					OwnerId = _userId,
					PostId = model.PostId,
					Post = model.Post,
					Id = model.Id
				};

			using (var ctx = new ApplicationDbContext())
			{
				ctx.Likes.Add(entity);
				return ctx.SaveChanges() == 1;
			}
		}

		//GET BY Post ID ---  READ BY ID
		public LikeDetail GetLikeById(int id)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity =
					ctx
						.Likes
						.Single(e => e.PostId == id && e.OwnerId == _userId);
				return
					new LikeDetail
					{
						OwnerId = _userId,
						PostId = entity.PostId,
						Post = entity.Post
					};
			}
		}

		//UPDATE
		public bool UpdateLike(LikeEdit model)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity =
					ctx
						.Likes
						.Single(e => e.PostId == model.PostId && e.OwnerId == _userId);

				entity.PostId = model.PostId;

				return ctx.SaveChanges() == 1;
			}
		}

		// DELETE
		public bool DeleteLike(int postId)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity =
					ctx
						.Likes
						.Single(e => e.PostId == postId && e.OwnerId == _userId);

				ctx.Likes.Remove(entity);

				return ctx.SaveChanges() == 1;
			}
		}
	}
}
