using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJIO.PageObjects
{
    internal class AjioCareersPage
    {
        IWebDriver driver;
        public AjioCareersPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//a[@href=\"https://rcareers.ril.com/sap/bc/bsp/sap/zerec_home_page/home_page.do\"])[1]")]
        private IWebElement? ExploreCareers { get; set; }

        public ReliancePage ClickExploreCareers()
        {
            ExploreCareers?.Click();
            return new ReliancePage(driver);
        }
    }
}
