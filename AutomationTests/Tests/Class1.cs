using AutomationTests.Pages;

namespace AutomationTests.Tests
{
    internal class Class1 : BaseTestFixture
    {
        [Test]
        public async Task Test()
        {
            MainPage mainPage = new(Context);
            var products = await mainPage.GoTo().Result.GoToProductPage();

        }
    }
}
