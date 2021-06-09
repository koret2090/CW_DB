using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessComponent
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? Permissions { get; set; }
    }
}
