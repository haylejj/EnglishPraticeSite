using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class FavoriteDto
    {
        public int Id { get; set; }
        public string? EnglishWord { get; set; }
        public string? TurkishWord { get; set; }
    }
}
