using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessComponent
{
    public partial class Genre
    {
        public Genre()
        {
            Films = new HashSet<Film>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}
