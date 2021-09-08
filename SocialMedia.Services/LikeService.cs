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
	}
}
