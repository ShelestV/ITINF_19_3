using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ThemeController : ControllerBase
	{
		private readonly string connectionString;

		public ThemeController(IConfiguration configuration)
		{
			connectionString = configuration.GetConnectionString("BlogAppCon");
		}

		[HttpGet]
		public JsonResult Get()
		{
			string query = @"select 
								ID,
								THEME_NAME,
								NUMBER_OF_POSTS
							from THEME;";
			var themes = Database.Query.Select(query, connectionString);
			return new JsonResult(themes);
		}

		[HttpPost]
		public JsonResult Post(Theme newTheme)
		{
			string query = $@"
							insert into THEME
							(
							 THEME_NAME
							)
							values
							(
							 {newTheme.Name}
							);";
			Database.Query.Insert(query, connectionString);
			return new JsonResult("Theme has been added successfully");
		}

		[HttpDelete("{id}")]
		public JsonResult Delete(string id)
		{
			string query = $@"
							delete from THEME
							where ID = '{id}'";
			Database.Query.Delete(query, connectionString);
			return new JsonResult("Theme has been deleted successfully");
		}
	}
}
