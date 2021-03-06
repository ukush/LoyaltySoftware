﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltySoftware.Models
{
    
    public class UserAccount
    {
        public static int userID { get; set; }
        public static string username { get; set; }
        public static string password { get; set; }
        public static string status { get; set; }

        public static string userRole { get; set; }

        static string[] userRoles = new string[] { "member", "admin" };
        static string[] userStatuses = new string[] { "active", "suspended", "revoked" };
        public static Dictionary<string, string> accounts = new Dictionary<string, string>();

        public static void AddAccount(string username, string password)
        {
            if(!accounts.ContainsKey(username))
            {
                accounts.Add(username, password);
            }
            else
            {
                Console.WriteLine("Username already exists.");
            }
        }

        public static string checkRole(string userRole)
        {
            foreach(string possibleRole in userRoles)
            {
                if (userRole.ToLower() == possibleRole) return userRole;
            }
            return "Invalid role";
        }

        public static string checkStatus(string userStatus)
        {
            foreach (string possibleStatus in userStatuses)
            {
                if (userStatus.ToLower() == possibleStatus) return userStatus;
            }
            return "Invalid status";
        }

        public static bool checkIfUsernameExists(string username)
        {
            foreach(KeyValuePair<string, string> value in accounts)
            {
                if (username == value.Key) return true;
            }
            return false;
        }

        public static bool checkPassword(string username, string password)
        {
            foreach (KeyValuePair<string, string> value in accounts)
            {
                if (username == value.Key)
                    if (password == value.Value) return true;
            }
            return false;
        }
    }
}
