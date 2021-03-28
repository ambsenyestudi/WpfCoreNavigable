using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using TicTacToe.Application.Secrets;

namespace TicTacToe.Infrastructure.Secrets
{
    public class SecretsService : ISecretsService
    {
        private readonly SecretsSettings settings;
        private readonly string basePath;
        private readonly IEncryptionService encryptionService;
        private const string DEFAULT_FOLDER_NAME = @"\TicTacToe";
        private const string DEFAULT_FILE_NAME = "secretTheme.txt";
        public SecretsService(IEncryptionService encryptionService, IOptions<SecretsSettings> options)
        {
            settings = options.Value;
            basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            this.encryptionService = encryptionService;
        }


        public string RetriveSecrets()
        {
            var fileName = GetStoringFilePath();
            if(!File.Exists(fileName))
            {
                return string.Empty;
            }
            var readText = File.ReadAllText(fileName);
            var decryptedText = encryptionService.Decrypt(readText);
            return decryptedText;
        }

        public void StoreSecrets(string json)
        {
            var fileName = GetStoringFilePath();
            var encryptedText = encryptionService.Encrypt(json);
            File.WriteAllText(fileName, encryptedText);
        }
        private string GetStoringFilePath()
        {
            var folder = string.IsNullOrWhiteSpace(settings?.FolderPath)
                ? DEFAULT_FOLDER_NAME
                : settings.FolderPath;

            var path = BuildPath(basePath, folder);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path + DEFAULT_FILE_NAME;
        }

        private string BuildPath(params string[] partList)
        {
            if(partList == null || !partList.Any())
            {
                return string.Empty;
            }
            var pathBuilder = new StringBuilder();
            for (int i = 0; i < partList.Length; i++)
            {
                var pathPart = @$"{partList[i]}\";
                pathBuilder.Append(pathPart);
            }
            return pathBuilder.ToString();
        }

        public SecretTheme RetriveSecretTheme()
        {
            var json = RetriveSecrets();
            if(string.IsNullOrWhiteSpace(json))
            {
                return SecretTheme.Light;
            }
            var themDTO = JsonConvert.DeserializeObject<SecretThemDTO> (json);
            var currTheme = SecretThemDTO.ToSecretTheme(themDTO);
            return currTheme;
        }

        public SecretTheme SwitchTheme(SecretTheme oldTheme)
        {
            var currTheme = oldTheme == SecretTheme.Light
                ? SecretTheme.Dark
                : SecretTheme.Light;
            var json = JsonConvert.SerializeObject(SecretThemDTO.FromSecretTheme(currTheme));
            StoreSecrets(json);
            return currTheme;
        }

    }
}
