using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MusicMarket.Core.Models
{
    public class Writers
    {
        public Writers()
        {
            Musics = new Collection<Books>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Books> Musics { get; set; }
    }
}
