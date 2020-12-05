﻿using MusicMarket.Core;
using MusicMarket.Core.Models;
using MusicMarket.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Services
{
    public class ArtistService : IWritersService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArtistService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Writers> CreateArtist(Writers newArtist)
        {
            await _unitOfWork.Artists
                .AddAsync(newArtist);

            return newArtist;
        }

        public async Task DeleteArtist(Writers artist)
        {
            _unitOfWork.Artists.Remove(artist);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Writers>> GetAllArtists()
        {
            return await _unitOfWork.Artists.GetAllAsync();
        }

        public async Task<Writers> GetArtistById(int id)
        {
            return await _unitOfWork.Artists.GetByIdAsync(id);
        }

        public async Task UpdateArtist(Writers artistToBeUpdated, Writers artist)
        {
            artistToBeUpdated.Name = artist.Name;

            await _unitOfWork.CommitAsync();
        }
    }

}
