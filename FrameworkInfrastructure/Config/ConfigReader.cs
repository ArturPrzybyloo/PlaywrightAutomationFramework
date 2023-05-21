using Newtonsoft.Json;

namespace FrameworkInfrastructure.Config
{
    public class ConfigReader
    {
        private readonly Config _config;
        //private readonly string _jsonFilePath = "C:\\Users\\HP\\Desktop\\Projects\\PlaywrightAutomationFramework\\EaFramework\\EaFramework\\Config\\config.json";

        public ConfigReader()
        {
            // Get the base directory of your application
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Specify the relative path to the config file
            string relativePath = Path.Combine("Config", "config.json");

            // Combine the base directory and relative path to get the complete file path
            string filePath = Path.Combine(baseDirectory, relativePath);

            var configJson = File.ReadAllText(filePath);
            _config = JsonConvert.DeserializeObject<Config>(configJson);
        }

        public Config GetConfig()   
        {
            return _config;
        }
    }
}
