using System.Collections.Generic;

namespace ConsoleAutoFactApplication.Repository
{
    public class TestRepository<T> : IRespoitory<T>
    {
        public List<T> GetAll()
        {
            var list = new List<T>();
            return list;
        }
    }
}