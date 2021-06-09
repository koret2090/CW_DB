using System;
using System.Collections.Generic;
#nullable disable

namespace DataAccessComponent
{
    public partial class Actor
    {
        public int ActorId { get; set; }
        public int? FilmId { get; set; }
        public string ActorName { get; set; }
        public int? Age { get; set; }
        public string Sex { get; set; }
        public string Nationality { get; set; }
        public int? Fee { get; set; }
        public int? Awards { get; set; }

        public virtual Film Film { get; set; }
    }
}
