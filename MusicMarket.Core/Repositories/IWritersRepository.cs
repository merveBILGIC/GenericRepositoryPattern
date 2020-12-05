using MusicMarket.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Core.Repositories
{
    public interface IWritersRepository : IRepository<Writers>
    {
        Task<IEnumerable<Writers>> GetAllWithMusicsAsync();
        Task<Writers> GetWithMusicsByIdAsync(int id);
    }
}
