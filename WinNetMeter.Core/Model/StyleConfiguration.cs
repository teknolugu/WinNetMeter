namespace WinNetMeter.Core.Model
{
    public class StyleConfiguration
    {

        private bool adaptive;
        string textColor;
        string fontFamily;
        IconStyle icon;

        public string TextColor { get => textColor; set => textColor = value; }
        public string FontFamily { get => fontFamily; set => fontFamily = value; }
        public IconStyle Icon { get => icon; set => icon = value; }
        public bool Adaptive { get => adaptive; set => adaptive = value; }
    }
}
