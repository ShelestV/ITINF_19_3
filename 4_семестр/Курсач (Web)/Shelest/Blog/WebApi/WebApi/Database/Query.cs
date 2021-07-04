using System.Data;
using System.Data.SqlClient;

namespace WebApi.Database
{
	public class Query
	{
		public static DataTable Select(string query, string connectionString)
		{
			var table = new DataTable();
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (var command = new SqlCommand(query, connection))
				{
					var reader = command.ExecuteReader();
					table.Load(reader);
				}
			}
			return table;
		}

		public static void Insert(string query, string connectionString)
		{
			ExecuteNonSelectQuery(query, connectionString);
		}

		public static void Delete(string query, string connectionString)
		{
			ExecuteNonSelectQuery(query, connectionString);
		}

		public static void Update(string query, string connectionString)
		{
			ExecuteNonSelectQuery(query, connectionString);
		}

		private static void ExecuteNonSelectQuery(string query, string connectionString)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (var command = new SqlCommand(query, connection))
				{
					command.ExecuteReader();
				}
			}
		}
	}
}
