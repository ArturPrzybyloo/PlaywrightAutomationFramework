namespace AutomationTests.Pages
{
    public class BasePage
    {
        public IPage Page;

        public BasePage(IBrowserContext context) 
        {
            Page = context.NewPageAsync().Result;
        }
    }
}
