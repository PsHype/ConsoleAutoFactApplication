using System;

namespace ConsoleAutoFactApplication.OutputImpl
{
    public class MagicTextOutput : IOutput
    {
        public MagicText MagicText2 { get; set; }
        public MagicText MagicText1 { get; set; }

        
        public void Write(string content)
        {
            Console.Write(MagicText2.Text);
        }
    }
}