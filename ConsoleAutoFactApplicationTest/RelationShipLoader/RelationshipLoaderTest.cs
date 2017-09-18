using System.Linq;
using Autofac;
using ConsoleAutoFactApplication;
using ConsoleAutoFactApplication.OutputImpl;
using Xunit;

namespace ConsoleAutoFactApplicationTest.RelationShipLoader
{
    public class RelationshipLoaderTest : TestBase
    {
        [Fact]
        public void Lazy_denpendency()
        {
            ContainerBuilder.RegisterType<MagicText>();
            ContainerBuilder.RegisterType<LazyMagicOutput>();
            LazyMagicOutput lazyMagicOutput = GetContainer().Resolve<LazyMagicOutput>();
            Assert.NotNull(lazyMagicOutput);
            Assert.False(lazyMagicOutput.MagicText.IsValueCreated);
            lazyMagicOutput.Write("init");
            Assert.True(lazyMagicOutput.MagicText.IsValueCreated);
        }

        [Fact]
        public void Dynamic_denpendency()
        {
            ContainerBuilder.RegisterType<MagicText>();
            ContainerBuilder.RegisterType<DynamicOutput>();
            DynamicOutput dynamicOutput = GetContainer().Resolve<DynamicOutput>();
            dynamicOutput.Write("");
            Assert.NotNull(dynamicOutput);
        }

        [Fact]
        public void Enumerable_denpendency()
        {
            ContainerBuilder.RegisterType<MagicTextOutput>().As<IOutput>();
            ContainerBuilder.RegisterType<ConsoleOutput>().As<IOutput>();
            ContainerBuilder.RegisterType<EnumerableComponent>();

            var enumerationComponent = GetContainer().Resolve<EnumerableComponent>();
            Assert.Equal(2,enumerationComponent.Outputs.Count());
        }
    }
}