using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Exercise_3Automation_CSharp.Pages
{
    public class CartPage : BasePage
    {
        // Locators
        protected By cartProductPrice = By.XPath("//td[@class='cart_price']//p");
        protected By cartRows = By.XPath("//tbody//tr");
        protected By cartDeleteButton = By.XPath("//td[@class='cart_delete']//a");

        public CartPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) {}

        // Actions
        public void RemoveProductsFromCart()
        {
            ClickElements(cartDeleteButton);
        }

        // Getters
        public string GetCartProductPrice()
        {
            return GetText(cartProductPrice);
        }

        public int GetCartRows()
        {
            return GetQuantityElements(cartRows);
        }
    }
}