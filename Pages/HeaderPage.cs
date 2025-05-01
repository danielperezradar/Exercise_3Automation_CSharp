using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Exercise_3Automation_CSharp.Pages
{
    public class HeaderPage : BasePage
    {
        // Locators
        protected By loginMenu = By.XPath("//a[@href='/login']");
        protected By productsMenu = By.XPath("//a[@href='/products']");
        protected By cartMenu = By.XPath("//ul//a[@href='/view_cart']");

        public HeaderPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) {}

        // Actions
        public void GoToLogin()
        {
            WaitClickableElement(loginMenu);
            ClickElement(loginMenu);
        }

        public void GoToProducts()
        {
            WaitClickableElement(productsMenu);
            ClickElement(productsMenu);
        }

        public void GoToCart()
        {
            WaitClickableElement(cartMenu);
            ClickElement(cartMenu);
        }
    }
}