using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Exercise_3Automation_CSharp.Helpers
{
    public class Waiter
    {
        protected WebDriverWait wait;

        public WebDriverWait CreateWaiter(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait;
        }
    }
}