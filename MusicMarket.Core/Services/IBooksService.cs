using MusicMarket.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Core.Services
{
    public interface IBooksService
    {
        Task<IEnumerable<Books>> GetAllWithArtist();
        Task<Books> GetMusicById(int id);
        Task<IEnumerable<Books>> GetMusicsByArtistId(int artistId);
        Task<Books> CreateMusic(Books newMusic);
        Task UpdateMusic(Books musicToBeUpdated, Books music);
        Task DeleteMusic(Books music);
    }
}
