using MusicMarket.Core;
using MusicMarket.Core.Models;
using MusicMarket.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Services
{
    public class MusicService : IBooksService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MusicService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Books> CreateMusic(Books newMusic)
        {
            await _unitOfWork.Musics.AddAsync(newMusic);
            await _unitOfWork.CommitAsync();
            return newMusic;
        }

        public async Task DeleteMusic(Books music)
        {
            _unitOfWork.Musics.Remove(music);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Books>> GetAllWithArtist()
        {
            return await _unitOfWork.Musics
                .GetAllWithArtistAsync();
        }

        public async Task<Books> GetMusicById(int id)
        {
            return await _unitOfWork.Musics
                .GetWithArtistByIdAsync(id);
        }

        public async Task<IEnumerable<Books>> GetMusicsByArtistId(int artistId)
        {
            return await _unitOfWork.Musics
                .GetAllWithArtistByArtistIdAsync(artistId);
        }

        public async Task UpdateMusic(Books musicToBeUpdated, Books music)
        {
            musicToBeUpdated.Name = music.Name;
            musicToBeUpdated.ArtistId = music.ArtistId;

            await _unitOfWork.CommitAsync();
        }
    }
}
