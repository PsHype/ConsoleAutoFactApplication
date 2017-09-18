using System.Collections.Generic;
using ConsoleAutoFactApplication;

namespace ConsoleAutoFactApplicationTest.Basic.TestComponent
{
    public class EnumerableComponent
    {
        public IEnumerable<IOutput> Outputs { get; }

        public EnumerableComponent(IEnumerable<IOutput> outputs)
        {
            this.Outputs = outputs;
        }
    }
}