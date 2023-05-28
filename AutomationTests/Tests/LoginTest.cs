using AutomationTests.Pages;

namespace AutomationTests.Tests
{
    internal class LoginTest : BaseTestFixture
    {
        [Test]
        public async Task Test()
        {
            MainPage mainPage = new(Page);
            var overviewPage = await mainPage.GoTo().Result.Login();
            var balance = await overviewPage.VerifyLogginIn().Result.GetTotalBalance();
            balance.Should().Be("1000");

        }
    }
}
