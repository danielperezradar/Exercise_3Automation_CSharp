using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Exercise_3Automation_CSharp.Pages
{
    public class ProductsPage : BasePage
    {
        // Locators
        protected By searchInput = By.XPath("//input[@name='search']");
        protected By searchButton = By.XPath("//button[@id='submit_search']");
        protected By productDetailButton = By.XPath("//a[contains(@href,'/product_details')]");
        protected By shopProductPrice = By.XPath("//div[@class='productinfo text-center']//h2");

        public ProductsPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) {}

        // Actions
        public void SearchProduct(string productName)
        {
            WriteText(searchInput, productName);
            ClickElement(searchButton);

            WaitClickableElement(productDetailButton);
        }

        public void GoToProductDetail()
        {
            ClickElement(productDetailButton);
        }

        // Getters
        public string GetProductShopPrice()
        {
            return GetText(shopProductPrice);
        }
    }
}