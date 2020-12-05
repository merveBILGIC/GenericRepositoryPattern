using MusicMarket.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Core.Services
{
    public interface IWritersService
    {
        Task<IEnumerable<Writers>> GetAllWriters();
        Task<Writers> GetWritersById(int id);
        Task<Writers> CreateArtist(Writers newWriters);
        Task UpdateWriters(Writers writersToBeUpdated, Writers writers);
        Task DeleteWriters(Writers writers);
    }
}
