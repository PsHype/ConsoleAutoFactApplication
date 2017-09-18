using Autofac;
using ConsoleAutoFactApplication;
using ConsoleAutoFactApplication.OutputImpl;
using Xunit;

namespace ConsoleAutoFactApplicationTest.Basic
{
    public class InjectMethod : TestBase
    {
        [Fact]
        public void MethodInejct()
        {
            var magicText = new MagicText {Text = "123"};
            ContainerBuilder.RegisterInstance(magicText);
            ContainerBuilder.RegisterType<MagicTextOutput>().OnActivating(e =>
            {
                var dep = e.Context.Resolve<MagicText>();
                e.Instance.MagicText2 = new MagicText {Text = "456"};
            });
            
            Assert.NotNull(GetContainer().Resolve<MagicTextOutput>().MagicText2);
            Assert.Equal(GetContainer().Resolve<MagicTextOutput>().MagicText2.Text,"456");
        }
    }
}