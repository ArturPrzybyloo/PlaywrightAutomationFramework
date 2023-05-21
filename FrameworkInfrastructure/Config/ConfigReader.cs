using Newtonsoft.Json;

namespace FrameworkInfrastructure.Config
{
    public class ConfigReader
    {
        private readonly Config _config;

        public ConfigReader()
        {
            // Get the base directory of your application
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Specify the relative path to the config file
            var filePath = Path.Combine(baseDirectory, "config.json");

            var configJson = File.ReadAllText(filePath);
            _config = JsonConvert.DeserializeObject<Config>(configJson);
        }

        public Config GetConfig()   
        {
            return _config;
        }
    }
}
