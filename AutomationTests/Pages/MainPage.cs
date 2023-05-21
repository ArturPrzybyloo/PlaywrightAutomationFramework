using FrameworkInfrastructure.Config;

namespace AutomationTests.Pages
{
    public class MainPage : BasePage
    {
        private IBrowserContext context;
        ConfigReader reader;

        public MainPage(IBrowserContext context) : base(context)
        {
            this.context = context;
            reader = new ConfigReader();
        }

        // Locators
        private ILocator LoginInput => Page.Locator("input[type='text']");

        // Actions
        public async Task<MainPage> GoTo()
        {
            await Page.GotoAsync(reader.GetConfig().AppConfig.BaseUrl);
            return this;
        }

        public async Task Login()
        {
            await LoginInput.FillAsync("test");
        }

    }
}
