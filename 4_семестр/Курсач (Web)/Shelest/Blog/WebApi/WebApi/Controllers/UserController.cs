using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly string connectionString;
		private readonly string concreteRootPath;
		public UserController(IConfiguration configuration, IWebHostEnvironment webHost)
		{
			connectionString = configuration.GetConnectionString("BlogAppCon");
			concreteRootPath = webHost.ContentRootPath;
		}

		[HttpGet]
		public JsonResult Get()
		{
			string query = @"select 
								USER_LOGIN,
								USER_PASSWORD,
								EMAIL,
								USERNAME,
								PHOTO,
								convert(varchar(10), BIRTHDATE, 23) as BIRTHDATE,
								CREATING_ACCOUNT_DATE,
								NUMBER_OF_POSTS
							 from BLOG_USER";
			var users = Database.Query.Select(query, connectionString);
			return new JsonResult(users);
		}

		[HttpGet("{login}")]
		public JsonResult Get(string login)
		{
			string query = $@"select 
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
							 where USER_LOGIN = '{login}';";
			var users = Database.Query.Select(query, connectionString);
			var user = new User
			{
				Name = users.Rows[0]["USERNAME"].ToString(),
				Login = users.Rows[0]["USER_LOGIN"].ToString(),
				Password = users.Rows[0]["USER_PASSWORD"].ToString(),
				Email = users.Rows[0]["EMAIL"].ToString(),
				Photo = Int32.Parse(users.Rows[0]["PHOTO"].ToString()),
				BirthDate = users.Rows[0]["BIRTHDATE"].ToString(),
				AccountCreatingDate = users.Rows[0]["CREATING_ACCOUNT_DATE"].ToString(),
				NumberOfPosts = Int32.Parse(users.Rows[0]["NUMBER_OF_POSTS"].ToString()),
				Role = users.Rows[0]["USER_ROLE"].ToString()
			};

			return new JsonResult(user);
		}

		[HttpPost]
		public JsonResult Post(User newUser)
		{
			string query = $@"
							insert into BLOG_USER
							(
							 USER_LOGIN,
							 USER_PASSWORD,
							 USERNAME,
							 EMAIL
							)
							values
							(
							 '{newUser.Login}',
							 '{newUser.Password}',
							 '{newUser.Name}',
							 '{newUser.Email}'
							);";
			Database.Query.Insert(query, connectionString);
			return new JsonResult("Registration has been successfull");
		}

		[HttpPut]
		public JsonResult Put(User user)
		{
			string query = $@"
							update BLOG_USER set 
								USERNAME = '{user.Name}',
								BIRTHDATE = '{user.BirthDate}',
								EMAIL = '{user.Email}',
								PHOTO = '{user.Photo}'
							where USER_LOGIN = '{user.Login}';";
			Database.Query.Update(query, connectionString);
			return new JsonResult("Account has been updated successfully");
		}

		[HttpDelete("{login}")]
		public JsonResult Delete(string login)
		{
			string query = $@"
							 delete from BLOG_USER
							 where USER_LOGIN = '{login}'";
			Database.Query.Delete(query, connectionString);
			return new JsonResult("Account has been deleted successfully");
		}
	}
}
