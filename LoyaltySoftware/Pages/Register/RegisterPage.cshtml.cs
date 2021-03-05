using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LoyaltySoftware.Database_Connection;
using LoyaltySoftware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoyaltySoftware.Pages.Register
{
    public class registerModel : PageModel
    {
        public List<string> user_role = new List<string> { "admin", "member" };
        public List<string> status = new List<string> { "active", "suspended", "revoked" };

        [BindProperty]
        public User UserRecord { get; set; }

        [BindProperty]
        public Address AddressRecord { get; set; }

        [BindProperty]
        public UserAccount UserAccountRecord { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string DbConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Uwais\Downloads\LoyaltySoftware-database\LoyaltySoftware-database\LoyaltySoftware\Database\;Integrated Security=True;Connect Timeout=30";

            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;


                command.CommandText = @"INSERT INTO address (address_id, country, county, street_name, street_number, postcode) VALUES (@aid, @cntry, @cnty, @srt, @srtnum, @pcode)";

                command.Parameters.AddWithValue("@aid", AddressRecord.addressId);
                command.Parameters.AddWithValue("@cntry", AddressRecord.country);
                command.Parameters.AddWithValue("@cnty", AddressRecord.county);
                command.Parameters.AddWithValue("@srt", AddressRecord.street_name);
                command.Parameters.AddWithValue("@srtnum", AddressRecord.street_number);
                command.Parameters.AddWithValue("@pcode", AddressRecord.postcode);


                Console.WriteLine(AddressRecord.addressId);
                Console.WriteLine(AddressRecord.country);
                Console.WriteLine(AddressRecord.county);
                Console.WriteLine(AddressRecord.street_name);
                Console.WriteLine(AddressRecord.street_number);
                Console.WriteLine(AddressRecord.postcode);

                command.CommandText = @"INSERT INTO user (user_id, irst_name, last_name, dob, email, telephone, creation_timestamp points, ) VALUES (@id, @fname, @lname, @dob, @email, @phone, @time @points)";

                command.Parameters.AddWithValue("@id", 1);
                command.Parameters.AddWithValue("@fname", UserRecord.first_name);
                command.Parameters.AddWithValue("@lname", UserRecord.last_name);
                command.Parameters.AddWithValue("@dob", UserRecord.dob);
                command.Parameters.AddWithValue("@email", UserRecord.email);
                command.Parameters.AddWithValue("@phone", UserRecord.telephone);
                command.Parameters.AddWithValue("@time", UserRecord.creation_timestamp);
                command.Parameters.AddWithValue("@points", 0);


                Console.WriteLine(UserRecord.first_name);
                Console.WriteLine(UserRecord.last_name);
                Console.WriteLine(UserRecord.dob);
                Console.WriteLine(UserRecord.email);
                Console.WriteLine(UserRecord.telephone);
                Console.WriteLine(UserRecord.points);


                command.CommandText = @"INSERT INTO useraccount (username, password, status, user_role, user_id ) VALUES (@uname, @pword, @sts, @urole, @uid)";

                command.Parameters.AddWithValue("@uname", UserAccountRecord.username);
                command.Parameters.AddWithValue("@pword", UserAccountRecord.password);
                command.Parameters.AddWithValue("@sts", "active");
                command.Parameters.AddWithValue("@urole", UserAccountRecord.user_role);
                command.Parameters.AddWithValue("@srtnum", UserRecord.user_id);


                Console.WriteLine(UserAccountRecord.username);
                Console.WriteLine(UserAccountRecord.password);
                Console.WriteLine("active");
                Console.WriteLine(UserAccountRecord.user_role);
                Console.WriteLine( UserRecord.user_id);


                command.ExecuteNonQuery();
            }



            return RedirectToPage("/Index");
        }
    }
}
