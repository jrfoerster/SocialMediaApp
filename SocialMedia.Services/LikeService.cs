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

		public bool PostIdExists(int postId)
		{
			using (var context = ApplicationDbContext.Create())
			{
				var post = context.Posts.Find(postId);
				return post != null;
			}
		}

		// POST -- CREATE
		public bool CreateLike(LikeCreate model)
		{
			var entity =
				new Like()
				{
					OwnerId = _userId,
					PostId = model.PostId,
				};

			using (var ctx = new ApplicationDbContext())
			{
				ctx.Likes.Add(entity);
				return ctx.SaveChanges() == 1;
			}
		}

		//GET BY Post ID ---  READ BY ID
		public IEnumerable<LikeDetail> GetLikeByPostId(int id)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var query =
					ctx
						.Likes
						.Where(e => e.PostId == id)
						.Select(e =>
		
					new LikeDetail
					{
						OwnerId = e.OwnerId,
						PostId = e.PostId
					});
				return query.ToArray();
			}
		}

		//GET BY Owner ID ---  READ BY ID
		public IEnumerable<LikeDetail> GetLikeByOwnerId(Guid id)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var query =
					ctx
						.Likes
						.Where(e => e.OwnerId == id)
						.Select(e => 
				
					new LikeDetail
					{
						OwnerId = _userId,
						PostId = e.PostId
					});
				return query.ToArray();
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
