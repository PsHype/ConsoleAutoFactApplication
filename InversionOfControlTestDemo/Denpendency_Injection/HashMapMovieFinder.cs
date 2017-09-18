using System.Collections.Generic;
using System.Linq;

namespace InversionOfControlTestDemo.Denpendency_Injection
{
    public class HashSetMovieFind : MovieFinder
    {
        private HashSet<Movie> _movies = new HashSet<Movie>();

        public HashSetMovieFind()
        {
            _movies.Add(new Movie("斯皮尔伯格", "阿凡达"));
        }

        public List<Movie> findAll()
        {
            return _movies.ToList();
        }
    }
}