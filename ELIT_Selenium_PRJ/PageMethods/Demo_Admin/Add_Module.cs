using NUnit.Framework;
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
    public static class Add_Module
    {
        public static By username = By.XPath("//input[@type='text']");
        public static By password = By.XPath("//input[@type='password']");
        public static By signin = By.XPath("//button[text()='Login Now']");
        public static By general = By.XPath("/html/body/div[1]/div[2]/aside/div/ul/li[2]");
        public static By Module = By.XPath("//span[text()='Module']");

        public static By Modulecode = By.XPath("//label[text()='Module Code*']//parent :: div/div/input");
        public static By ModuleName = By.XPath("//label[text()='Module Name*']//parent :: div/div/input");
        public static By ModuleIcon = By.XPath("//label[text()='Module Icon*']//parent :: div/div/div");
        public static By Icon = By.XPath("//div[3]/div[1]/div/div/div[1]/div[2]/div[3]/div/div[2]/div/div/ul/li[1]/span");
        public static By ModuleDescription = By.XPath("//label[text()='Module Description*']//parent :: div/div/textarea");
        public static By Submit = By.XPath("//span[text()='Submit']");
        public static By Profile = By.XPath("//div[contains(@class, 'MuiAvatar-root MuiAvatar-circular profileAvatar floatRight mt15 MuiAvatar-colorDefault')]");
        public static By Logout = By.XPath("//span[text()='Logout']");

        //public static By Modulecodevalidation = By.XPath("#root > div.al-main > div.al-content > div > div > div.panel.color_highlight_bg.color_highlight_text.with-scroll.animated.zoomIn > div.panel-body > div:nth-child(1) > div > span");
        //public static By Modulename_validation = By.XPath("#root > div.al-main > div.al-content > div > div > div.panel.color_highlight_bg.color_highlight_text.with-scroll.animated.zoomIn > div.panel-body > div:nth-child(2) > div > span");
        //public static By Moduleicon_validation = By.XPath("#root > div.al-main > div.al-content > div > div > div.panel.color_highlight_bg.color_highlight_text.with-scroll.animated.zoomIn > div.panel-body > div:nth-child(3) > div > span");
        //public static By Moduledescribtion_validation = By.XPath("#root > div.al-main > div.al-content > div > div > div.panel.color_highlight_bg.color_highlight_text.with-scroll.animated.zoomIn > div.panel-body > div:nth-child(3) > div > span");
    }

    public class Add_Module_Method
    {
        private IWebDriver driver;

        public Add_Module_Method(IWebDriver driver)
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
            Wait(20, Add_Module.username);
            Thread.Sleep(1000);
        }

        public void Username(string Username)
        {
            driver.FindElement(Add_Module.username).SendKeys(Username);
            Thread.Sleep(1000);
        }

        public void Password(string Password)
        {
            driver.FindElement(Add_Module.password).SendKeys(Password);
            Thread.Sleep(1000);
        }

        public void LoginNow()
        {
            driver.FindElement(Add_Module.signin).Click();
            Wait(20, Add_Module.general);
            Thread.Sleep(1000);
        }

        public void Sidebar()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Add_Module.general));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();
            Thread.Sleep(1000);
        }
        public void Module()
        {
            driver.FindElement(Add_Module.Module).Click();
            Thread.Sleep(500);
        }

        public void Modulecode(string text1)
        {
            driver.FindElement(Add_Module.Modulecode).Click();
            driver.FindElement(Add_Module.Modulecode).SendKeys(text1);
            Thread.Sleep(500);
        }

        public void Modulename(string text1)
        {
            driver.FindElement(Add_Module.ModuleName).Click();
            driver.FindElement(Add_Module.ModuleName).SendKeys(text1);
            Thread.Sleep(500);
        }

        public void ModuleIcon()
        {
            driver.FindElement(Add_Module.ModuleIcon).Click();
            Thread.Sleep(500);
            driver.FindElement(Add_Module.Icon).Click();
            Thread.Sleep(500);
        }

        public void ModuleDescription(String text1)
        {
            driver.FindElement(Add_Module.ModuleDescription).Click();
            driver.FindElement(Add_Module.ModuleDescription).SendKeys(text1);
            Thread.Sleep(500);
        }

        public void Submit()
        {
            driver.FindElement(Add_Module.Submit).Click();
            Thread.Sleep(500);
        }

        public void LogOut()
        {
            driver.FindElement(Add_Module.Profile).Click();
            Thread.Sleep(500);

            driver.FindElement(Add_Module.Logout).Click();
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


