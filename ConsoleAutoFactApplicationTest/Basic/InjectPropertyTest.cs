using Autofac;
using ConsoleAutoFactApplication;
using ConsoleAutoFactApplication.OutputImpl;
using ConsoleAutoFactApplicationTest.Basic;
using Xunit;

namespace ConsoleAutoFactApplicationTest
{
    public class PropertyInjectTest : TestBase
    {
        [Fact]
        public void PropertyInject()
        {
            //not recommended in the majority of cases
            ContainerBuilder.RegisterInstance(new MagicText());
            ContainerBuilder.Register(c => new MagicTextOutput {MagicText2 = c.ResolveOptional<MagicText>()});

            var magicTextOutput = GetContainer().Resolve<MagicTextOutput>();
            Assert.NotNull(magicTextOutput);
            Assert.NotNull(magicTextOutput.MagicText2);
        }
        
        
        [Fact]
        public void PropertyInject_with_circular()
        {
//            builder.Register(c => new A()).OnActivated(e => e.Instance.B = e.Context.Resolve<B>());
        }
        
        [Fact]
        public void PropertyInject_with_reflection_component()
        {
            ContainerBuilder.RegisterInstance(new MagicText());
            ContainerBuilder.RegisterType<MagicTextOutput>().PropertiesAutowired();

            var magicTextOutput = GetContainer().Resolve<MagicTextOutput>();
            Assert.NotNull(magicTextOutput);
            Assert.NotNull(magicTextOutput.MagicText2);
        } 
        
        [Fact]
        public void PropertyInject_with_specific_field()
        {
            ContainerBuilder.RegisterType<MagicTextOutput>().WithProperty("MagicText2",new MagicText());

            var magicTextOutput = GetContainer().Resolve<MagicTextOutput>();
            Assert.NotNull(magicTextOutput);
            Assert.NotNull(magicTextOutput.MagicText2);
        }
    }
}