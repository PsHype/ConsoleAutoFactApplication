using System;

namespace ConsoleAutoFactApplication.OutputImpl
{
    public class TextOutput : IOutput
    {
        private readonly string defaultContent;

        public TextOutput(string defaultContent)
        {
            this.defaultContent = defaultContent;
            Console.WriteLine(defaultContent);
        }

        public void Write(string content)
        {
            Console.WriteLine("textOutput" + defaultContent);
        }
    }
}