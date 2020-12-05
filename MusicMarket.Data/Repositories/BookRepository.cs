using Microsoft.EntityFrameworkCore;
using MusicMarket.Core.Models;
using MusicMarket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Data.Repositories
{
    public class BookRepository : Repository<Books>, IBooksRepository
    {
        public BookRepository(BooksMarketDbContext context)
             : base(context)
        { }

        public async Task<IEnumerable<Books>> GetAllWithArtistAsync()
        {
            return await MusicMarketDbContext.Musics
                .Include(m => m.Artist)
                .ToListAsync();
        }

        public async Task<Books> GetWithArtistByIdAsync(int id)
        {
            return await MusicMarketDbContext.Musics
                .Include(m => m.Artist)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        public async Task<IEnumerable<Books>> GetAllWithArtistByArtistIdAsync(int artistId)
        {
            return await MusicMarketDbContext.Musics
                .Include(m => m.Artist)
                .Where(m => m.ArtistId == artistId)
                .ToListAsync();
        }

        private BooksMarketDbContext MusicMarketDbContext
        {
            get { return Context as BooksMarketDbContext; }
        }
    }
}
