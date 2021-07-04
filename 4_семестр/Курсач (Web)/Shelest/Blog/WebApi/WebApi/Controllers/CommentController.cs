using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentController : ControllerBase
	{
		private readonly string connectionString;

		public CommentController(IConfiguration configuration)
		{
			connectionString = configuration.GetConnectionString("BlogAppCon");
		}

		[HttpGet]
		public JsonResult Get()
		{
			string query = @"
							select 
								ID,
								COMMENT_TEXT,
								AUTHOR,
								POST,
								COMMENT_DATE
							from COMMENT;";
			var posts = Database.Query.Select(query, connectionString);
			return new JsonResult(posts);
		}

		[HttpPost]
		public JsonResult Post(Comment newComment)
		{
			string query = $@"
							insert into COMMENT
							(
							 COMMENT_TEXT,
							 AUTHOR,
							 POST
							)
							values
							(
							 '{newComment.Text}',
							 '{newComment.Author.Login}',
							 '{newComment.Post.ID}'
							);";
			Database.Query.Insert(query, connectionString);
			return new JsonResult("Comment has been created successfully");
		}

		[HttpPut]
		public JsonResult Put(Comment comment)
		{
			string query = $@"
							update COMMENT set 
								COMMENT_TEXT = '{comment.Text}'
							where ID = '{comment.ID}';";
			Database.Query.Update(query, connectionString);
			return new JsonResult("Comment has been updated successfully");
		}

		[HttpDelete("{id}")]
		public JsonResult Delete(string id)
		{
			string query = $@"
							 delete from COMMENT
							 where ID = '{id}'";
			Database.Query.Delete(query, connectionString);
			return new JsonResult("Comment has been deleted successfully");
		}
	}
}
