namespace FrameworkInfrastructure.Driver
{
    public class BrowserBuilder
    {
        private string _browserType;
        private BrowserTypeLaunchOptions _launchOptions;

        public BrowserBuilder()
        {
            _browserType = "chromium";
            _launchOptions = new BrowserTypeLaunchOptions();
        }
        public BrowserBuilder WithBrowser(string browserType)
        {
            _browserType = browserType;
            return this;
        }

        public BrowserBuilder WithOptions(bool headless = false, string? channel = null)
        {
            _launchOptions.Headless = headless;
            _launchOptions.Channel = channel;
            return this;
        }

        public async Task<IBrowser> Build()
        {
            var playwright = await Playwright.CreateAsync();
            IBrowserType browserType;

            switch (_browserType.ToLower())
            {
                case "chromium":
                    browserType = playwright.Chromium;
                    break;
                case "firefox":
                    browserType = playwright.Firefox;
                    break;
                default:
                    throw new ArgumentException($"Unsupported browser type: {_browserType}");
            }

            return await browserType.LaunchAsync(_launchOptions);
        }
    }
}
