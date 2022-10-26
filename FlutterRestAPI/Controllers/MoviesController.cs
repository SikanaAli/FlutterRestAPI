using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlutterRestAPI.Services;
using FlutterRestAPI.Models;


namespace FlutterRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly MoviesDBService _moviesDBService;

        public MoviesController(MoviesDBService moviesDBService)
        {
            _moviesDBService = moviesDBService;
        }


        // GET: api/Movies
        [HttpGet]
        public async Task<List<Movie>> Get() =>
            await _moviesDBService.GetMoviesAsync();

        // GET: api/Movies/5
        [HttpGet("{id:length(24)}", Name = "Get")]
        public async Task<ActionResult<Movie>> Get(string id)
        {
            var _movie = await _moviesDBService.GetMoviesAsync(id);

            if(_movie is null)
            {
                return NoContent();
            }

            return _movie;
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Movie MovieToAdd)
        {
            await _moviesDBService.CreateAsync(MovieToAdd);

            return CreatedAtAction(nameof(Get), new { id = MovieToAdd.Id }, MovieToAdd);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Movie updateMovie)
        {
            var _movie = await _moviesDBService.GetMoviesAsync(id);

            if (_movie is null)
            {
                return NoContent();
            }

            updateMovie.Id = _movie.Id;
            await _moviesDBService.UpdateAsync(id, updateMovie);
            return NoContent();
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var _movie = await _moviesDBService.GetMoviesAsync(id);

            if (_movie is null)
            {
                return NoContent();
            }

            await _moviesDBService.RemoveAsync(id);
            return NoContent();
        }
    }
}
