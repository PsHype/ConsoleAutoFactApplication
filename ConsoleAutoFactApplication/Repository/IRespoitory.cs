using System.Collections.Generic;

namespace ConsoleAutoFactApplication.Repository
{
    public interface IRespoitory<T>
    {
        List<T> GetAll();
    }
}