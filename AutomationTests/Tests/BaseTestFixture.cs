using FrameworkInfrastructure.Config;
using FrameworkInfrastructure.Driver;
using NUnit.Framework.Interfaces;

namespace AutomationTests.Tests
{
    [TestFixture]
    public class BaseTestFixture
    {
        protected IBrowser Browser;
        protected IBrowserContext Context;
        protected IPage Page;

        [SetUp]
        public async Task SetUp()
        {
            // Read config file
            ConfigReader reader = new();
            var config = reader.GetConfig();

            // Set up browser
            var builder = new BrowserBuilder()
               .WithBrowser(config.BrowserConfig.BrowserType)
               .WithOptions(channel: config.BrowserConfig.Channel);

            Browser = await builder.Build();

            // Create a new browser context and a new page
            Context = await Browser.NewContextAsync();
            await Context.Tracing.StartAsync(new TracingStartOptions()
            {
                Screenshots = true,
                Snapshots = true,
            });

            Page = await Context.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                if (Context != null)
                {
                    await Context.Tracing.StopAsync(new TracingStopOptions()
                    {
                        Path = $"traces/trace-{TestContext.CurrentContext.Test.Name}.zip"
                    });
                }
            }

            if (Browser != null)
            {
                await Browser.CloseAsync();
                Browser = null;
            }
        }
    }
}
