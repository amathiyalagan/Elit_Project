using AventStack.ExtentReports;
using ELIT_Selenium_PRJ.PageMethods.Demo_Admin;
using ELIT_Selenium_TR.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELIT_Selenium_PRJ.TestCases.Demo_AdminTests
{
    [TestFixture]
    class MenuCreationTest : ReportsGenerationClass
    {
        MenuCreation MC;
        [Test, Order(1)]
        [Category("Menu Creation")]

        public void MenuCreation()
        {
            MC = new MenuCreation(GetDriver());

            try
            {
                MC.GoToPage("http://localhost:3000/");
                MC.UserName("ATHANIGA");
                MC.Password("Atsdxb@003");
                MC.SignIn();
                _test.Log(Status.Info,"Buyer Logged in");

                MC.General();
                MC.menu();
                MC.Menucode("Gen_Mod");
                MC.Menuname("Module");
                MC.MenuDescriptions("Menu Creation");
                MC.Submitbutton();
                _test.Log(Status.Info, "Menu Creation Has been done");

                MC.MenuAssign();
                MC.Modname("test");
                MC.Name("Module");
                MC.SubName("Menu");
                MC.MenuDescriptions("Menu Assignment has been done");
                MC.Submitbutton();
                _test.Log(Status.Info, "Menu Assignment has been done");

                MC.LogOut();
                _test.Log(Status.Info, "Buyer Logged out");
            }
            catch (Exception ex)
            {
                DateTime time = DateTime.Now;
                String fileName = "Screenshot_" + time.ToString("dd_MM_yyyy_hh_mm_ss") + ".png";
                String screenShotPath = Capture(_driver, fileName);
                _test.Log(Status.Fail, ex.ToString());
                _test.Log(Status.Fail, "Snapshot below: " + _test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
            }
            finally
            {
                MC.closeBrowser();
            }
        }

       
    }
}
