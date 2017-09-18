namespace InversionOfControlTestDemo
{
    public class Movie
    {
        public string Name { get; }
        public string Director { get; }

        public Movie(string director, string name)
        {
            Director = director;
            Name = name;
        }
    }
}