using System;

namespace TicTacToe.Application.Secrets
{
    public record SecretTheme
    {
        public static SecretTheme Light { get; } = new SecretTheme("Black", "White", "LightGray");
        public static SecretTheme Dark { get; } = new SecretTheme("Azure", "Black", "DarkGreen");

        public string ForegroundColor { get; }
        public string BackgroundColor { get; }
        public string ButtonBackgroundColor { get; }
        private SecretTheme(string foregroundColor, string backgroundColor, string buttonBackgroundColor) =>
            (ForegroundColor, BackgroundColor, ButtonBackgroundColor) = (foregroundColor, backgroundColor, buttonBackgroundColor);

        public static SecretTheme FromColors(string foreground, string background, string buttonBackground)
        {
            //todo validate colors
            return new SecretTheme(foreground, background, buttonBackground);
        }
    }
}
