using System.Collections.Generic;

namespace InversionOfControlTestDemo.Denpendency_LookUp
{

    public class ServiceLocatorMovieFindService
    {
        public List<Movie> GetMoviesDirectedBy(string directorName)
        {
            List<Movie> allMovies = ServiceLocator.GetMoveFinder().findAll();
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