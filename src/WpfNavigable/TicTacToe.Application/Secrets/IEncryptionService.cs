namespace TicTacToe.Application.Secrets
{
    public interface IEncryptionService
    {
        string Encrypt(string content);
        string Decrypt(string encrypted);
    }
}
