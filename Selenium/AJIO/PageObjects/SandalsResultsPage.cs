using OpenQA.Selenium;
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
            //CoreCodes.ScrollIntoView(driver, Product);
            Product.Click();
            Thread.Sleep(3000);
            return new ProductDetailsPage(driver);
        }
    }
}
