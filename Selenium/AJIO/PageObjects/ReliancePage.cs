using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJIO.PageObjects
{
    internal class ReliancePage
    {
        IWebDriver driver;
        public ReliancePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//a[@href=\"/sap/bc/ui5_ui5/sap/ZJDESC_ERECAPP/index.html?sap-ui-language=EN&sap-ui-appcache=false&sap-theme=ZEREC_BASE@/sap/public/bc/themes/~client-449&tid=DJ&pid=AURDRkNGR0ZC\"])[2]")]
        private IWebElement? ViewDetails { get; set; }

        public JobDescriptionPage ClickViewDetails()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", ViewDetails);
            return new JobDescriptionPage(driver);
        }
    }
}
