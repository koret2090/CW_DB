using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessComponent
{
    public partial class Studio
    {
        public Studio()
        {
            Films = new HashSet<Film>();
        }

        public int StudioId { get; set; }
        public string StudioName { get; set; }
        public DateTime? DateOfCreation { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}
