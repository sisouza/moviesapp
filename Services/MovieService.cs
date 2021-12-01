using MongoDB.Driver;
using webapp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace moviesapp.Services
{
    public class MovieService
    {
        private readonly IMongoCollection<Movie> _movies;

        public MovieService(IMoviesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _movies = database.GetCollection<Movie>(settings.MoviesCollectionName);
        }

        public async Task<List<Movie>> Get()
        {
            var findMovie = await _movies.FindAsync(movie => true);
            var movies = await findMovie.ToListAsync();
            return movies;
        }


        public async Task<Movie> GetById(string id)
        {
            var findMovie = await _movies.FindAsync<Movie>(movie => movie.Id == id);
            var result = await findMovie.FirstOrDefaultAsync();
            return result;
        }


        public async Task<Movie> Create(Movie movie)
        {
            var movieExits = await _movies.FindAsync<Movie>(movie => true);

            if (movieExits != null)
            {
                return null;
            }

            await _movies.InsertOneAsync(movie);
            return movie;
        }

        public async Task<bool> Update(string id, Movie movieData)
        {
            var movieExits = await _movies.FindAsync<Movie>(movie => movie.Id == id);

            if (movieExits == null)
            {
                return false;
            }

            var result = await _movies.ReplaceOneAsync(movie => movie.Id == id, movieData);
            return true;

        }

        public async Task<bool> Remove(string id)
        {
            var movieExits = await _movies.FindAsync<Movie>(movie => movie.Id == id);

            if (movieExits == null)
            {
                return false;
            }

            var deleteMovie = await _movies.DeleteOneAsync(id);
            return true;
        }


    }
}