using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessComponent
{
    public partial class Director
    {
        public Director()
        {
            Films = new HashSet<Film>();
        }

        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
        public int? Age { get; set; }
        public string Sex { get; set; }
        public int? FilmsAmount { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}
