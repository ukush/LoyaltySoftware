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
            string DbConnection = dbstring.DatabaseString(); //calling the method from the class
            Console.WriteLine(DbConnection);
            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            Console.WriteLine(UserAccount.Username);
            Console.WriteLine(UserAccount.Password);

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"SELECT id, username, password, user_role FROM UserAccount WHERE id = @UID, username = @UName, password = @Pwd AND user_role = @URole";

                command.Parameters.AddWithValue("@UID", UserAccount.UserID);
                command.Parameters.AddWithValue("@UName", UserAccount.Username);
                command.Parameters.AddWithValue("@Pwd", UserAccount.Password);
                command.Parameters.AddWithValue("@URole", UserAccount.UserRole);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UserAccount.UserID = reader.GetInt32(0);
                    UserAccount.Username = reader.GetString(1);
                    UserAccount.Password = reader.GetString(2);
                    UserAccount.UserRole = reader.GetString(3);
                }

                if (!string.IsNullOrEmpty(UserAccount.UserID.ToString()))
                {
                    SessionID = HttpContext.Session.Id;
                    HttpContext.Session.SetString("sessionID", SessionID);
                    HttpContext.Session.SetString("username", UserAccount.Username);
                    HttpContext.Session.SetString("password", UserAccount.Password);

                    if (!UserAccount.checkIfUsernameExists(UserAccount.Username))
                    {
                        Message = "Username does not exist!";
                        return Page();
                    }
                    else if (!UserAccount.checkPassword(UserAccount.Username, UserAccount.Password))
                    {
                        Message = "Password does not match!";
                        return Page();
                    }
                    else
                    {
                        if (UserAccount.checkRole(UserAccount.UserRole) == "member")
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

