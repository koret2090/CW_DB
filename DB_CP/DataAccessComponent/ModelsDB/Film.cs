using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessComponent
{
    public partial class Film
    {
        public Film()
        {
            Actors = new HashSet<Actor>();
        }

        public int FilmId { get; set; }
        public int? StudioId { get; set; }
        public int? GenreId { get; set; }
        public int? DirectorId { get; set; }
        public string FilmName { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? Budget { get; set; }
        public int? Fees { get; set; }
        public int? AvgPrice { get; set; }

        public virtual Director Director { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Studio Studio { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
    }
}
