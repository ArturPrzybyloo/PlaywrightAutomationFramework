namespace FrameworkInfrastructure.Config
{
    public class BrowserConfig
    {
        public string BrowserType { get; set; }
        public bool HeadlessMode { get; set; }
        public string Channel { get; set; }
    }

    public class AppConfig
    {
        public string BaseUrl { get; set; }
    }

    public class Config
    {
        public BrowserConfig BrowserConfig { get; set; }
        public AppConfig AppConfig { get; set; }
    }
}
