using Autofac;

namespace ConsoleAutoFactApplication
{
    public class Program
    {
        public static IContainer Container { get; set; }

        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
        }
    }
}