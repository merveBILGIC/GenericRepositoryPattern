using System;
using System.Collections.Generic;
using System.Text;

namespace MusicMarket.Core.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public Writers Artist { get; set; }
    }
}
