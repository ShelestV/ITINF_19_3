using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostController : ControllerBase
	{
		private readonly string connectionString;

		public PostController(IConfiguration configuration)
		{
			connectionString = configuration.GetConnectionString("BlogAppCon");
		}

		[HttpGet]
		public JsonResult Get()
		{
			string query = "";

			if (Models.User.CurrentUser.Role == "ADMIN")
			{
				query = $@"
							select 
								P.ID,
								P.POST_TEXT,
								U.USER_LOGIN,
								U.USERNAME,
								coalesce(U.PHOTO,0) as PHOTO,
								P.THEME,
								convert(varchar(10),P.POSTING_DATE,23) as POSTING_DATE,
								case 
									when not exists (select * from POST_REACTION R where R.POST = P.ID and R.REACTOR = '{Models.User.CurrentUser.Login}') then -1
									else (select R.REACTION
										  from POST_REACTION R
										  where R.POST = P.ID and R.REACTOR = '{Models.User.CurrentUser.Login}')
								end as REACTION,
								(select count(*)
								 from POST_REACTION R
								 where R.POST = P.ID and R.REACTION = 1) as LIKES,
								(select count(*)
								 from POST_REACTION R
								 where R.POST = P.ID and R.REACTION = 0) as DISLIKES
							from POST P inner join BLOG_USER U on P.AUTHOR = U.USER_LOGIN
							order by P.POSTING_DATE desc;";
			}
			else
			{
				query = $@"
							select 
								P.ID,
								P.POST_TEXT,
								U.USER_LOGIN,
								U.USERNAME,
								coalesce(U.PHOTO,0) as PHOTO,
								P.THEME,
								convert(varchar(10),P.POSTING_DATE,23) as POSTING_DATE,
								case 
									when not exists (select * from POST_REACTION R where R.POST = P.ID and R.REACTOR = '{Models.User.CurrentUser.Login}') then -1
									else (select R.REACTION
										  from POST_REACTION R
										  where R.POST = P.ID and R.REACTOR = '{Models.User.CurrentUser.Login}')
								end as REACTION,
								(select count(*)
								 from POST_REACTION R
								 where R.POST = P.ID and R.REACTION = 1) as LIKES,
								(select count(*)
								 from POST_REACTION R
								 where R.POST = P.ID and R.REACTION = 0) as DISLIKES
							from POST P inner join BLOG_USER U on P.AUTHOR = U.USER_LOGIN
							where P.AUTHOR in (select F.FRIEND_LOGIN 
											   from FRIEND F
											   where F.USER_LOGIN = '{Models.User.CurrentUser.Login}') or
								  P.AUTHOR = '{Models.User.CurrentUser.Login}'
							order by P.POSTING_DATE desc;";
			}
			var posts = Database.Query.Select(query, connectionString);
			return new JsonResult(posts);
		}

		[HttpPost]
		public JsonResult Post(Post newPost)
		{
			string query = $@"
							insert into POST
							(
							 POST_TEXT,
							 AUTHOR
							)
							values
							(
							 '{newPost.Text}',
							 '{Models.User.CurrentUser.Login}'
							);";
			Database.Query.Insert(query, connectionString);
			return new JsonResult("Post has been created successfully");
		}

		[HttpPut]
		public JsonResult Put(Post post)
		{
			string query = $@"
							update POST set 
								POST_TEXT = '{post.Text}'
							where ID = '{post.ID}';";
			Database.Query.Update(query, connectionString);
			return new JsonResult("Post has been updated successfully");
		}

		[HttpDelete("{id}")]
		public JsonResult Delete(string id)
		{
			string query = $@"
							 delete from POST
							 where ID = '{id}'";
			Database.Query.Delete(query, connectionString);
			return new JsonResult("Post has been deleted successfully");
		}
	}
}
