using System;
using Autofac;
using ConsoleAutoFactApplication;
using ConsoleAutoFactApplication.OutputImpl;
using Xunit;

namespace ConsoleAutoFactApplicationTest
{
    public class ConstructorInjectTest :TestBase
    {
        [Fact]
        public void Deafult_constructor_Inject()
        {
            ContainerBuilder.RegisterType<ConsoleOutput>().As<IOutput>();
            ContainerBuilder.RegisterType<ConstructorInjectApplication>();

            var constructorInjectApplication = GetContainer().Resolve<ConstructorInjectApplication>();
            Assert.NotNull(constructorInjectApplication);
        }
        
        [Fact]
        public void Specifying_constructor_Inject()
        {
            ContainerBuilder.RegisterType<ConsoleOutput>().AsSelf();
            ContainerBuilder.RegisterType<ConsoleOutput>().As<IOutput>();
            ContainerBuilder.RegisterType<ConstructorInjectApplication>().UsingConstructor(typeof(IOutput));

            var constructorInjectApplication = GetContainer().Resolve<ConstructorInjectApplication>();
            Assert.NotNull(constructorInjectApplication);
        }
    }

    public class ConstructorInjectApplication
    {
        private readonly IOutput _output;
        private readonly ConsoleOutput _contnet;

        public ConstructorInjectApplication(IOutput output)
        {
            _output = output;
            Console.Write("hello IOutput");
        }
        
        

        public ConstructorInjectApplication(IOutput output,ConsoleOutput contnet)
        {
            _output = output;
            _contnet = contnet;
            Console.Write("hello consoleOutput");
        }
        
    }
}