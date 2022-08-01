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
    public static class Approval_Attribute
    {
        public static By username = By.XPath("//input[@type='text']");
        public static By password = By.XPath("//input[@type='password']");
        public static By signin = By.XPath("//button[text()='Login Now']");
        public static By general = By.XPath("/html/body/div[1]/div[2]/aside/div/ul/li[2]");
        public static By ApprovalAttribute = By.XPath("//span[text()='Approval Attribute']");

        public static By ApprovalType = By.XPath("//label[text()='Approval Type*']//parent :: div/div/div/div/div/input");
        public static By AttributeType = By.XPath("//label[text()='Attribute Type*']//parent :: div/div/div/div/div/input");
        public static By AttributeCode = By.XPath("//label[text()='Attribute Code*']//parent :: div/div/input");
        public static By Attributename = By.XPath("//label[text()='Attribute Name*']//parent :: div/div/input");
        public static By ViewLink = By.XPath("//label[text()='View Link*']//parent :: div/div/input");
        public static By LinkParameter = By.XPath("//label[text()='Link Parameter*']//parent :: div/div/input");
        public static By Submit = By.XPath("//span[text()='Submit']");
        public static By Profile = By.XPath("//div[contains(@class, 'MuiAvatar-root MuiAvatar-circular profileAvatar floatRight mt15 MuiAvatar-colorDefault')]");
        public static By Logout = By.XPath("//span[text()='Logout']");
    }

    public class Approval_Attribute_Method
    {
        private IWebDriver driver;

        public Approval_Attribute_Method(IWebDriver driver)
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
            Wait(20, Approval_Attribute.username);
            Thread.Sleep(1000);
        }

        public void Username(string Username)
        {
            driver.FindElement(Approval_Attribute.username).SendKeys(Username);
            Thread.Sleep(1000);
        }

        public void Password(string Password)
        {
            driver.FindElement(Approval_Attribute.password).SendKeys(Password);
            Thread.Sleep(1000);
        }
        public void LoginNow()
        {
            driver.FindElement(Approval_Attribute.signin).Click();
            Wait(20, Approval_Attribute.general);
            Thread.Sleep(1000);
        }

        public void Sidebar()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Approval_Attribute.general));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();
            Thread.Sleep(1000);
        }

        public void ApprovalAttribute()
        {
            driver.FindElement(Approval_Attribute.ApprovalAttribute).Click();
            Thread.Sleep(500);
        }

        public void ApprovalType(string text1)
        {
            driver.FindElement(Approval_Attribute.ApprovalType).Click();
            Thread.Sleep(500);
            driver.FindElement(Approval_Attribute.ApprovalType).SendKeys(text1);
            Thread.Sleep(500);
            driver.FindElement(Approval_Attribute.ApprovalType).SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            driver.FindElement(Approval_Attribute.ApprovalType).SendKeys(Keys.Enter);
            Thread.Sleep(500);
        }

        public void AttributeType(string text1)
        {
            driver.FindElement(Approval_Attribute.AttributeType).Click();
            Thread.Sleep(500);
            driver.FindElement(Approval_Attribute.AttributeType).SendKeys(text1);
            Thread.Sleep(500);
            driver.FindElement(Approval_Attribute.AttributeType).SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            driver.FindElement(Approval_Attribute.AttributeType).SendKeys(Keys.Enter);
            Thread.Sleep(500);
        }

        public void AttributeCode(string text1)
        {
            driver.FindElement(Approval_Attribute.AttributeCode).Click();
            Thread.Sleep(500);
            driver.FindElement(Approval_Attribute.AttributeCode).SendKeys(text1);
            Thread.Sleep(500);

        }

        public void Attributename(string text1)
        {
            driver.FindElement(Approval_Attribute.Attributename).Click();
            Thread.Sleep(500);
            driver.FindElement(Approval_Attribute.Attributename).SendKeys(text1);
            Thread.Sleep(500);

        }



        public void Viewlink(string text1)
        {
            driver.FindElement(Approval_Attribute.ViewLink).Click();
            Thread.Sleep(500);
            driver.FindElement(Approval_Attribute.ViewLink).SendKeys(text1);
            Thread.Sleep(500);

        }

        public void linkParameter(string text1)
        {
            driver.FindElement(Approval_Attribute.LinkParameter).Click();
            Thread.Sleep(500);
            driver.FindElement(Approval_Attribute.LinkParameter).SendKeys(text1);
            Thread.Sleep(500);

        }

        public void Submit()
        {
            driver.FindElement(Approval_Attribute.Submit).Click();
            Thread.Sleep(500);
        }

        public void LogOut()
        {
            driver.FindElement(Approval_Attribute.Profile).Click();
            Thread.Sleep(500);

            driver.FindElement(Approval_Attribute.Logout).Click();
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
