using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AutorizationController : ControllerBase
	{
		private readonly string connectionString;

		public AutorizationController(IConfiguration configuration)
		{
			connectionString = configuration.GetConnectionString("BlogAppCon");
		}

		[HttpPost]
		public JsonResult LogIn(User user)
		{
			string query = $@"
							select 
								USER_LOGIN,
								USER_PASSWORD,
								EMAIL,
								USERNAME,
								coalesce(PHOTO,0) as PHOTO,
								convert(varchar(10), BIRTHDATE, 23) as BIRTHDATE,
								CREATING_ACCOUNT_DATE,
								NUMBER_OF_POSTS,
								USER_ROLE
							 from BLOG_USER
							 where USER_LOGIN = '{user.Login}' and
								   USER_PASSWORD = '{user.Password}';";
			var users = Database.Query.Select(query, connectionString);
			if (users.Rows.Count > 0)
			{
				var currentUser = new User
				{
					Login = users.Rows[0]["USER_LOGIN"].ToString(),
					Password = users.Rows[0]["USER_PASSWORD"].ToString(),
					Email = users.Rows[0]["EMAIL"].ToString(),
					Name = users.Rows[0]["USERNAME"].ToString(),
					Photo = Int32.Parse(users.Rows[0]["PHOTO"].ToString()),
					BirthDate = users.Rows[0]["BIRTHDATE"].ToString(),
					AccountCreatingDate = users.Rows[0]["CREATING_ACCOUNT_DATE"].ToString(),
					NumberOfPosts = Int32.Parse(users.Rows[0]["NUMBER_OF_POSTS"].ToString()),
					Role = users.Rows[0]["USER_ROLE"].ToString()
				};

				Models.User.CurrentUser = currentUser;

				return new JsonResult("Autorization has been successfulled");
			}

			return new JsonResult("Autorization has been failed");
		}

		[HttpGet]
		public JsonResult Get()
		{
			if (Models.User.CurrentUser == null)
				Console.WriteLine("user is null!");
			return Models.User.GetCurrentUserInJson();
		}

		[HttpDelete]
		public JsonResult LogOut()
		{
			Models.User.CurrentUser = null;
			return new JsonResult("User successfully quit");
		}
	}
}
