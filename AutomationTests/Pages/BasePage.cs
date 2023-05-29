using FrameworkInfrastructure.Models;
using FrameworkInfrastructure.Utils;

namespace AutomationTests.Pages
{
    public class BasePage
    {
        public IPage Page;

        public BasePage(IPage page) 
        {
            Page = page;
        }
    }
}
