using Microsoft.EntityFrameworkCore;
using MusicMarket.Core.Models;
using MusicMarket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Data.Repositories
{
    public class WriterRepository : Repository<Writers>, IWritersRepository
    {
        public WriterRepository(BooksMarketDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Writers>> GetAllWithMusicsAsync()
        {
            return await MusicMarketDbContext.Artists
                .Include(a => a.Musics)
                .ToListAsync();
        }

        public Task<Writers> GetWithMusicsByIdAsync(int id)
        {
            return MusicMarketDbContext.Artists
                .Include(a => a.Musics)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private BooksMarketDbContext MusicMarketDbContext
        {
            get { return Context as BooksMarketDbContext; }
        }
    }
}
