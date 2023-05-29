using FrameworkInfrastructure.Models;

namespace AutomationTests.Pages
{
    public class RegisterPage: BasePage
    {
        public RegisterPage(IPage page) : base(page) { }

        // Locators
        private ILocator FirstNameInput => Page.Locator("#customer\\.firstName");
        private ILocator LastNameInput => Page.Locator("#customer\\.lastName");
        private ILocator AddressInput => Page.Locator("#customer\\.address\\.street");
        private ILocator CityInput => Page.Locator("#customer\\.address\\.city");
        private ILocator StateInput => Page.Locator("#customer\\.address\\.state");
        private ILocator ZipCodeInput => Page.Locator("#customer\\.address\\.zipCode");
        private ILocator PhoneInput => Page.Locator("#customer\\.phoneNumber");
        private ILocator SsnInput => Page.Locator("#customer\\.ssn");
        private ILocator UsernameInput => Page.Locator("#customer\\.username");
        private ILocator PasswordInput => Page.Locator("#customer\\.password");
        private ILocator PasswordConfitmInput => Page.Locator("#repeatedPassword");
        private ILocator RegisterButton => Page.Locator("input.button[value=Register]");

        // Actions
        public async Task<OverviewPage> FillRegisterPage(User user)
        {
            await FirstNameInput.FillAsync(user.FirstName);
            await LastNameInput.FillAsync(user.LastName);
            await AddressInput.FillAsync(user.Address);
            await CityInput.FillAsync(user.City);
            await StateInput.FillAsync(user.State);
            await ZipCodeInput.FillAsync(user.ZipCode);
            await PhoneInput.FillAsync(user.Phone);
            await SsnInput.FillAsync(user.SSN.ToString());
            await UsernameInput.FillAsync(user.UserName);
            await PasswordInput.FillAsync(user.Password);
            await PasswordConfitmInput.FillAsync(user.Password);
            await RegisterButton.ClickAsync();
            return new OverviewPage(Page);
        }
    }
}