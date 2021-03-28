using TicTacToe.Application.Secrets;

namespace TicTacToe.Infrastructure.Secrets
{
    public class SecretThemDTO
    {
        public string ForegroundColor { get; set; }
        public string BackgroundColor { get; set; }
        public string ButtonBackgroundColor { get; set; }

        internal static SecretThemDTO FromSecretTheme(SecretTheme theme) =>
            new SecretThemDTO
            {
                ForegroundColor = theme.ForegroundColor,
                BackgroundColor = theme.BackgroundColor,
                ButtonBackgroundColor = theme.ButtonBackgroundColor
            };
        internal static SecretTheme ToSecretTheme(SecretThemDTO dto) =>
            SecretTheme.FromColors
            (dto.ForegroundColor, dto.BackgroundColor, dto.ButtonBackgroundColor);
    }
}
