using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Autofac;

namespace ConsoleAutoFactApplicationTest
{
    public class TestBase
    {
        protected ContainerBuilder ContainerBuilder;
        private IContainer _container;

        public TestBase()
        {
            ContainerBuilder = new ContainerBuilder();
        }


        protected IContainer GetContainer()
        {
            return _container ?? (_container = ContainerBuilder.Build());
        }

      
    }
}