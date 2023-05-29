using AutomationTests.Pages;
using FrameworkInfrastructure.Models;
using FrameworkInfrastructure.Utils;

namespace AutomationTests.Tests
{
    public class BasicTests : BaseTestFixture
    {
        readonly User user = GenerateNewUser.CreateUser();

        [Test,Order(1)]
        public async Task RegisterTest()
        {
            MainPage mainPage = new(Page);

            var registerPage = await mainPage.GoTo().Result.GoToRegisterPage();
            var overviewPage = await registerPage.FillRegisterPage(user);
            await overviewPage.VerifyRegiser(user);
        }

        [Test, Order(2)]
        public async Task LoginTest()
        {
            MainPage mainPage = new(Page);
            await mainPage.GoTo().Result.Login(user);
        }
    }
}
