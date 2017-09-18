using System;

namespace ConsoleAutoFactApplication.OutputImpl
{
    public class DynamicOutput:IOutput
    {
        public Func<MagicText> MagicText { get; }

        public DynamicOutput(Func<MagicText> magicText)
        {
            this.MagicText = magicText;
        }

        public void Write(string content)
        {
            var text = MagicText();
            Console.Write(text.Text);
        }
    }
}