using System.Collections.Generic;

namespace InversionOfControlTestDemo
{
    public class MovieFindService
    {
        private readonly MovieFinder _movieFinder;

        public MovieFindService()
        {
            _movieFinder = new TxtFileMovieFinder("C://movies.txt");
        }

        public List<Movie> GetMoviesDirectedBy(string directorName)
        {
            List<Movie> allMovies = _movieFinder.findAll();
            var directorMovies = new List<Movie>();
            foreach (var movie in allMovies)
            {
                if (movie.Director.Equals(directorName))
                {
                    directorMovies.Add(movie);
                }
            }
            return directorMovies;
        }
    }
}