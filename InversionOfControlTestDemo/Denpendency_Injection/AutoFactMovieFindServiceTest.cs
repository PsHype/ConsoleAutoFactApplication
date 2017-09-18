using Autofac;
using Xunit;

namespace InversionOfControlTestDemo.Denpendency_Injection
{
    public class AutoFactMovieFindServiceTest
    {
        //无论如何换find，我的AutoFactMovieFindService服务内部是不需要变更代码的,因为把finder的控制权反转出去了
        [Fact]
        public void Dependency_Inject_TxtFileMovieFinder_Test()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Register(c => new AutoFactMovieFindService(new TxtFileMovieFinder("C://")));
            var container = builder.Build();

            var movieFindService = container.Resolve<AutoFactMovieFindService>();
            var movies = movieFindService.GetMoviesDirectedBy("斯皮尔伯格");
            Assert.Equal(1, movies.Count);
            Assert.Equal("斯皮尔伯格", movies[0].Director);
        }
        
        [Fact]
        public void Dependency_Inject_HashSetMovieFind_Test()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Register(c => new AutoFactMovieFindService(new HashSetMovieFind()));
            var container = builder.Build();

            var movieFindService = container.Resolve<AutoFactMovieFindService>();
            var movies = movieFindService.GetMoviesDirectedBy("斯皮尔伯格");
            Assert.Equal(1, movies.Count);
            Assert.Equal("斯皮尔伯格", movies[0].Director);
        }
    }
}