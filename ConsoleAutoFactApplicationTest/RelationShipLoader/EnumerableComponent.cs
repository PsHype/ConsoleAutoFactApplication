using System.Collections.Generic;
using ConsoleAutoFactApplication;

namespace ConsoleAutoFactApplicationTest.RelationShipLoader
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