using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Exercise_3Automation_CSharp.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver, WebDriverWait wait) {
            this.driver = driver;
            this.wait = wait;
        }

        public void Init(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void Finish()
        {
            driver.Quit();
        }

        // Finders
        public IWebElement FindElement(By locator)
        {
            return driver.FindElement(locator);
        }

        public IReadOnlyList<IWebElement> FindElements(By locator)
        {
            return driver.FindElements(locator);
        }

        // Actions
        public void ClickElement(By locator)
        {
            FindElement(locator).Click();
        }

        public void ClickElements(By locator)
        {
            IReadOnlyList<IWebElement> elements = FindElements(locator);
            foreach(IWebElement element in elements)
            {
                element.Click();
            }
        }

        public void WriteText(By locator, string text)
        {
            FindElement(locator).SendKeys(text);
        }

        // Getters
        public string GetText(By locator)
        {
            return FindElement(locator).Text;
        }

        public int GetQuantityElements(By locator)
        {
            return FindElements(locator).Count;
        }

        // Waiter
        public void WaitClickableElement(By locator)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(FindElement(locator)));
        }
    }
}