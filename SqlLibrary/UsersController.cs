using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary {
	public class UsersController {

		SqlConnection conn = null;
		SqlCommand cmd = new SqlCommand();

		public UsersController () { 

		}

		private void SetupCommand(SqlConnection conn, string sql) {
			cmd.Connection = conn;
			cmd.CommandText = sql;
			cmd.Parameters.Clear();
		}

		public IEnumerable<User> List() {
			string sql = "select * from [user];";
			SetupCommand(conn, sql);
			SqlDataReader reader = cmd.ExecuteReader();
			List<User> users = new List<User>();
			while(reader.Read()) {
				User user = new User(reader);
				users.Add(user);
			}
			reader.Close();
			return users;
		}

		public User Get(int id) {
			string sql = "select * from [user] where Id = @id";
			SetupCommand(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@id", id));
			SqlDataReader reader = cmd.ExecuteReader();
			if(reader.HasRows == false) {
				reader.Close();
				return null;
			}
			reader.Read();
			User user = new User(reader);
			reader.Close();
			return user;
		}

		public bool Create(User user) {
			string sql = "Insert into [user] "
				+ "(Username, Password, Firstname, Lastname, Phone, Email, IsReviewer, IsAdmin) "
				+ "values "
				+ "(@Username, @Password, @Firstname, @Lastname, @Phone, @Email, @IsReviewer, @IsAdmin)";
			SetupCommand(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@Username", user.Username));
			cmd.Parameters.Add(new SqlParameter("@Password", user.Password));
			cmd.Parameters.Add(new SqlParameter("@Firstname", user.FirstName));
			cmd.Parameters.Add(new SqlParameter("@Lastname", user.LastName));
			cmd.Parameters.Add(new SqlParameter("@Phone", user.Phone));
			cmd.Parameters.Add(new SqlParameter("@Email", user.Email));
			cmd.Parameters.Add(new SqlParameter("@IsReviewer", user.IsReviewer));
			cmd.Parameters.Add(new SqlParameter("@IsAdmin", user.IsAdmin));
			int RecsAffected = cmd.ExecuteNonQuery();
			return (RecsAffected == 1);
		}

		public bool Change(User user) {
			string sql = "update [user] set "
				+ "Username = @Username, "
				+ "Password = @Password, "
				+ "Firstname = @Firstname, "
				+ "Lastname = @Lastname, "
				+ "Phone = @Phone, "
				+ "Email = @Email, "
				+ "IsReviewer= @IsReviewer, "
				+ "IsAdmin = @IsAdmin, "
				+ "Active = @Active "
				+ "Where Id = @Id ";

			SetupCommand(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@Id", user.Id));
			cmd.Parameters.Add(new SqlParameter("@Username", user.Username));
			cmd.Parameters.Add(new SqlParameter("@Password", user.Password));
			cmd.Parameters.Add(new SqlParameter("@Firstname", user.FirstName));
			cmd.Parameters.Add(new SqlParameter("@Lastname", user.LastName));
			cmd.Parameters.Add(new SqlParameter("@Phone", user.Phone));
			cmd.Parameters.Add(new SqlParameter("@Email", user.Email));
			cmd.Parameters.Add(new SqlParameter("@IsReviewer", user.IsReviewer));
			cmd.Parameters.Add(new SqlParameter("@IsAdmin", user.IsAdmin));
			cmd.Parameters.Add(new SqlParameter("@Active", user.Active));
			int RecsAffected = cmd.ExecuteNonQuery();
			return (RecsAffected == 1);
		}

		public bool Remove(User user) {
			string sql = "Delete from [user] where Id = @Id";
			SetupCommand(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@Id", user.Id));
			int RecsAffected = cmd.ExecuteNonQuery();
			return (RecsAffected == 1);
		}

		private SqlConnection CreateandOpenConnection(string server, string database) {
			string connStr = $"server={server};database={database};Trusted_Connection=true;";
			SqlConnection conn = new SqlConnection(connStr);
			conn.Open();
			if(conn.State != System.Data.ConnectionState.Open) {
				throw new ApplicationException("Sql connection is borked");
			}
			return conn;
		}

		public void CloseConection() {
			if(conn != null && conn.State == System.Data.ConnectionState.Open) {
				conn.Close();
			}
		}

		public UsersController(string server, string database) {
			conn = CreateandOpenConnection(server, database);
		}
	}
}
