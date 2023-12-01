﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJIO.PageObjects
{
    internal class JobDescriptionPage
    {
        IWebDriver driver;
        public JobDescriptionPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@id='__xmlview1--IdAply']")]
        private IWebElement? ApplyButton { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//span[text()='New User']")]
        private IWebElement? NewUserButton { get; set; }




        public void ClickApplyButton()
        {
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", ApplyButton);
            //CoreCodes.ScrollIntoView(driver, ApplyButton);
            //driver.Manage().Window.Size = new System.Drawing.Size(1296, 696);
            
            ApplyButton?.Click();
        }

        public void ClickNewUserButton()
        {
            NewUserButton?.Click();
        }
    }
}
