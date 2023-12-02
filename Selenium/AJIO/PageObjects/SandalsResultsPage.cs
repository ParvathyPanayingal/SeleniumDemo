using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJIO.PageObjects
{
    internal class SandalsResultsPage
    {
        IWebDriver driver;
        private DefaultWait<IWebDriver> fluentWait()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found.";
            return fluentWait;
        }

        public SandalsResultsPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//li[@class=\"rilrtl-list-item\"])[2]")]
        private IWebElement? WomenFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "(//li[@class='rilrtl-list-item'])[8]")]
        private IWebElement? WomenFlatsFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[div[@class='preview']][1]")]
        private IWebElement? Product { get; set; }


        public void ClickWomenFilter()
        {
            WomenFilter?.Click();
        }

        public void ClickWomenFlatsFilter()
        {
            WomenFlatsFilter?.Click();
        }



        public ProductDetailsPage ProductClick()
        {
            //fluentWait().Until(d => (Product?.Displayed));
            Product?.Click();
            //Thread.Sleep(3000);
            return new ProductDetailsPage(driver);
        }
    }
}
