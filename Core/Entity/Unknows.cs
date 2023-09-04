using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Unknows
    {
        public int Id { get; set; }
        public string? EnglishWord { get; set; }
        public string? TurkishWord { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
