using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJIO.PageObjects
{
    internal class CustomerCarePage
    {
        IWebDriver driver;
        public CustomerCarePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//input[@type=\"text\"])[2]")]
        [CacheLookup]
        private IWebElement? SearchInputBox { get; set; }
        
        [FindsBy(How = How.Id, Using = "left-tabs-example-tab-2")]
        private IWebElement? Question { get; set; }

        public void ClickSearchInput(string searchQuery)
        {
            SearchInputBox?.SendKeys(searchQuery);
            SearchInputBox?.SendKeys(Keys.Enter);
        }

        public void SelectQuestion()
        {
            Question?.Click();
        }
    }
}
