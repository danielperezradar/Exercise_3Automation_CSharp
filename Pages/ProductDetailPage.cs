using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Exercise_3Automation_CSharp.Pages
{
    public class ProductDetailPage : BasePage
    {
        // Locators
        protected By detailProductPrice = By.XPath("//div[@class='product-information']//span//span");
        protected By addToCartButton = By.XPath("//div[@class='product-information']//span//button");
        protected By continueShoppingButton = By.XPath("//button[text()='Continue Shopping']");

        public ProductDetailPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) {}

        // Actions
        public void AddToCart() 
        {
            ClickElement(addToCartButton);
            ClickElement(continueShoppingButton);
        }

        // Getters
        public string GetProductDetailPrice()
        {
            return GetText(detailProductPrice);
        }
    }
}