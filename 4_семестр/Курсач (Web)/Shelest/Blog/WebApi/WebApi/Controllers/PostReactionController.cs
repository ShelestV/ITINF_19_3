using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostReactionController : ControllerBase
	{
		private readonly string connectionString;

		public PostReactionController(IConfiguration configuration)
		{
			connectionString = configuration.GetConnectionString("BlogAppCon");
		}

		[HttpPost]
		public JsonResult Post(PostReaction reaction)
		{
			string query = $@"insert into POST_REACTION
								(
								 REACTOR,
								 POST,
								 REACTION
								)								
								values
								(
								 '{Models.User.CurrentUser.Login}',
								 '{reaction.Post}',
								 '{reaction.Reaction}'
								);";
			try
			{
				Database.Query.Insert(query, connectionString);
			}
			catch (SqlException)
			{
				return new JsonResult("You have already reacted on this post");
			}

			return new JsonResult("Post has been reacted!");
		}

		[HttpDelete("{post_id}")]
		public JsonResult Delete(string post_id)
		{
			string query = $@"
							delete from POST_REACTION
							where REACTOR = '{Models.User.CurrentUser.Login}' and 
								  POST = '{post_id}';";
			Database.Query.Delete(query, connectionString);
			return new JsonResult("Post react has been deleted");
		}
	}
}
