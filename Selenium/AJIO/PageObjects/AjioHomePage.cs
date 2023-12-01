using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJIO.PageObjects
{
    internal class AjioHomePage
    {
        IWebDriver driver;
        public AjioHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "searchVal")]
        [CacheLookup] 
        private IWebElement? SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"appContainer\"]/div[1]/div/header/div[2]/a")]
        private IWebElement? AjioLogo { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[@title=\"Join Our Team\"]")]
        private IWebElement? JoinOurTeam { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[@href=\"/selfcare\"]")]
        private IWebElement? CustomerCare { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@class='ic-floating']")]
        private IWebElement? FloatButton { get; set; }
        
        [FindsBy(How = How.XPath, Using = "(//a[@href=\"/shop/women\"])[2]")]
        private IWebElement? ShopWomen { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[@href=\"https://www.ajio.com/return-refund-policy\"]")]
        private IWebElement? ReturnRefund { get; set; }
        
        [FindsBy(How = How.Id, Using = "loginAjio")]
        private IWebElement? SignUp { get; set; }
        
        [FindsBy(How = How.Name, Using = "username")]
        private IWebElement? MobileNoInput { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement? ContinueButton { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id=\"login-modal\"]/div/div/div[2]/div[2]/form/div[3]/label[2]/span")]
        private IWebElement? GenderRadio { get; set; }
       
        [FindsBy(How = How.Name, Using = "user-name")]
        private IWebElement? NameInputBox { get; set; }
        
        [FindsBy(How = How.Name, Using = "email-mob")]
        private IWebElement? EmailINputBox { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement? SendOtpButton { get; set; }
        
        [FindsBy(How = How.Id, Using = "tncCheckbox")]
        private IWebElement? CheckBox { get; set; }

        public void SearchBoxClick()
        {
            SearchInput?.Click();
        }

        public void AjioLogoClick()
        {
            AjioLogo?.Click();
        }

        public string GetCurrentUrl()
        {
            return driver.Url;
        }

        public SandalsResultsPage TypeSearchInput(string searchText)
        {
            if (SearchInput == null)
            {
                throw new NoSuchElementException(nameof(SearchInput));
            }
            SearchInput.SendKeys(searchText);
            SearchInput.SendKeys(Keys.Enter);
            return new SandalsResultsPage(driver);
        }

        public AjioCareersPage ClickJoinOurTeam()
        {
            JoinOurTeam.Click();
            return new AjioCareersPage(driver);
        }

        public CustomerCarePage ClickCustomerCare()
        {
            CustomerCare?.Click();
            return new CustomerCarePage(driver);
        }

        public void ClickFloatButton()
        {
            FloatButton?.Click();
        }

        public void ClickShopWomen()
        {
            ShopWomen?.Click();
        }

        public void ClickReturnRefund()
        {
            ReturnRefund?.Click();
        }

        public void ClickSignUp()
        {
            SignUp?.Click();
        }

        public void ClickMobileNoInput(string MobileNumber)
        {
            MobileNoInput?.SendKeys(MobileNumber);
        }

        public void ClickContinueButton()
        {
            ContinueButton?.Click();

        }

        public void ClickGenderRadio()
        {
            GenderRadio?.Click();
        }

        public void ClickNameInputBox(string Name)
        {
            NameInputBox.SendKeys(Name);
        }

        public void ClickEmailInputBox(string Email)
        {
            EmailINputBox.SendKeys(Email);
        }

        public void ClickSendOtpButton()
        {
            SendOtpButton?.Click();
        }

        public void SelectCheckBox()
        {
            CheckBox?.Click();
        }



    }
}
