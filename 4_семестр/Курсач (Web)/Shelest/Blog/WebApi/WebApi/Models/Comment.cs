﻿namespace WebApi.Models
{
	public class Comment
	{
		public string ID { get; set; }
		public string Text { get; set; }
		public User Author { get; set; }
		public Post Post { get; set; }
	}
}
