using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary{
	public class User {

		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public bool IsReviewer { get; set; }
		public bool IsAdmin { get; set; }
		public bool Active { get; set; }

		public User() {

		}

		public User(SqlDataReader reader) {
			Id = reader.GetInt32(reader.GetOrdinal("Id"));
			Username = reader.GetString(reader.GetOrdinal("Username"));
			Password = reader.GetString(reader.GetOrdinal("Password"));
			FirstName = reader.GetString(reader.GetOrdinal("Firstname"));
			LastName = reader.GetString(reader.GetOrdinal("Lastname"));
			Phone = reader.GetString(reader.GetOrdinal("Phone"));
			Email = reader.GetString(reader.GetOrdinal("Email"));
			IsReviewer = reader.GetBoolean(reader.GetOrdinal("IsReviewer"));
			IsAdmin = reader.GetBoolean(reader.GetOrdinal("IsAdmin"));
			Active = reader.GetBoolean(reader.GetOrdinal("Active"));
		}
	}
}
