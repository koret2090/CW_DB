using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessComponent
{
    public enum Permission : int
    {
        Guest,
        User,
        Admin
    }
    public class Connection
    {
        public static string GetConnection(int perms, IConfiguration config)
        {
            if (perms == (int)Permission.Guest)
            {
                return config["Connections:ConnectGuest"];
            }
            else if (perms == (int)Permission.User)
            {
                return config["Connections:ConnectUser"];
            }
            else
            {
                return config["Connections:ConnectAdmin"];
            }

        }
    }
}
