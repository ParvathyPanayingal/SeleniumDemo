using AJIO.PageObjects;
using AJIO.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJIO.TestScripts
{
    [TestFixture]
    internal class BuyProductTests : CoreCodes
    {

        [Test]
        [Category("Regression Test")]
        public void BuyProductTest()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            AjioHomePage ajioHomePage = new(driver);
            Log.Information("Buy Product Test Started");
            ajioHomePage.SearchBoxClick();
            //Thread.Sleep(2000);

            string? excelFilePath = currdir + "/TestData/InputData.xlsx";
            string? sheetName = "SearchInput";

            List<ExcelData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? searchText = excelData?.SearchText;
                ajioHomePage.TypeSearchInput(searchText);
                TakeScreenShot();
                Log.Information("Searched for sandals");


                var sandalsResultsPage = new SandalsResultsPage(driver);
                sandalsResultsPage.ClickWomenFilter();
                //Thread.Sleep(3000);
                sandalsResultsPage.ClickWomenFlatsFilter();
                //Thread.Sleep(2000);
                

                sandalsResultsPage.ProductClick();
               //Thread.Sleep(2000);
                TakeScreenShot();
                Log.Information("Product clicked");

                

                List<string> nextwindow = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(nextwindow[1]);


                var productDetailsPage = new ProductDetailsPage(driver);
                productDetailsPage.ClickSelectSize();
                //Thread.Sleep(2000);
                productDetailsPage.ClickAddToCartButton();

                Thread.Sleep(5000);
                productDetailsPage.ClickCartIcon();
               //Thread.Sleep(3000);

                var cartPage=new CartPage(driver);

                cartPage.ClickIncQuantity();
                cartPage.ClickIncQuantityButton();
                //Thread.Sleep(2000);
                cartPage.ClickUpdateButton();
                Thread.Sleep(3000);
                cartPage.SelectCoupon();
                //Thread.Sleep(5000);
                cartPage.ApplyCouponButtonClick();
                Thread.Sleep(2000);
                cartPage.ClickProceedToBuy();
                //Thread.Sleep(5000);
                TakeScreenShot();
                Log.Information("Buy product Test completed");

                try
                {
                    Assert.IsTrue(driver?.FindElement(By.XPath(
                        "(//div[@class='modal-content'])//following::h1[1]")).Text
                        == "Welcome to AJIO", $"Test failed for Buy Product Test");
                    Log.Information("Test passed for Buy Product Test");
                    test = extent.CreateTest("Buy Product Test");
                    test.Pass("Buy Product Test success");

                }
                catch (AssertionException ex)
                {
                    Log.Error($"Test failed for Create Account. \n Exception: {ex.Message}");
                    test = extent.CreateTest("Buy Product Test");
                    test.Fail("Buy Product Test failed");
                }
                //Thread.Sleep(3000);

            }
            Log.CloseAndFlush();
        }

        

    }
}