using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentReactionController : ControllerBase
	{
		private readonly string connectionString;

		public CommentReactionController(IConfiguration configuration)
		{
			connectionString = configuration.GetConnectionString("BlogAppCon");
		}

		[HttpPost]
		public JsonResult Post(CommentReaction reaction)
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
								 '{reaction.Comment}',
								 '{reaction.Reaction}'
								);";
			try
			{
				Database.Query.Insert(query, connectionString);
			}
			catch (SqlException)
			{
				return new JsonResult("You have already reacted on this comment");
			}

			return new JsonResult("Comment has been reacted!");
		}

		[HttpDelete("{comment_id}")]
		public JsonResult Delete(string comment_id)
		{
			var user = Models.User.CurrentUser;

			string query = $@"
							delete from POST_REACTION
							where REACTOR = '{user.Login}' and 
								  COMMENT = '{comment_id}';";
			Database.Query.Delete(query, connectionString);
			return new JsonResult("Comment react has been deleted");
		}
	}
}
