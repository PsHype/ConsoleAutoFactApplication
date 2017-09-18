using System.Collections.Generic;

namespace InversionOfControlTestDemo.Denpendency_Injection
{
    public class AutoFactMovieFindService
    {
        private readonly MovieFinder _movieFinder;

        public AutoFactMovieFindService(MovieFinder movieFinder)
        {
            _movieFinder = movieFinder;
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