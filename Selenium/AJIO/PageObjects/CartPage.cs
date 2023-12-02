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
    internal class CartPage
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

        public CartPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);

        }

        
        [FindsBy(How = How.XPath, Using = "(//span[@class='ic-chevrondown'])[2]")]
        private IWebElement? IncQuantity { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//button[text()='+']")]
        private IWebElement? IncQuantityButton { get; set; }
        
        [FindsBy(How = How.Id, Using = "updateQuantity")]
        private IWebElement? UpdateButton { get; set; }
        
        [FindsBy(How = How.XPath, Using = "(//li[@class='rilrtl-list-item'])[1]")]
        private IWebElement? CouponCode { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//button[text()='Apply']")]
        private IWebElement? ApplyCouponButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Proceed to shipping']")]
        private IWebElement? ProceedToBuy { get; set; }

        public void ClickIncQuantity()
        {
            IncQuantity?.Click();
        }

        public void ClickIncQuantityButton()
        {
            IncQuantityButton?.Click();
        }

        public void ClickUpdateButton()
        {
            UpdateButton?.Click();
        }

        public void SelectCoupon()
        {
           //fluentWait().Until(d => (CouponCode?.Displayed));
           CouponCode?.Click();
        }

        public void ApplyCouponButtonClick()
        {
            ApplyCouponButton?.Click();
        }

        public void ClickProceedToBuy()
        {
            //fluentWait().Until(d => (ProceedToBuy?.Displayed));
            ProceedToBuy?.Click();
        }
    }
}
