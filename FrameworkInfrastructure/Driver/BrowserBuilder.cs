namespace FrameworkInfrastructure.Driver
{
    public class BrowserBuilder
    {
        private string _browserType;
        private BrowserTypeLaunchOptions _launchOptions;
        public IPlaywright _playwright;

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
            _playwright = await Playwright.CreateAsync();
            IBrowserType browserType;

            switch (_browserType.ToLower())
            {
                case "chromium":
                    browserType = _playwright.Chromium;
                    break;
                case "firefox":
                    browserType = _playwright.Firefox;
                    break;
                default:
                    throw new ArgumentException($"Unsupported browser type: {_browserType}");
            }

            return await browserType.LaunchAsync(_launchOptions);
        }
    }
}
