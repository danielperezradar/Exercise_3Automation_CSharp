using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Exercise_3Automation_CSharp.Pages
{
    public class LoginPage : BasePage
    {
        // Locators
        protected By emailInput = By.XPath("//form[@action='/login']//input[@name='email']");
        protected By passwordInput = By.XPath("//form[@action='/login']//input[@name='password']");
        protected By submitButton = By.XPath("//form[@action='/login']//button[@type='submit']");

        public LoginPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) {}

        // Actions
        public void DoLogin(string username, string password)
        {
            WriteText(emailInput, username);
            WriteText(passwordInput, password);
            ClickElement(submitButton);
        }
    }
}