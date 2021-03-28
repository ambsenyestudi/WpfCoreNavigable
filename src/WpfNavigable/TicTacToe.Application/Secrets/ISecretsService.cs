namespace TicTacToe.Application.Secrets
{
    public interface ISecretsService
    {
        void StoreSecrets(string json);
        string RetriveSecrets();
        SecretTheme RetriveSecretTheme();
        SecretTheme SwitchTheme(SecretTheme oldTheme);
    }
}
