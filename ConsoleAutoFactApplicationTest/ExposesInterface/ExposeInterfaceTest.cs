using Autofac;
using Autofac.Core.Registration;
using ConsoleAutoFactApplication;
using ConsoleAutoFactApplication.OutputImpl;
using Xunit;

namespace ConsoleAutoFactApplicationTest.ExposesInterface
{
    public class ExposeInterfaceTest : TestBase
    {
        [Fact]
        public void ExposeSelf()
        {
            ContainerBuilder.RegisterType<ConsoleOutput>().AsSelf();
            var consoleOutput = GetContainer().Resolve<ConsoleOutput>();
            Assert.NotNull(consoleOutput);
        }

        [Fact]
        public void ExposeInterface()
        {
            ContainerBuilder.RegisterType<ConsoleOutput>().As<IOutput>();
            var consoleOutput = GetContainer().Resolve<IOutput>();
            Assert.NotNull(consoleOutput);
        }

        [Fact]
        public void ExposeInterface_resolve_self()
        {
            ContainerBuilder.RegisterType<ConsoleOutput>().As<IOutput>();
            Assert.Throws<ComponentNotRegisteredException>(() => GetContainer().Resolve<ConsoleOutput>());
        }

        [Fact]
        public void Exposes_are_IOutput_and_self()
        {
            ContainerBuilder.RegisterType<ConsoleOutput>()
                .AsSelf()
                .As<IOutput>();
            Assert.NotNull(GetContainer().Resolve<IOutput>());
            Assert.NotNull(GetContainer().Resolve<ConsoleOutput>());
        }

    
        
    }
}