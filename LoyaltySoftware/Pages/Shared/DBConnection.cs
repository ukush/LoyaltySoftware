using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltySoftware.Pages.Shared
{
    public class DBConnection
    {
        public string DbString()
        {
            string dbString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LoyaltySystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return dbString;
        }
    }
}
