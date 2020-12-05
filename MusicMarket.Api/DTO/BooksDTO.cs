using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicMarket.Api.DTO
{
    public class BooksDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WritersDTO Writers { get; set; }
    }
}
