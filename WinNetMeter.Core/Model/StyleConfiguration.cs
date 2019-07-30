namespace WinNetMeter.Core.Model
{
    class StyleConfiguration
    {
        string textColor;
        string fontFamily;
        IconStyle icon;

        public string TextColor { get => textColor; set => textColor = value; }
        public string FontFamily { get => fontFamily; set => fontFamily = value; }
        public IconStyle Icon { get => icon; set => icon = value; }
    }
}
