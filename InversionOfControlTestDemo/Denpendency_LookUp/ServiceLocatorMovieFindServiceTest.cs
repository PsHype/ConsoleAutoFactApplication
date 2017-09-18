using Xunit;

namespace InversionOfControlTestDemo.Denpendency_LookUp
{
    public class ServiceLocatorMovieFindServiceTest
    {
        //无论如何换find，我的ServiceLocatorMovieFindService服务内部是不需要变更代码的,因为把finder的控制权反转出去了
        [Fact]
        public void Service_locator_TxtFileMovieFinder_Test()
        {
            ServiceLocator.load(new ServiceLocator(new TxtFileMovieFinder("C://")));
            
            var movies = new ServiceLocatorMovieFindService().GetMoviesDirectedBy("斯皮尔伯格");
            Assert.Equal(1, movies.Count);
            Assert.Equal("斯皮尔伯格", movies[0].Director);
        }
    }
}