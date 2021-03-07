using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LoyaltySoftware.Models;
using LoyaltySoftware.Pages.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoyaltySoftware.Pages.Login
{
    public class loginModel : PageModel
    {
        [BindProperty]
        public UserAccount UserAccount { get; set; }
        public string Message { get; set; }
        public string SessionID;


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            DBConnection dbstring = new DBConnection(); //creating an object from the class
            string DbConnection = dbstring.DbString(); //calling the method from the class
            Console.WriteLine(DbConnection);
            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            Console.WriteLine(UserAccount.username);
            Console.WriteLine(UserAccount.password);

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"SELECT id, username, password, user_role FROM User WHERE userID = @UID, username = @UName, password = @Pwd AND userRole = @URole";

                command.Parameters.AddWithValue("@UID", UserAccount.userID);
                command.Parameters.AddWithValue("@UName", UserAccount.username);
                command.Parameters.AddWithValue("@Pwd", UserAccount.password);
                command.Parameters.AddWithValue("@URole", UserAccount.userRole);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UserAccount.userID = reader.GetInt32(0);
                    UserAccount.username = reader.GetString(1);
                    UserAccount.password = reader.GetString(2);
                    UserAccount.userRole = reader.GetString(3);
                }

                if (!string.IsNullOrEmpty(UserAccount.userID.ToString()))
                {
                    SessionID = HttpContext.Session.Id;
                    HttpContext.Session.SetString("sessionID", SessionID);
                    HttpContext.Session.SetString("username", UserAccount.username);
                    HttpContext.Session.SetString("fname", UserAccount.password);

                    if (!UserAccount.checkIfUsernameExists(UserAccount.username))
                    {
                        Message = "Username does not exist!";
                        return Page();
                    }
                    else if (!UserAccount.checkPassword(UserAccount.username, UserAccount.password))
                    {
                        Message = "Password does not match!";
                        return Page();
                    }
                    else
                    {
                        if (UserAccount.checkRole(UserAccount.userRole) == "member")
                        {
                            return RedirectToPage("/MemberPages/Dashboard");
                        }
                        else
                        {
                            return RedirectToPage("/AdminPages/Dashboard");
                        }
                    }


                }
                else
                {
                    Message = "Username does not exist!";
                    return Page();
                }



            }
        }
    }
}
