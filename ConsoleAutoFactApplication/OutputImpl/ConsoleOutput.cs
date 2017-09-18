using System;

namespace ConsoleAutoFactApplication.OutputImpl
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}