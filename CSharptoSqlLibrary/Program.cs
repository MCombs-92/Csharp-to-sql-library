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

			//	IEnumerable<User> users = UserCtrl.List();
			//	foreach (User user1 in users) { 
			//		Console.WriteLine($"{user1.FirstName} {user1.LastName}");
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

			//User user = UserCtrl.Get(5);
			//user.FirstName = "Harvy";
			//bool success = UserCtrl.Change(user);

			//user = UserCtrl.Get(10);
			//success = UserCtrl.Remove(user);

			//UserCtrl.CloseConection();




			VendorsController vendorctrl = new VendorsController(@"STUDENT12\SQLEXPRESS", "PRSDatabase");

			IEnumerable<Vendor> Vendors = vendorctrl.List();
				foreach (Vendor vendors in Vendors) {
					Console.WriteLine($"{vendors.Code} {vendors.Name}");
				}

			//Vendor newVendor = new Vendor();
			//newVendor.Code = "EGG"; //Must be a unique value
			//newVendor.Name = "New Egg";
			//newVendor.Address = "123 Main Street";
			//newVendor.City = "Cincinnati";
			//newVendor.State = "OH";
			//newVendor.Zip = "45002";
			//newVendor.Phone = "nani";
			//newVendor.Email = "nano";
			//newVendor.IsPreApproved = true;

			//bool success = vendorctrl.Create(newVendor);
			//Console.WriteLine($"New vendor successfully added = {success}");

			//Vendor vendor = vendorctrl.Get(2);
			//vendor.Code = "TAR";
			//success = vendorctrl.Change(vendor);

			Vendor vendordlt = vendorctrl.Get(12);
			bool deleted = vendorctrl.Remove(vendordlt);
			Console.WriteLine($"Vendor Successfully removed = {deleted}");


			
		}
	}
}
