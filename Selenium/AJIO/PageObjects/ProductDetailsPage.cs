using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJIO.PageObjects
{
    internal class ProductDetailsPage
    {
        IWebDriver driver;
        public ProductDetailsPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//div[@role='button'])/span[1]")]
        private IWebElement? SelectSize { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn-gold")]
        private IWebElement? AddToCartButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href=\"/cart\"]")]
        private IWebElement? CartIcon { get; set; }

        public void ClickSelectSize()
        {
            SelectSize?.Click();
        }

        public void ClickAddToCartButton()
        {
            AddToCartButton?.Click();
        }

        public CartPage ClickCartIcon()
        {
            CartIcon?.Click();
            return new CartPage(driver);
        }
    }
}
