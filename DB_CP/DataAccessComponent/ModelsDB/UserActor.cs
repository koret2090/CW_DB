using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace DataAccessComponent
{
    [Keyless]
    public partial class UserActor
    {
        public int? UserId { get; set; }
        public int? ActorId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual User User { get; set; }
    }
}
