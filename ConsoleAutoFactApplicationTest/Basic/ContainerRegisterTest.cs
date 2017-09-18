using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using ConsoleAutoFactApplication;
using ConsoleAutoFactApplication.OutputImpl;
using ConsoleAutoFactApplication.Repository;
using Xunit;

namespace ConsoleAutoFactApplicationTest.Basic
{
    public class ContainerRegisterTest : TestBase
    {
        [Fact]
        public void RegisterInstance_with_lambda()
        {
            
            //default register asSelf 
            ContainerBuilder.Register(c => new TextOutput("ping pong"));
            Assert.NotNull(GetContainer().Resolve<TextOutput>());
        }


        [Fact]
        public void RegisterInstance()
        {
            var textOutput = new TextOutput("ping pong");
            ContainerBuilder.RegisterInstance(textOutput).As<IOutput>();

            Assert.NotNull(GetContainer().Resolve<IOutput>());
        }


        [Fact]
        public void RegisterInstance_ExternallyOwned()
        {
            var textOutput = new TextOutput("ping pong");
            ContainerBuilder.RegisterInstance(textOutput).As<IOutput>().ExternallyOwned();
            Assert.NotNull(GetContainer().Resolve<IOutput>());
        }


        [Fact]
        public void RegisterGeneric()
        {
            ContainerBuilder.RegisterGeneric(typeof(TestRepository<>)).As(typeof(IRespoitory<>))
                .InstancePerLifetimeScope();
            var respoitory = GetContainer().Resolve<IRespoitory<string>>();
            Assert.NotNull(respoitory);
            Assert.True(respoitory is TestRepository<string>);
        }

        [Fact]
        public void Should_use_last_registered()
        {
            ContainerBuilder.RegisterType<ConsoleOutput>().As<IOutput>();
            ContainerBuilder.RegisterType<MagicTextOutput>().As<IOutput>();

            var ioutput = GetContainer().Resolve<IOutput>();
            Assert.NotNull(ioutput);
            Assert.True(ioutput is MagicTextOutput);
        }

        [Fact]
        public void shoud_use_first_registered()
        {
            ContainerBuilder.RegisterType<ConsoleOutput>().As<IOutput>();
            ContainerBuilder.RegisterType<MagicTextOutput>().As<IOutput>().PreserveExistingDefaults();

            var ioutput = GetContainer().Resolve<IOutput>();
            Assert.NotNull(ioutput);
            Assert.True(ioutput is ConsoleOutput);
        }
     
        //Conditional Registration
        [Fact]
        public void IfNotRegistered_conditional_Register()
        {
            ContainerBuilder.RegisterType<ConsoleOutput>().As<IOutput>();
            ContainerBuilder.RegisterType<MagicTextOutput>().As<IOutput>().IfNotRegistered(typeof(IOutput));

            var resolves = GetContainer().Resolve<IEnumerable<IOutput>>();
            Assert.Equal(1, resolves.Count());
            Assert.NotNull(resolves);
        }

//        ContainerBuilder.RegisterType<MagicTextOutput>()
//        .As<IOutput>()
//        .OnlyIf(reg =>
//        reg.IsRegistered(new ConsoleOutput())) &&
//        reg.IsRegistered(new TypedService(typeof(HandlerB))));

        [Fact]
        public void Scan_component()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            ContainerBuilder.RegisterAssemblyTypes(executingAssembly)
                .Where(t => t.Name.EndsWith("OutputTest"))
//                .Except()
                .AsImplementedInterfaces()
                .AsSelf();
//                .As<IOutput>();

            Assert.NotNull(GetContainer().Resolve<IOutput>());
            Assert.NotNull(GetContainer().Resolve<OutputTest>());
        }
    }
}