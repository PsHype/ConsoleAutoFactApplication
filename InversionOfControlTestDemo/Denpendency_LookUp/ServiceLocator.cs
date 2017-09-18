namespace InversionOfControlTestDemo.Denpendency_LookUp
{
    public class ServiceLocator
    {
        private MovieFinder _movieFinder;

        public ServiceLocator(MovieFinder movieFinder)
        {
            _movieFinder = movieFinder;
        }

        private static ServiceLocator soleInstance;

        public static void load(ServiceLocator arg)
        {
            soleInstance = arg;
        }

        public static MovieFinder GetMoveFinder()
        {
            return soleInstance._movieFinder;
        }
    }
}