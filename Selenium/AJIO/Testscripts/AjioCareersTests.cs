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

namespace AJIO.Testscripts
{
    [TestFixture]
    internal class AjioCareersTests:CoreCodes
    {
        [Test]
        [Category("Regression Test")]
        public void AjioCareerTest()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            var ajioHomePage = new AjioHomePage(driver);
            ajioHomePage.ClickJoinOurTeam();
            TakeScreenShot();
            Log.Information("Navigated to AJIO Career page ");

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50); 
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); 
            fluentWait.Message = "Element not found.";

            fluentWait.Until(d => driver.FindElement(By.XPath("//a[@title=\"Join Our Team\"]")));

            var ajioCareersPage= new AjioCareersPage(driver);
            ajioCareersPage.ClickExploreCareers();
            Thread.Sleep(3000);

         

            List<string> nextwindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextwindow[1]);

            var reliancePage=new ReliancePage(driver);
            reliancePage.ClickViewDetails();

            Thread.Sleep(3000);

            List<string> nexwindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nexwindow[2]);

            var jobDescriptionPage = new JobDescriptionPage(driver);
            jobDescriptionPage.ClickApplyButton();

            Thread.Sleep(2000);



            jobDescriptionPage.ClickNewUserButton();
            Thread.Sleep(3000);
            TakeScreenShot();
            Log.Information("Navigated to Registration form page ");

            var registrationPage = new RegistrationPage(driver);

            string? excelFilePath = currdir + "/TestData/InputData.xlsx";
            string? sheetName = "RegistrationForm";

            List<RegistrationExcelData> excelDataList = ExcelUtils.ReadRegistrationExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? userId = excelData?.UserId;
                string? email = excelData?.Email;
                string? password = excelData?.Password;
                string? conPassword = excelData?.ConPassword;
                string? firstName = excelData?.FirstName;
                string? lastName = excelData?.LastName;
                string? date=excelData?.Date;
                string? city = excelData?.City;
                string? mobileNo = excelData?.MobileNo;
                string? passingDate=excelData?.PassingDate;
                string? filePath = excelData?.FilePath;

                registrationPage.EnterUserId(userId);
                //Thread.Sleep(2000);
                registrationPage.EnterEmail(email);
                //Thread.Sleep(2000);
                registrationPage.EnterPassword(password);
                //Thread.Sleep(2000);
                registrationPage.EnterConfirmPassword(conPassword);
               // Thread.Sleep(2000);
                registrationPage.EnterFirstName(firstName);
                //Thread.Sleep(2000);
                registrationPage.EnterLastName(lastName);
                //Thread.Sleep(2000);
                registrationPage.SelectDateOfBirth(date);
                //Thread.Sleep(2000);


                registrationPage.ClickGenderArrow();
                registrationPage.SelectFemale();
                //Thread.Sleep(2000);
                registrationPage.SelectNationalityArrow();
                registrationPage.SelectNationality();
                //Thread.Sleep(2000);
                registrationPage.SelectStateArrow();
                registrationPage.SelectState();
                //Thread.Sleep(2000);
                registrationPage.EnterCity(city);
               // Thread.Sleep(2000);
                registrationPage.EnterMobileNumber(mobileNo);
                //Thread.Sleep(2000);
                registrationPage.SelectEducationLevelArrow();
                registrationPage.SelectEducationLevel();
                //Thread.Sleep(2000);
                registrationPage.SelectEducationEstArrow();
                registrationPage.SelectEducationEstablishment();
                //Thread.Sleep(2000);
                registrationPage.SelectCourseArrow();
               //Thread.Sleep(2000);
                registrationPage.SelectCourse();
                //Thread.Sleep(2000);
                registrationPage.SelectInstitutionArrow();
                registrationPage.SelectInstitute();
                //Thread.Sleep(2000);
                registrationPage.SelectPassingDateArrow(passingDate);
                //Thread.Sleep(2000);
                registrationPage.SelectExperience();
                //Thread.Sleep(2000);
                registrationPage.SelectRelocate();
                //Thread.Sleep(2000);
                registrationPage.SelectBrowse(filePath);
                //Thread.Sleep(5000);
                registrationPage.ClickRegisterButton();
                Thread.Sleep(2000);
                
                IWebElement modalconfirm = driver.FindElement(By.XPath("//span[contains(text(),'Are')]"));
                //TakeScreenShot();
                try
                {

                    Assert.That(modalconfirm.Text.Contains("Are"));
                    Log.Information("Test passed for AJIO Career Test");

                    test = extent.CreateTest("AJIO Career Test");
                    test.Pass("AJIO Career Test success");

                }
                catch (AssertionException ex)
                {
                    Log.Error($"Test failed for AJIO Career. \n Exception: {ex.Message}");

                    test = extent.CreateTest("AJIO Career Test");
                    test.Fail("AJIO Career Test failed");
                }

            }
            Log.CloseAndFlush();
        }
    }
}
