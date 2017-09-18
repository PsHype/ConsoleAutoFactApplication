using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Autofac.Features.OwnedInstances;
using ConsoleAutoFactApplication;
using ConsoleAutoFactApplication.OutputImpl;
using Xunit;

namespace ConsoleAutoFactApplicationTest.LifetimeScopes
{
    public class LifeTimeTest : TestBase
    {
        [Fact]
        public void Share_component_for_instanceperLifetimeScope()
        {
            ContainerBuilder.RegisterType<ConsoleOutput>().InstancePerLifetimeScope();

            var rootConsoleOutput = GetContainer().Resolve<ConsoleOutput>();
            using (var transactionScope = GetContainer().BeginLifetimeScope())
            {
                var consoleOutput = transactionScope.Resolve<ConsoleOutput>();
                var consoleOutput1 = transactionScope.Resolve<ConsoleOutput>();
                Assert.Equal(consoleOutput.GetHashCode(), consoleOutput1.GetHashCode());
                Assert.NotEqual(rootConsoleOutput.GetHashCode(), consoleOutput.GetHashCode());
            }
        }


        [Fact]
        public void Share_component_for_instancePerDependency()
        {
            ContainerBuilder.RegisterType<ConsoleOutput>();
            // ...is the same as this:
            //builder.RegisterType<Worker>().InstancePerDependency();
            var rootConsoleOutput = GetContainer().Resolve<ConsoleOutput>();
            using (var scope = GetContainer().BeginLifetimeScope())
            {
                var consoleOutput = scope.Resolve<ConsoleOutput>();
                var consoleOutput1 = scope.Resolve<ConsoleOutput>();
                Assert.NotEqual(consoleOutput1.GetHashCode(), consoleOutput.GetHashCode());
                Assert.NotEqual(rootConsoleOutput.GetHashCode(), consoleOutput.GetHashCode());
            }
        }
        
        
        [Fact]
        public void Share_component_for_tagging_instancePerMatchingLifetimeScope()
        {
            const string lifetimeScopeTag = "transaction";
            ContainerBuilder.RegisterType<ConsoleOutput>()
                .InstancePerMatchingLifetimeScope(lifetimeScopeTag);
            using (var transactionScope = GetContainer().BeginLifetimeScope(tag: lifetimeScopeTag))
            {
                var resolve = transactionScope.Resolve<ConsoleOutput>();
                Assert.NotNull(resolve);
                using (var consoleScope = transactionScope.BeginLifetimeScope())
                {
                    var consoleOutput = consoleScope.Resolve<ConsoleOutput>();
                    Assert.NotNull(consoleOutput);
                    Assert.Equal(consoleOutput.GetHashCode(),resolve.GetHashCode());
                }
            }
            
            Assert.Throws<DependencyResolutionException>(() => GetContainer().Resolve<ConsoleOutput>());
            
        }

        [Fact]
        public void Share_component_for_singleInstance()
        {
            ContainerBuilder.RegisterType<ConsoleOutput>().SingleInstance();
            var root = GetContainer().Resolve<ConsoleOutput>();
            using (var scope = GetContainer().BeginLifetimeScope())
            {
                var consoleOutput = scope.Resolve<ConsoleOutput>();
                var consoleOutput1 = scope.Resolve<ConsoleOutput>();
                Assert.Equal(consoleOutput1.GetHashCode(), consoleOutput.GetHashCode());
                Assert.Equal(root.GetHashCode(), consoleOutput.GetHashCode());
            }
        }

        [Fact]
        public void Share_component_for_tagging_InstancePerOwned()
        {
//            var builder = new ContainerBuilder();
//            builder.RegisterType<MessageHandler>();
//            builder.RegisterType<ServiceForHandler>().InstancePerOwned<MessageHandler>();
//            In this example the ServiceForHandler service will be scoped to the lifetime of the owned MessageHandler instance.
//
//            using(var scope = container.BeginLifetimeScope())
//            {
//                // The message handler itself as well as the
//                // resolved dependent ServiceForHandler service
//                // is in a tiny child lifetime scope under
//                // "scope." Note that resolving an Owned<T>
//                // means YOU are responsible for disposal.
//                var h1 = scope.Resolve<Owned<MessageHandler>>();
//                h1.Dispose();
//            }
        }

//        Captive dependency        

    }
}