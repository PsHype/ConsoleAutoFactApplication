using System;
using System.Collections.Generic;

namespace InversionOfControlTestDemo
{
    public class TxtFileMovieFinder : MovieFinder
    {
        private readonly string _path;

        public TxtFileMovieFinder(string path)
        {
            this._path = path;
        }

        public List<Movie> findAll()
        {
            // read file by path
            Console.Write(_path);
            var movies = new List<Movie>();
            movies.Add(new Movie("斯皮尔伯格", "阿凡达"));
            return movies;
        }
    }
}