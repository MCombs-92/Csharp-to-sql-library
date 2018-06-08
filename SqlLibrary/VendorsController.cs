using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary {
	public class VendorsController {

		SqlConnection conn = null;
		SqlCommand cmd = new SqlCommand();

		public VendorsController() {

		}

		private void SetupCommand(SqlConnection conn, string sql) {
			cmd.Connection = conn;
			cmd.CommandText = sql;
			cmd.Parameters.Clear();
		}

		public IEnumerable<Vendor> List() {
			string sql = "select * from [Vendor];";
			SetupCommand(conn, sql);
			SqlDataReader reader = cmd.ExecuteReader();
			List<Vendor> Vendors = new List<Vendor>();
			while (reader.Read()) {
				Vendor Vendor = new Vendor(reader);
				Vendors.Add(Vendor);
			}
			reader.Close();
			return Vendors;
		}

		public Vendor Get(int id) {
			string sql = "select * from [Vendor] where Id = @Id";
			SetupCommand(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@Id", id));
			SqlDataReader reader = cmd.ExecuteReader();
			if (reader.HasRows == false) {
				reader.Close();
				return null;
			}
			reader.Read();
			Vendor Vendor = new Vendor(reader);
			reader.Close();
			return Vendor;
		}

		public bool Create(Vendor Vendor) {
			string sql = "Insert into [vendor] "
				+ "(code, name, address, city, state, zip, phone, email, ispreapproved) "
				+ "values "
				+ "(@code, @name, @address, @city, @state, @zip, @phone, @email, @ispreapproved) ";
			SetupCommand(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@code", Vendor.Code));
			cmd.Parameters.Add(new SqlParameter("@name", Vendor.Name));
			cmd.Parameters.Add(new SqlParameter("@address", Vendor.Address));
			cmd.Parameters.Add(new SqlParameter("@city", Vendor.City));
			cmd.Parameters.Add(new SqlParameter("@state", Vendor.State));
			cmd.Parameters.Add(new SqlParameter("@zip", Vendor.Zip));
			cmd.Parameters.Add(new SqlParameter("@phone", Vendor.Phone));
			cmd.Parameters.Add(new SqlParameter("@email", Vendor.Email));
			cmd.Parameters.Add(new SqlParameter("@ispreapproved", Vendor.IsPreApproved));
			int RecsAffected = cmd.ExecuteNonQuery();
			return (RecsAffected == 1);
		}

		public bool Change(Vendor Vendor) {
			string sql = "update [vendor] set "
				+ "code = @code, "
				+ "name = @name, "
				+ "address = @address, "
				+ "city = @city, "
				+ "state = @state, "
				+ "zip = @zip, "
				+ "phone = @phone, "
				+ "email = @email, "
				+ "ispreapproved = @ispreapproved, "
				+ "active = @active "
				+ "where id = @id ";
			SetupCommand(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@id", Vendor.Id));
			cmd.Parameters.Add(new SqlParameter("@code", Vendor.Code));
			cmd.Parameters.Add(new SqlParameter("@name", Vendor.Name));
			cmd.Parameters.Add(new SqlParameter("@address", Vendor.Address));
			cmd.Parameters.Add(new SqlParameter("@city", Vendor.City));
			cmd.Parameters.Add(new SqlParameter("@state", Vendor.State));
			cmd.Parameters.Add(new SqlParameter("@zip", Vendor.Zip));
			cmd.Parameters.Add(new SqlParameter("@phone", Vendor.Phone));
			cmd.Parameters.Add(new SqlParameter("@email", Vendor.Email));
			cmd.Parameters.Add(new SqlParameter("@ispreapproved", Vendor.IsPreApproved));
			cmd.Parameters.Add(new SqlParameter("@active", Vendor.Active));
			int RecsAffected = cmd.ExecuteNonQuery();
			return (RecsAffected == 1);
		}

		public bool Remove(Vendor Vendor) {
			string sql = "delete from [vendor] where id = @id ";
			SetupCommand(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@id", Vendor.Id));
			int RecsAffected = cmd.ExecuteNonQuery();
			return (RecsAffected == 1);
		}

		private SqlConnection CreateandOpenConnection(string server, string database) {
			string connStr = $"server={server};database={database};Trusted_Connection=true;";
			SqlConnection conn = new SqlConnection(connStr);
			conn.Open();
			if (conn.State != System.Data.ConnectionState.Open) {
				throw new ApplicationException("Sql connection is borked");
			}
			return conn;
		}

		public void CloseConection() {
			if (conn != null && conn.State == System.Data.ConnectionState.Open) {
				conn.Close();
			}
		}

		public VendorsController(string server, string database) {
			conn = CreateandOpenConnection(server, database);
		}
	}
}
