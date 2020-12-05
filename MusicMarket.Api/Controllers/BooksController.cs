using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicMarket.Api.DTO;
using MusicMarket.Api.Validators;
using MusicMarket.Core.Models;
using MusicMarket.Core.Services;

namespace MusicMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _musicService;
        private readonly IMapper _mapper;
        public BooksController(IBooksService musicService, IMapper mapper)
        {
            this._musicService = musicService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<BooksDTO>>> GetAllMusics()
        {
            var musics = await _musicService.GetAllWithArtist();
            var musicResources = _mapper.Map<IEnumerable<Books>, IEnumerable<BooksDTO>>(musics);

            return Ok(musicResources);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BooksDTO>> GetMusicById(int id)
        {
            var music = await _musicService.GetMusicById(id);
            var musicResource = _mapper.Map<Books, BooksDTO>(music);

            return Ok(musicResource);
        }
        [HttpPost("")]
        public async Task<ActionResult<BooksDTO>> CreateMusic([FromBody] SaveBooksDTo saveMusicResource)
        {
            var validator = new SaveMusicResourceValidator();
            var validationResult = await validator.ValidateAsync(saveMusicResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var musicToCreate = _mapper.Map<SaveBooksDTo, Books>(saveMusicResource);

            var newMusic = await _musicService.CreateMusic(musicToCreate);

            var music = await _musicService.GetMusicById(newMusic.Id);

            var musicResource = _mapper.Map<Books, BooksDTO>(music);

            return Ok(musicResource);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<BooksDTO>> UpdateMusic(int id, [FromBody] SaveBooksDTo saveMusicResource)
        {
            var validator = new SaveMusicResourceValidator();
            var validationResult = await validator.ValidateAsync(saveMusicResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var musicToBeUpdate = await _musicService.GetMusicById(id);

            if (musicToBeUpdate == null)
                return NotFound();

            var music = _mapper.Map<SaveBooksDTo, Books>(saveMusicResource);

            await _musicService.UpdateMusic(musicToBeUpdate, music);

            var updatedMusic = await _musicService.GetMusicById(id);
            var updatedMusicResource = _mapper.Map<Books, BooksDTO>(updatedMusic);

            return Ok(updatedMusicResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            if (id == 0)
                return BadRequest();

            var music = await _musicService.GetMusicById(id);

            if (music == null)
                return NotFound();

            await _musicService.DeleteMusic(music);

            return NoContent();
        }
    }
}