using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Models
{
	public class User
	{
		public string Login { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string BirthDate { get; set; }
		public string Email { get; set; }
		public string AccountCreatingDate { get; set; }
		public int NumberOfPosts { get; set; }
		public int Photo { get; set; }
		public string Role { get; set; }

		public static User CurrentUser { get; set; }

		public static JsonResult GetCurrentUserInJson()
		{
			if (CurrentUser == null)
				return new JsonResult("null");
			return new JsonResult(CurrentUser);
		}

		public override string ToString()
		{
			return Login + " " + Password + " " + Name + " " + BirthDate;
		}
	}
}
