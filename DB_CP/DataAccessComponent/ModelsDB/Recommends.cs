using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessComponent
{
    [Keyless]
    public class Recommends
    {
        public string film_name { get; set; }
        public DateTime? release_date { get; set; }
        public int budget { get; set; }
        public int fees { get; set; }
        public int avg_price { get; set; }
    }
}
