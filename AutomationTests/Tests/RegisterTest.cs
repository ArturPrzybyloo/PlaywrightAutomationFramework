using AutomationTests.Pages;
using FrameworkInfrastructure.Utils;

namespace AutomationTests.Tests
{
    internal class LoginTest : BaseTestFixture
    {
        [Test]
        public async Task Test()
        {
            MainPage mainPage = new(Page);
            var user = GenerateNewUser.CreateUser();

            var registerPage = await mainPage.GoTo().Result.GoToRegisterPage();
            var overviewPage = await registerPage.FillRegisterPage(user);
            await overviewPage.VerifyRegiser(user);

        }
    }
}
