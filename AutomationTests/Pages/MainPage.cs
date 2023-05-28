using FrameworkInfrastructure.Config;

namespace AutomationTests.Pages
{
    public class MainPage : BasePage
    {
        private IPage Page;
        private ConfigReader Reader;
        private Config Config;

        public MainPage(IPage page) : base(page)
        {
            Page = page;
            Reader = new ConfigReader();
            Config = Reader.GetConfig();
        }

        // Locators
        private ILocator LoginInput => Page.Locator("input[name='username']");
        private ILocator PasswordInput => Page.Locator("input[name='password']");
        private ILocator LoginButton => Page.Locator("input[type='submit']");
        private ILocator RegisterLink => Page.GetByText("Register");

        // Actions
        public async Task<MainPage> GoTo()
        {
            await Page.GotoAsync(Config.AppConfig.BaseUrl);
            return this;
        }

        public async Task<OverviewPage> Login()
        {
            await LoginInput.FillAsync(Config.AppConfig.UserName);
            await PasswordInput.FillAsync(Config.AppConfig.Password);
            await LoginButton.ClickAsync();

            return new OverviewPage(Page);
        }

        public async Task<RegisterPage> GoToRegisterPage()
        {
            await RegisterLink.ClickAsync();

            return new RegisterPage(Page);
        }

    }
}
