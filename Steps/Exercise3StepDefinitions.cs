using TechTalk.SpecFlow;
using System.Xml;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Exercise_3Automation_CSharp.Helpers;
using Exercise_3Automation_CSharp.Drivers;
using Exercise_3Automation_CSharp.Pages;

namespace Exercise_3Automation_CSharp.Steps
{
    [Binding]
    public class Exercise3StepDefinitions
    {
        static IWebDriver driver;
        static WebDriverWait wait;
        static Driver _driver;
        static Waiter _wait;
        static ReadXmlDocument readXmlDocument;
        static BasePage basePage;
        static HeaderPage headerPage;
        static LoginPage loginPage;
        static ProductsPage productsPage;
        static ProductDetailPage productDetailPage;
        static CartPage cartPage;

        // Strings
        string expectedProductPrice, url, username, password;

        // Given statements //
        [Given(@"I load my XML file '(.*)'")]
        public void loadDocument(string path)
        {
            readXmlDocument = new ReadXmlDocument();
            XmlNodeList nodes = readXmlDocument.ReadXML(path);
            url = readXmlDocument.GetUrl(nodes);
            username = readXmlDocument.GetUsername(nodes);
            password = readXmlDocument.GetPassword(nodes);
        }

        [Given(@"I go to automation exercise web site")]
        public void goToWebSite()
        {
            _driver = new Driver();
            _wait = new Waiter();
            
            driver = _driver.CreateDriver();
            wait = _wait.CreateWaiter(driver);
            
            basePage = new BasePage(driver, wait);
            headerPage = new HeaderPage(driver, wait);
            loginPage = new LoginPage(driver, wait);
            productsPage = new ProductsPage(driver, wait);
            productDetailPage = new ProductDetailPage(driver, wait);
            cartPage = new CartPage(driver, wait);

            basePage.Init(url);
        }

        [Given(@"I login using valid credentials")]
        public void login()
        {
            headerPage.GoToLogin();
            loginPage.DoLogin(username, password);
        }

        [Given(@"I search for product: '(.*)'")]
        public void searchForProduct(string productName)
        {
            headerPage.GoToProducts();
            productsPage.SearchProduct(productName);
        }

        [Given(@"I select first product")]
        public void clickProduct()
        {
            productsPage.GoToProductDetail();
        }

        // When statements //
        [When(@"I add it to Cart")]
        public void addToCart()
        {
            productDetailPage.AddToCart();
        }

        [When(@"I select first product and save the price")]
        public void selectProductAndSaveThePrice()
        {
            expectedProductPrice = productsPage.GetProductShopPrice();
            productsPage.GoToProductDetail();
        }
        
        // Then statements //
        [Then(@"I validate first price is the same of new price")]
        public void validatePrices()
        {
            ClassicAssert.AreEqual(expectedProductPrice, productDetailPage.GetProductDetailPrice());
        }

        [Then(@"I validate cart price is the same of new price")]
        public void validateCartPrices()
        {
            headerPage.GoToCart();
            ClassicAssert.AreEqual(expectedProductPrice, cartPage.GetCartProductPrice());
        }

        [Then(@"I validate that the Shop car has '(.*)' as a product")]
        public void validateShopCarProductQuantity(int productQuantity)
        {
            headerPage.GoToCart();
            ClassicAssert.AreEqual(productQuantity, cartPage.GetCartRows());
        }

        [Then(@"I finish the test")]
        public void finish()
        {
            headerPage.GoToCart();
            cartPage.RemoveProductsFromCart();
            basePage.Finish();
        }
    }
}