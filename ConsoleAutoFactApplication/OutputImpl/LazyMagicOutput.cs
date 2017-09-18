using System;

namespace ConsoleAutoFactApplication.OutputImpl
{
    public class LazyMagicOutput:IOutput
    {
        public Lazy<MagicText> MagicText { get; }

        public LazyMagicOutput(Lazy<MagicText> magicText)
        {
            MagicText = magicText;
        }


        public void Write(string content)
        {
            var valueText = MagicText.Value.Text;
        }
        
    }
}