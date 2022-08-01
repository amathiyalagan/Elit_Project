using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ELIT_Selenium_PRJ.PageMethods.Demo_Admin
{
    public static class Approval_Creation
    {
        public static By username = By.XPath("//input[@type='text']");
        public static By password = By.XPath("//input[@type='password']");
        public static By signin = By.XPath("//button[text()='Login Now']");
        public static By general = By.XPath("/html/body/div[1]/div[2]/aside/div/ul/li[2]");
        public static By ApprovalCreation = By.XPath("//span[text()='Approval Creation']");

        public static By ApprovalType = By.XPath("//label[text()='Approval Type*']//parent:: div/div/div/div/div/input");
        public static By Authorizedperson = By.XPath("//label[text()='Authorized Person*']//parent:: div/div/div/div/div/input");
        public static By Level = By.XPath("//label[text()='Level*']//parent:: div/div/div/div/div/input");
        public static By DelegateUser = By.XPath("//label[text()='Delegate User']//parent:: div/div/div/div/div/input");
        public static By Submit = By.XPath("//span[text()='Submit']");
        public static By Profile = By.XPath("//div[contains(@class, 'MuiAvatar-root MuiAvatar-circular profileAvatar floatRight mt15 MuiAvatar-colorDefault')]");
        public static By Logout = By.XPath("//span[text()='Logout']");

    }

    public class Approval_Creation_Method
    {
        private IWebDriver driver;

        public Approval_Creation_Method(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Wait(int sec, object obj)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By)obj));
        }

        public void GoToPage(string URL)
        {
            driver.Navigate().GoToUrl(URL);
            Wait(20, Approval_Creation.username);
            Thread.Sleep(1000);
        }

        public void Username(string Username)
        {
            driver.FindElement(Approval_Creation.username).SendKeys(Username);
            Thread.Sleep(1000);
        }

        public void Password(string Password)
        {
            driver.FindElement(Approval_Creation.password).SendKeys(Password);
            Thread.Sleep(1000);
        }

        public void LoginNow()
        {
            driver.FindElement(Approval_Creation.signin).Click();
            Wait(20, Approval_Creation.general);
            Thread.Sleep(1000);
        }

        public void Sidebar()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Approval_Creation.general));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();
            Thread.Sleep(1000);
        }

        public void ApprovalCreation()
        {
            driver.FindElement(Approval_Creation.ApprovalCreation).Click();
            Thread.Sleep(500);
        }

        public void ApprovalType(string text1)
        {
            driver.FindElement(Approval_Creation.ApprovalType).Click();
            driver.FindElement(Approval_Creation.ApprovalType).SendKeys(text1);
            Thread.Sleep(500);
            driver.FindElement(Approval_Creation.ApprovalType).SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            driver.FindElement(Approval_Creation.ApprovalType).SendKeys(Keys.Enter);
            Thread.Sleep(500);
        }

        public void AuthorizedPerson(string text1)
        {
            driver.FindElement(Approval_Creation.Authorizedperson).Click();
            driver.FindElement(Approval_Creation.Authorizedperson).SendKeys(text1);
            Thread.Sleep(500);
            driver.FindElement(Approval_Creation.Authorizedperson).SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            driver.FindElement(Approval_Creation.Authorizedperson).SendKeys(Keys.Enter);
            Thread.Sleep(500);
        }

        public void Level(string text1)
        {
            driver.FindElement(Approval_Creation.Level).Click();
            driver.FindElement(Approval_Creation.Level).SendKeys(text1);
            Thread.Sleep(500);
            driver.FindElement(Approval_Creation.Level).SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            driver.FindElement(Approval_Creation.Level).SendKeys(Keys.Enter);
            Thread.Sleep(500);
        }

        public void DelegateUser(string text1)
        {
            driver.FindElement(Approval_Creation.DelegateUser).Click();
            driver.FindElement(Approval_Creation.DelegateUser).SendKeys(text1);
            Thread.Sleep(500);
            driver.FindElement(Approval_Creation.DelegateUser).SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            driver.FindElement(Approval_Creation.DelegateUser).SendKeys(Keys.Enter);
            Thread.Sleep(500);
        }

        public void Submit()
        {
            driver.FindElement(Approval_Creation.Submit).Click();
            Thread.Sleep(500);
        }

        public void LogOut()
        {
            driver.FindElement(Approval_Creation.Profile).Click();
            Thread.Sleep(500);

            driver.FindElement(Approval_Creation.Logout).Click();
            Thread.Sleep(500);
        }

        public void ErrorValidation()
        {

            string validation_error = "//span[@class='field-validation-error-text '] | //span[@class='field-validation-error-text'] | //div[contains(@class,'Toastify__toast--error')]";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var ve = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(validation_error)));
            Actions action = new Actions(driver);
            action.MoveToElement(ve).Perform();

            bool isvalidationPresent = ve.Displayed;
            if (isvalidationPresent)
            {
                string error = driver.FindElement(By.XPath(validation_error)).GetAttribute("innerHTML");
                throw new InvalidOperationException(error);
            }
        }

        public void closeBrowser()
        {
            driver.Quit();
        }


    }

}
