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
    public static class Dashboard_Actions
    {
        public static By username = By.XPath("//input[@type='text']");
        public static By password = By.XPath("//input[@type='password']");
        public static By signin = By.XPath("//button[text()='Login Now']");
        public static By general = By.XPath("/html/body/div[1]/div[2]/aside/div/ul/li[2]");
        public static By DashboardAction = By.XPath("//span[text()='Dashboard Actions']");

        public static By Actioncode = By.XPath("//label[text()='Action Code*']//parent:: div/div/input");
        public static By Actionname = By.XPath("//label[text()='Action Name*']//parent:: div/div/input");
        public static By Actionpath = By.XPath("//label[text()='Action Path*']//parent:: div/div/input");
        public static By Actionicon = By.XPath("//label[text()='Action Icon*']//parent:: div/div/div");
        public static By Icon = By.XPath("//label[text()='Action Code*']//parent:: div/div/input");
        public static By Submit = By.XPath("//span[text()='Submit']");
        public static By DashboardAssignment = By.XPath("//button[text()='Dashboard Action Assignment']");
        public static By Action = By.XPath("//label[text()='Action*']//parent:: div/div/div/div/div/input");
        public static By Role = By.XPath("//label[text()='Role*']//parent:: div/div/div/div/div/input");

        public static By Profile = By.XPath("//div[contains(@class, 'MuiAvatar-root MuiAvatar-circular profileAvatar floatRight mt15 MuiAvatar-colorDefault')]");
        public static By Logout = By.XPath("//span[text()='Logout']");

    }

    public class Dashboard_Action_Method
    {
        private IWebDriver driver;

        public Dashboard_Action_Method(IWebDriver driver)
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
            Wait(20, Dashboard_Actions.username);
            Thread.Sleep(1000);
        }

        public void Username(string Username)
        {
            driver.FindElement(Dashboard_Actions.username).SendKeys(Username);
            Thread.Sleep(1000);
        }

        public void Password(string Password)
        {
            driver.FindElement(Dashboard_Actions.password).SendKeys(Password);
            Thread.Sleep(1000);
        }
        public void LoginNow()
        {
            driver.FindElement(Dashboard_Actions.signin).Click();
            Wait(20, Approval_Attribute.general);
            Thread.Sleep(1000);
        }

        public void Sidebar()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Dashboard_Actions.general));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();
            Thread.Sleep(1000);
        }

        public void DashboardActions()
        {
            driver.FindElement(Dashboard_Actions.DashboardAction).Click();
            Thread.Sleep(500);
        }

        public void Actioncode(string text1)
        {
            driver.FindElement(Dashboard_Actions.Actioncode).Click();
            Thread.Sleep(500);
            driver.FindElement(Dashboard_Actions.Actioncode).SendKeys(text1);
            Thread.Sleep(500);
        }

        public void ActionName(string text1)
        {
            driver.FindElement(Dashboard_Actions.Actionname).Click();
            Thread.Sleep(500);
            driver.FindElement(Dashboard_Actions.Actionname).SendKeys(text1);
            Thread.Sleep(500);
        }

        public void ActionPath(string text1)
        {
            driver.FindElement(Dashboard_Actions.Actionpath).Click();
            Thread.Sleep(500);
            driver.FindElement(Dashboard_Actions.Actionpath).SendKeys(text1);
            Thread.Sleep(500);
        }

        public void ActionIcon()
        {
            driver.FindElement(Dashboard_Actions.Actionicon).Click();
            Thread.Sleep(500);
            driver.FindElement(Dashboard_Actions.Icon).Click();
            Thread.Sleep(500);
        }

        public void Submit()
        {
            driver.FindElement(Dashboard_Actions.Submit).Click();
            Thread.Sleep(500);
        }

        public void DashboardAssignment()
        {
            driver.FindElement(Dashboard_Actions.DashboardAssignment).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Dashboard_Actions.Action));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();
        }

        public void Action(string text1)
        {
            driver.FindElement(Dashboard_Actions.Action).SendKeys(text1);
            Thread.Sleep(500);
            driver.FindElement(Dashboard_Actions.Action).SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            driver.FindElement(Dashboard_Actions.Action).SendKeys(Keys.Enter);
            Thread.Sleep(500);
        }

        public void Role(string text1)
        {
            driver.FindElement(Dashboard_Actions.Role).SendKeys(text1);
            Thread.Sleep(500);
            driver.FindElement(Dashboard_Actions.Role).SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            driver.FindElement(Dashboard_Actions.Role).SendKeys(Keys.Enter);
            Thread.Sleep(500);
        }


        public void LogOut()
        {
            driver.FindElement(Dashboard_Actions.Profile).Click();
            Thread.Sleep(500);

            driver.FindElement(Dashboard_Actions.Logout).Click();
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
