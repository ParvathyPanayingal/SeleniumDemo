using AJIO.PageObjects;
using AJIO.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJIO.Testscripts
{
    [TestFixture]
    internal class AjioSmokeTests : CoreCodes
    {
        [Test,Order(1)]
        [Category("Smoke Test")]
        public void AjioLogoTest()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();


            AjioHomePage ajio = new(driver);
            ajio.AjioLogoClick();
            //Thread.Sleep(2000);
            TakeScreenShot();
            Log.Information("Page reloaded");
            try
            {
                Assert.That(driver?.Url, Is.EqualTo("https://www.ajio.com/"));

                Log.Information("Test passed for Ajio logo");

                test = extent.CreateTest("Ajio logo Test");
                test.Pass("Ajio logo Test success");

            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Ajio logo. \n Exception: {ex.Message}");

                test = extent.CreateTest("Ajio logo Test");
                test.Fail("Ajio logo  Test failed");
            }
            Log.CloseAndFlush();

        }
        [Test,Order(2)]
        [Category("Smoke Test")]
        public void CustomerCareTest()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            if (!driver.Url.Equals("https://www.ajio.com/"))
            {
                driver.Navigate().GoToUrl("https://www.ajio.com/");

            }          

            AjioHomePage ajioHomePage = new(driver);
            Log.Information("Buy Product Test Started");
            ajioHomePage.ClickCustomerCare();
            TakeScreenShot();
            Log.Information("Navigated to Customer Care Page");

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50); 
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); 
            fluentWait.Message = "Element not found.";

            fluentWait.Until(d => driver.Url.Equals("https://www.ajio.com/selfcare"));
            //Thread.Sleep(2000);

            string? excelFilePath = currdir + "/TestData/InputData.xlsx";
            string? sheetName = "CustomerCareInput";

            List<CustomerCareExcelData> excelDataList = ExcelUtils.ReadCustomerCareExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? searchQuery = excelData?.SearchQuery;
                var customerCarePage = new CustomerCarePage(driver);
                customerCarePage.ClickSearchInput(searchQuery);
                TakeScreenShot();
                Log.Information("Searched for return");
                //Thread.Sleep(3000);
                customerCarePage.SelectQuestion();
                //Thread.Sleep(3000);

                
                 try
                  {


                    Assert.IsTrue(driver?.FindElement(By.XPath(
                        "(//div[@id=\"left-tabs-example-tabpane-2\"])/div")).Text
                        == "1. We offer 7 days no-questions-asked returns policy for \"Fine Jewellery\" on select products. 2. Gold coins, Silver Coins and Idols are non-returnable. 3. Also, all return policies are listed on the product display page for easy reference 4. For detailed returns T&amp;C please refer this link https://www.ajio.com/selfcare 5. Currently, we are not offering any exchange policy", $"Test failed for Customer Care");

                    Log.Information("Test passed for Customer Care");

                    test = extent.CreateTest("Customer Care Test");
                    test.Pass("Customer Care Test success");

                  }
                catch (AssertionException ex)
                  {
                    Log.Error($"Test failed for Customer Care. \n Exception: {ex.Message}");

                    test = extent.CreateTest("Customer Care Test");
                    test.Fail("Customer Care Test failed");
                  }

            }
            Log.CloseAndFlush();


        }

        [Test, Order(3)]
        [Category("Smoke Test")]
        public void FloatButtonTest()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            if (!driver.Url.Equals("https://www.ajio.com/"))
            {
                driver.Navigate().GoToUrl("https://www.ajio.com/");

            }
            AjioHomePage ajio = new(driver);
            ajio.ClickFloatButton();
            TakeScreenShot();
            Log.Information("Modal Opened");
            ajio.ClickShopWomen();
            //Thread.Sleep(3000);
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found.";

            fluentWait.Until(d => driver.Url.Equals("https://www.ajio.com/shop/women"));


            try
            {
                Assert.That(driver?.Url, Is.EqualTo("https://www.ajio.com/shop/women"));

                Log.Information("Test passed for Float Button");

                test = extent.CreateTest("Float Button Test");
                test.Pass("Float Button Test success");

            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Float Button. \n Exception: {ex.Message}");

                test = extent.CreateTest("Float Button Test");
                test.Fail("Float Button Test failed");
            }
            Log.CloseAndFlush();
        }

        [Test, Order(4)]
        [Category("Smoke Test")]
        public void ReturnRefundTest()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            if (!driver.Url.Equals("https://www.ajio.com/"))
            {
                driver.Navigate().GoToUrl("https://www.ajio.com/");

            }

            AjioHomePage ajio = new(driver);
            ajio.ClickReturnRefund();
            //Thread.Sleep(2000);
            TakeScreenShot();
            Log.Information("Page displays return and refund policy");
            try
            {
                Assert.That(driver?.Url, Is.EqualTo("https://www.ajio.com/return-refund-policy"));

                Log.Information("Test passed for Return and refund policy");

                test = extent.CreateTest("Return and refund policy Test");
                test.Pass("Return and refund policy Test success");

            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Return and refund policy. \n Exception: {ex.Message}");

                test = extent.CreateTest("Return and refund policy Test");
                test.Fail("Return and refund policy Test failed");
            }
            Log.CloseAndFlush();

        }

        [Test, Order(5)]
        [Category("Smoke Test")]
        public void SignUpTest()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            if (!driver.Url.Equals("https://www.ajio.com/"))
            {
                driver.Navigate().GoToUrl("https://www.ajio.com/");

            }

            AjioHomePage ajio = new(driver);
            ajio.ClickSignUp();
            //Thread.Sleep(2000);
            TakeScreenShot();
            Log.Information("SignUp modal displayed");

            string? excelFilePath = currdir + "/TestData/InputData.xlsx";
            string? sheetName = "SignUp";

            List<SignUpExcelData> excelDataList = ExcelUtils.ReadSignUpExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? mobileNumber = excelData?.MobileNumber;
                string? name = excelData?.Name;
                string? email = excelData?.Email;
                ajio.ClickMobileNoInput(mobileNumber);
                ajio.ClickContinueButton();
                //Thread.Sleep(2000);
                ajio.ClickGenderRadio();
                ajio.ClickNameInputBox(name);
                ajio.ClickEmailInputBox(email);
                ajio.ClickSendOtpButton();
                ajio.SelectCheckBox();
                //Thread.Sleep(3000);
                try
                {


                    Assert.IsTrue(driver?.FindElement(By.XPath(
                        "(//form[@class=' signup-form'])//child::h1")).Text
                        == "Welcome to AJIO", $"Test failed for SignUp ");

                    Log.Information("Test passed for SignUp ");

                    test = extent.CreateTest("SignUp Test");
                    test.Pass("SignUp Test success");

                }
                catch (AssertionException ex)
                {
                    Log.Error($"Test failed for SignUp. \n Exception: {ex.Message}");

                    test = extent.CreateTest("SignUp Test");
                    test.Fail("SignUp Test failed");
                }

            }
            Log.CloseAndFlush();

        }
    }
}
