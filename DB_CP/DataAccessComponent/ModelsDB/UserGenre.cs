using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessComponent
{
    public partial class UserGenre
    {
        public int? UserId { get; set; }
        public int? GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual User User { get; set; }
    }
}
