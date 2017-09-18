using System.Collections.Generic;

namespace InversionOfControlTestDemo.Denpendency_Injection
{
    //    依赖注入的最大好处在于：它消除了MovieFinder类对具体MovieFinder实现类的依赖
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