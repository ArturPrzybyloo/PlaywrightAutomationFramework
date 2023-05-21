namespace AutomationTests.Pages
{
    public class MainPage : BasePage
    {
        private IBrowserContext context;

        public MainPage(IBrowserContext context) : base(context)
        {
            this.context = context;
        }

        // Locators
        private ILocator ProductList => Page.GetByText("Product");

        // Actions
        public async Task<MainPage> GoTo()
        {
            await Page.GotoAsync("http://localhost:8000/");
            return this;
        }

        public async Task<ProductPage> GoToProductPage()
        {
            await ProductList.ClickAsync();
            return new ProductPage(context);
        }
    }
}
