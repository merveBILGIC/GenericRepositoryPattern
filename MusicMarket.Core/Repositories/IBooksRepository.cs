using MusicMarket.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Core.Repositories
{
    public interface IBooksRepository : IRepository<Books>
    {
        Task<IEnumerable<Books>> GetAllWithArtistAsync();
        Task<Books> GetWithArtistByIdAsync(int id);
        Task<IEnumerable<Books>> GetAllWithArtistByArtistIdAsync(int artistId);
    }
}
