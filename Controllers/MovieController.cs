using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using moviesapp.Services;
using webapp.Models;

namespace moviesapp.Controllers
{
    public class MovieController
    {
        [Route("api/[controller]")]
        [ApiController]

        public class MoviesController : ControllerBase
        {
            private readonly MovieService _movieService;

            public MoviesController(MovieService movieService)
            {
                _movieService = movieService;
            }

            [HttpGet]
            public async Task<ActionResult<List<Movie>>> Get()
            {
                try
                {
                    var findMovies = await _movieService.Get();

                    return Ok(findMovies);
                }
                catch (Exception error)
                {
                    return NotFound(new
                    {
                        error = error.Message

                    });
                }

            }


            [HttpGet("{id}", Name = "GetMovie")]
            public async Task<ActionResult<Movie>> Get(string id)
            {
                try
                {
                    var movie = await _movieService.GetById(id);

                    return Ok(movie);

                }
                catch (Exception error)
                {

                    return NotFound(
                        new
                        {
                            error = error.Message
                        }
                    );
                }

            }

            [HttpPost]
            public async Task<ActionResult<Movie>> Create(Movie movie)
            {
                try
                {
                    var newMovie = await _movieService.Create(movie);

                    return Ok( new {newMovie});
                }
                catch (Exception error)
                {
                    return NotFound(new
                        {
                            error = error.Message
                        }
                    );
                }
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<bool>> Update(string id, Movie movie)
            {
                try
                {
                    var editMovie = await _movieService.Update(id, movie);

                    return Ok(new
                        {
                            Message = "Movie Updated"
                        }
                    );
                }
                catch (Exception error)
                {
                    return NotFound(new
                        {
                            error = error.Message
                        }
                    );
                }
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<bool>> Delete(string id)
            {
                try
                {
                    var deleteMovie = await _movieService.Remove(id);

                    return Ok( new { deleteMovie});
                }
                catch (Exception error)
                {
                    return NotFound(new
                    {
                        error = error.Message
                    });
                }
            }
        }
    }
}