namespace WebApi.Models
{
	public class Post
	{
		public string ID { get; set; }
		public string Theme { get; set; }
		public string Text { get; set; }
		public User Author { get; set; }
		public string PostingDate { get; set; }
	}
}
