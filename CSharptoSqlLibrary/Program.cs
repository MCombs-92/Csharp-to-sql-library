using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLibrary;

namespace CSharptoSqlLibrary {
	class Program {
		static void Main(string[] args) {

			UsersController UserCtrl = new SqlLibrary.UsersController(@"STUDENT12\SQLEXPRESS", "PRSDatabase");

			//IEnumerable<User> users = UserCtrl.List();
			//foreach(User user1 in users) {
			//	Console.WriteLine($"{user1.FirstName} {user1.LastName}");
			//}

			//User user = UserCtrl.Get(5);
			//if(user == null) {
			//	Console.WriteLine("User not found");
			//} else {
			//	Console.WriteLine($"{user.FirstName} {user.LastName}");

			//}

			//user = UserCtrl.Get(999);
			//if (user == null) {
			//	Console.WriteLine("User not found");
			//} else {
			//	Console.WriteLine($"{user.FirstName} {user.LastName}");
			//}

			//User newUser = new User();
			//newUser.Username = "newUSer9999"; ;
			//newUser.Password = "Paassw0rddd";
			//newUser.FirstName = "Last";
			//newUser.LastName = "first";
			//newUser.Phone = "513-555-0000";
			//newUser.Email = "newuser@gmail";
			//newUser.IsReviewer = true;
			//newUser.IsAdmin = true;
			//newUser.Active = true;

			//bool success = UserCtrl.Create(newUser);

			User user = UserCtrl.Get(5);
			user.FirstName = "Harvy";
			bool success = UserCtrl.Change(user);

			user = UserCtrl.Get(10);
			success = UserCtrl.Remove(user);

			UserCtrl.CloseConection();
		}
	}
}
