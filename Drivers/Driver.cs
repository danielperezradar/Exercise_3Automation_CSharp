using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Exercise_3Automation_CSharp.Drivers
{
    public class Driver
    {
        protected IWebDriver driver;

        public IWebDriver CreateDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
    }
}