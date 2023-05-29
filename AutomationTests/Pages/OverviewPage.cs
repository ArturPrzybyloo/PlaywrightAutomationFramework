using FrameworkInfrastructure.Models;

namespace AutomationTests.Pages
{
    public class OverviewPage : BasePage
    {
        public OverviewPage(IPage page) : base(page) { }

        // Locators
        private ILocator LogOutButton => Page.GetByText("Log Out");
        private ILocator TotalBalance => Page.Locator(".ng-binding");
        private ILocator WelcomeMessage => Page.Locator("h1[class='title']");

        // Actions
        public async Task<OverviewPage> VerifyLogginIn()
        {
            await LogOutButton.IsVisibleAsync();
            return this;
        }

        public async Task<string> GetTotalBalance()
        {
            Thread.Sleep(1000);
            return await TotalBalance.InnerTextAsync();
        } 

        public async Task VerifyRegiser(User user)
        {
            var welcomeMsg = await WelcomeMessage.InnerTextAsync();
            welcomeMsg.Should().Contain(user.UserName);
        }
    }
}