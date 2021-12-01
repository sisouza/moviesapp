namespace webapp.Models
{
    public class MoviesDatabaseSettings
    {
        public string MoviesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMoviesDatabaseSettings
    {
        string MoviesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}