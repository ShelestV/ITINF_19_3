using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FriendController : ControllerBase
	{
		private readonly string connectionString;

		public FriendController(IConfiguration configuration)
		{
			connectionString = configuration.GetConnectionString("BlogAppCon");
		}

		[HttpGet]
		public JsonResult GetActiveFriends()
		{
			string query = $@"select 
								BR.USER_LOGIN,
								BR.EMAIL,
								BR.USERNAME,
								BR.PHOTO,
								convert(varchar(10), BR.BIRTHDATE, 23) as BIRTHDATE,
								BR.NUMBER_OF_POSTS
							 from BLOG_USER BL inner join FRIEND F on BL.USER_LOGIN = F.USER_LOGIN
											   inner join BLOG_USER BR on BR.USER_LOGIN = F.FRIEND_LOGIN
							 where BL.USER_LOGIN = '{Models.User.CurrentUser.Login}'";
			var users = Database.Query.Select(query, connectionString);
			return new JsonResult(users);
		}

		[HttpGet("{stringToDetermineTabs}")]
		public JsonResult GetFriendApplications(string stringToDetermineTabs)
		{
			string query = $@"select 
								BL.USER_LOGIN, 
								BL.EMAIL, 
								BL.USERNAME, 
								coalesce(BL.PHOTO,0) as PHOTO, 
								convert(varchar(10), BL.BIRTHDATE, 23) as BIRTHDATE, 
								BL.NUMBER_OF_POSTS
							  from BLOG_USER BL inner join (select F.USER_LOGIN, F.FRIEND_LOGIN
															from FRIEND F
															where not exists (select *
																			  from FRIEND EF
																			  where F.USER_LOGIN = EF.FRIEND_LOGIN and 
																					F.FRIEND_LOGIN = EF.USER_LOGIN)) NEWF 
															on BL.USER_LOGIN = NEWF.USER_LOGIN
							  where NEWF.FRIEND_LOGIN = '{Models.User.CurrentUser.Login}';";
			var users = Database.Query.Select(query, connectionString);
			return new JsonResult(users);
		}
		
		private bool IsExistsFriendship(string login)
		{
			string query = $@"select top 1 
								case
									when exists (select * 
												 from FRIEND 
												 where USER_LOGIN = '{Models.User.CurrentUser.Login}' and 
													   FRIEND_LOGIN = '{login}') then 1
									else 0
								 end as IS_EXISTS
							   from THEME";
			var friendship = Database.Query.Select(query, connectionString);
			return friendship.Rows[0]["IS_EXISTS"].ToString() == "1";
		}

		[HttpPost]
		public JsonResult Post(User friend)
		{
			var user = Models.User.CurrentUser;

			string query = $@"
							insert into FRIEND
							(
							 USER_LOGIN,
							 FRIEND_LOGIN
							)
							values
							(
							 '{user.Login}',
							 '{friend.Login}'
							);";
			Database.Query.Insert(query, connectionString);
			return new JsonResult("Registration has been successfull");
		}

		[HttpDelete("{friendLogin}")]
		public JsonResult Delete(string friendLogin)
		{
			string query = $@"
							 delete from FRIEND
							 where USER_LOGIN = '{Models.User.CurrentUser.Login}' and FRIEND_LOGIN = '{friendLogin}';";
			Database.Query.Delete(query, connectionString);
			return new JsonResult("Account has been deleted successfully");
		}

		[HttpPut]
		public JsonResult Put(User friend)
		{
			if (IsExistsFriendship(friend.Login))
			{
				string query = $@"
							 delete from FRIEND
							 where USER_LOGIN = '{Models.User.CurrentUser.Login}' and 
								   FRIEND_LOGIN = '{friend.Login}';";
				Database.Query.Delete(query, connectionString);
			}
			else
			{
				string query = $@"
							insert into FRIEND
							(
							 USER_LOGIN,
							 FRIEND_LOGIN
							)
							values
							(
							 '{Models.User.CurrentUser.Login}',
							 '{friend.Login}'
							);";
				Database.Query.Insert(query, connectionString);
			}
			return new JsonResult("Friendship updated successfully");
		}
	}
}
