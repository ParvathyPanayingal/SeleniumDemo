using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AJIO.PageObjects
{
    internal class RegistrationPage
    {
        IWebDriver driver;
        public RegistrationPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='User Id']")]       
        private IWebElement? UserIdField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='E-mail']")]
        private IWebElement? EmailField { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Password']")]
        private IWebElement? PasswordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Confirm Password']")]
        private IWebElement? ConfirmPasswordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='First Name']")]
        private IWebElement? FirstNameField { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Last Name']")]
        private IWebElement? LastNameField { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id=\"__xmlview2--gender_cBoxId-arrow\"]")]
        private IWebElement? GenderArrow { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@id=\"__item2\"]")]
        private IWebElement? FemaleOption { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//span[@id=\"__xmlview2--nationalityPInfo_txtId__vhi\"]")]
        private IWebElement? NationalityArrow { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@id=\"__item13-__clone0\"]")]
        private IWebElement? NationalityField { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//li[@id=\"__item14-__clone37\"]")]
        private IWebElement? StateField { get; set; }
        
        [FindsBy(How = How.XPath, Using = "(//input[@placeholder=\"City\"])[1]")]
        private IWebElement? CityField { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input[@placeholder=\"Mobile Number\"]")]
        private IWebElement? MobileNumberField { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//li[@id=\"__item11-__xmlview2--eduLevel_cBoxId-3\"]")]
        private IWebElement? EducationLevelField { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@id=\"__item12-__xmlview2--eduEstab_cBoxId-1\"]")]
        private IWebElement? EducationEstablishmentField { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='BS']")]
        private IWebElement? CourseField { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[text()='Anna University, Chennai']")]
        private IWebElement? InstituteField { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@id=\"__xmlview2--passYr_dtpId-cal--Month0-20231121\"]")]
        private IWebElement? PassOutDate { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@id=\"__xmlview2--fresher_rBtnId-Button\"]")]
        private IWebElement? Experience { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@id=\"__xmlview2--w2rNo_rBtnId-Button\"]")]
        private IWebElement? Relocate { get; set; }
        
        [FindsBy(How = How.Id, Using = "__xmlview2--resume_fUploadId-fu")]
        private IWebElement? BrowseFile { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//button[@id=\"__xmlview2--submit_btnId\"]")]
        private IWebElement? RegisterButton { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//span[text()='OK']")]
        private IWebElement? ConfirmRegistrationButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder=\"Select Date Of Birth\"]")]
        private IWebElement? DateOfBirth { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//span[@id=\"__xmlview2--statePInfo_txtId__vhi\"]")]
        private IWebElement? StateArrow { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@id='__xmlview2--eduLevel_cBoxId']")]
        private IWebElement? EducationLevelArrow { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@id=\"__xmlview2--eduEstab_cBoxId\"]")]
        private IWebElement? EducationEstArrow { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input[@placeholder=\"Select Education/Course\"]")]
        private IWebElement? CourseArrow { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@id='__xmlview2--institute_txtId']")]
        private IWebElement? InstitutionArrow { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder=\"Select Passing Date\"]")]
        private IWebElement? PassingDateArrow { get; set; }

        public void SelectPassingDateArrow(string PassingDate)
        {
            PassingDateArrow?.Click();
            PassingDateArrow?.SendKeys(PassingDate);
        }

        public void SelectInstitutionArrow()
        {
            InstitutionArrow?.Click();
        }
        public void SelectCourseArrow()
        {
            CourseArrow?.Click();
        }
        public void SelectEducationEstArrow()
        {
            EducationEstArrow?.Click();
        }
        public void SelectStateArrow()
        {
            StateArrow?.Click();
        }

        public void SelectEducationLevelArrow()
        {
            EducationLevelArrow?.Click();
        }

        public void SelectNationalityArrow()
        {
            NationalityArrow?.Click();
        }


        public void EnterUserId(string UserId)
        {
            UserIdField?.SendKeys(UserId);
        }

        public void EnterEmail(string Email)
        {
            EmailField?.SendKeys(Email);
        }

        public void EnterPassword(string Password)
        {
            PasswordField?.SendKeys(Password);
        }

        public void EnterConfirmPassword(string ConPassword)
        {
            ConfirmPasswordField?.SendKeys(ConPassword);
        }

        public void EnterFirstName(string FirstName)
        {
            FirstNameField?.SendKeys(FirstName);
        }

        public void EnterLastName(string LastName)
        {
            LastNameField?.SendKeys(LastName);
        }

        public void ClickGenderArrow()
        {
            GenderArrow?.Click();
        }

        public void SelectFemale()
        {
            FemaleOption?.Click();
        }

        public void SelectNationality()
        {
            NationalityField?.Click();
        }

        public void SelectState()
        {
            StateField?.Click();
        }

        public void EnterCity(string City)
        {
            CityField?.SendKeys(City);
        }

        public void EnterMobileNumber(string MobileNo)
        {
            MobileNumberField?.SendKeys(MobileNo);
        }

        public void SelectEducationLevel()
        {
            EducationLevelField?.Click();
        }

        public void SelectEducationEstablishment()
        {
            EducationEstablishmentField?.Click();
        }

        public void SelectCourse()
        {

            CourseField?.Click();
        }

        public void SelectInstitute()
        {
            InstituteField?.Click();
        }

        public void SelectPassOutDate()
        {
            PassOutDate?.Click();
        }

        public void SelectExperience()
        {
            Experience?.Click();
        }

        public void SelectRelocate()
        {
            Relocate?.Click();
        }
        public void SelectBrowse(string FilePath)
        {
            BrowseFile?.SendKeys(FilePath);
        }
       

        public void ClickRegisterButton()
        {
            RegisterButton?.Click();
        }

        public void ClickConfirmRegistration()
        {
            ConfirmRegistrationButton?.Click();
        }

        public void SelectDateOfBirth(string Date)
        {
            DateOfBirth?.SendKeys(Date);
        }

        

    }
}
