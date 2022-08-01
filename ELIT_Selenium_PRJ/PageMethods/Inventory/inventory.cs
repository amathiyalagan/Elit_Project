using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ELIT_Selenium_PRJ.PageMethods.Inventory
{
    public static class Createinventory
    {
        public static By username = By.XPath("//input[@type='text']");
        public static By password = By.XPath("//input[@type='password']");
        public static By loginnow = By.XPath("//button[text()='Login Now']");
        public static By sidebar = By.XPath("//ul[contains(@class,'al-sidebar-list')]/li/div/i");
        public static By Orders = By.XPath("//div[text()='Orders']");
        public static By inventory = By.XPath("//span[text()='Inventory']");
        public static By Addinventory = By.XPath("//button[text()='Add Inventory']");
        public static By LanguageENG = By.XPath("//div[text()='ENG']");
        public static By LanguageAR = By.XPath("//div[contains(@class,'react-switch-handle')]");
        public static By Operatingunit = By.XPath("//label[text()='Operating Unit*']//parent::div/div/div/div/div/input");
        public static By itemNumber = By.XPath("//label[text()='Item Number*']//parent::div/div/input");
        public static By Category = By.XPath("//label[text()='Category*']//parent::div/div/div/div/div/input");
        public static By UOM = By.XPath("//label[text()='UOM*']//parent::div/div/div/div/div/input");
        public static By Unitprice = By.XPath("//label[text()='Unit Price*']//parent::div/div/input");
        public static By Taxpercentage = By.XPath("//label[text()='Tax Percentage']//parent::div/div/input");
        public static By Description = By.XPath("//label[text()='Description*']//parent::div/div/textarea");
        public static By Add = By.XPath("//span[text()='Add']");
        public static By Profile = By.XPath("(//div[contains(@class, 'MuiAvatar-root')])[1]");
        public static By Logout = By.XPath("//span[text()='Logout']");

    }

    public class inventorymethod
    {

        private IWebDriver driver;

        public inventorymethod(IWebDriver driver)
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
            Wait(20, Createinventory.username);
            Thread.Sleep(1000);
        }

        public void Username(string Username)
        {
            driver.FindElement(Createinventory.username).SendKeys(Username);
            Thread.Sleep(1000);
        }

        public void Password(string Password)
        {
            driver.FindElement(Createinventory.password).SendKeys(Password);
            Thread.Sleep(1000);
        }

        public void LoginNow()
        {
            driver.FindElement(Createinventory.loginnow).Click();
            Wait(20, Createinventory.sidebar);
            Thread.Sleep(1000);
        }

        public void Sidebar()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Createinventory.sidebar));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            Thread.Sleep(1000);

        }

        public void Orders()
        {
            driver.FindElement(Createinventory.Orders).Click();
            Thread.Sleep(500);
            driver.FindElement(Createinventory.inventory).Click();
            Wait(20, Createinventory.Addinventory);
            Thread.Sleep(1000);
        }

        public void language()
        {
            driver.FindElement(Createinventory.LanguageAR).Click();
            Thread.Sleep(1000);
        }

        public void OperatingUnit(string text1)
        {
            driver.FindElement(Createinventory.Operatingunit).Click();
            Thread.Sleep(500);
            driver.FindElement(Createinventory.Operatingunit).SendKeys(text1);
            driver.FindElement(Createinventory.Operatingunit).SendKeys(Keys.ArrowDown);
            driver.FindElement(Createinventory.Operatingunit).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
        }

        public void Itemnumber(string text1)
        {
            driver.FindElement(Createinventory.itemNumber).Click();
            Thread.Sleep(500);
            driver.FindElement(Createinventory.itemNumber).SendKeys(text1);
            Thread.Sleep(500);
        }

        public void Category(string text1)
        {
            driver.FindElement(Createinventory.Category).Click();
            Thread.Sleep(500);
            driver.FindElement(Createinventory.Category).SendKeys(text1);
            driver.FindElement(Createinventory.Category).SendKeys(Keys.ArrowDown);
            driver.FindElement(Createinventory.Category).SendKeys(Keys.Enter);
            Thread.Sleep(500);
        }

        public void UOM(string text1)
        {
            driver.FindElement(Createinventory.UOM).Click();
            Thread.Sleep(1000);
            driver.FindElement(Createinventory.UOM).SendKeys(text1);
            driver.FindElement(Createinventory.UOM).SendKeys(Keys.ArrowDown);
            driver.FindElement(Createinventory.UOM).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
        }

        public void UnitPrice(string text1)
        {
            driver.FindElement(Createinventory.Unitprice).SendKeys(text1);
            Thread.Sleep(500);
        }

        public void Taxpercentage(string text1)
        {
            driver.FindElement(Createinventory.Taxpercentage).SendKeys(text1);
            Thread.Sleep(500);
        }

        public void Description(string text1)
        {
            driver.FindElement(Createinventory.Description).SendKeys(text1);
            Thread.Sleep(500);
        }

        public void Add()
        {
            driver.FindElement(Createinventory.Add).Click();
            Thread.Sleep(500);
        }

        public void Profile_logout()
        {
            Thread.Sleep(2000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Createinventory.Profile));
            element.Click();
            Thread.Sleep(800);
        }

        public void Logout()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Createinventory.Logout));
            element.Click();
            Thread.Sleep(1000);
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

    

