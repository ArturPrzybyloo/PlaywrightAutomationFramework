namespace AutomationTests.Pages
{
    public class OverviewPage : BasePage
    {
        public OverviewPage(IPage page) : base(page) { }

        // Locators
        private ILocator LogOutButton => Page.GetByText("Log Out");
        private ILocator TotalBalance => Page.Locator(".ng-binding");

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


    }
}