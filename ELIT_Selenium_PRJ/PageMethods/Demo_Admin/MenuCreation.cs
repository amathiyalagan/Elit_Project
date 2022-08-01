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
    class MenuCreation
    {
        private IWebDriver driver;

        string username = "//input[@type='text']";
        string password = "//input[@type='password']";
        string signin = "//button[text()='Login Now']";
        string general = "/html/body/div[1]/div[2]/aside/div/ul/li[2]";
        string Menu = "//span[text()='Menu']";

        string MenuCode = "//label[text()='Menu Code*']//parent :: Div/div/input";
        string MenuName = "//label[text()='Menu Name*']//parent :: Div/div/input";
        string MenuDescription = "//label[text()='Menu Description*']//parent :: Div/div/textarea";
        string Submit = "//span[text()='Submit']";

        string MenuAssignment = "//button[text()='Menu Assignment']";
        string ModuleName = "//label[text()='Module Name*']//parent :: Div/div/div/div/div/input";
        string MenuName1 = "//label[text()='Menu Name*']//parent :: Div/div/div/div/div/input";
        string SubMenu = "//label[text()='Sub Menu Name']//parent :: Div/div/div/div/div/input";
        string MenuDescription1 = "//label[text()='Menu Description*']//parent :: Div/div/textarea";

        string profile = "//div[contains(@class, 'MuiAvatar-root MuiAvatar-circular profileAvatar floatRight mt15 MuiAvatar-colorDefault')]";
        string logout = "//span[text()='Logout']";

        public MenuCreation(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void GoToPage(string text1)
        {
            driver.Navigate().GoToUrl(text1);
            Thread.Sleep(500);
        }

        public void UserName(String text)
        {
            driver.FindElement(By.XPath(username)).SendKeys(text);
            Thread.Sleep(500);
        }

        public void Password(string text)
        {
            driver.FindElement(By.XPath(password)).SendKeys(text);
            Thread.Sleep(500);
        }

        public void SignIn()
        {
            driver.FindElement(By.XPath(signin)).Click();
            Thread.Sleep(1000);
        }

        public void General()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(general)));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();
            Thread.Sleep(1000);
        }

        public void menu()
        {
            driver.FindElement(By.XPath(Menu)).Click();
            Thread.Sleep(1500);
        }

        public void Menucode(string text)
        {
            driver.FindElement(By.XPath(MenuCode)).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath(MenuCode)).SendKeys(text);
            Thread.Sleep(500);
        }

        public void Menuname(string text)
        {
            driver.FindElement(By.XPath(MenuName)).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath(MenuName)).SendKeys(text);
            Thread.Sleep(500);
        }

        public void MenuDescriptions(string text)
        {
            driver.FindElement(By.XPath(MenuDescription)).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath(MenuDescription)).SendKeys(text);
            Thread.Sleep(500);
        }

        public void Submitbutton()
        {
            driver.FindElement(By.XPath(Submit)).Click();
            Thread.Sleep(500);
        }

        public void MenuAssign()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(ModuleName)));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();
            Thread.Sleep(1000);
        }

        public void Modname(string text)
        {
            driver.FindElement(By.XPath(MenuName)).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath(MenuName)).SendKeys(text);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(MenuName)).SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(MenuName)).SendKeys(Keys.Enter);
            Thread.Sleep(500);
        }


        public void Name(string text)
        {
            driver.FindElement(By.XPath(MenuName)).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath(MenuName)).SendKeys(text);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(MenuName)).SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(MenuName)).SendKeys(Keys.Enter);
            Thread.Sleep(500);
        }

        public void SubName(string text)
        {
            driver.FindElement(By.XPath(SubMenu)).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath(SubMenu)).SendKeys(text);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(SubMenu)).SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            driver.FindElement(By.XPath(SubMenu)).SendKeys(Keys.Enter);
            Thread.Sleep(500);
        }

        public void LogOut()
        {
            
            driver.FindElement(By.XPath(profile)).Click();
            Thread.Sleep(500);

            driver.FindElement(By.XPath(logout)).Click();
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
