using AventStack.ExtentReports;
using ELIT_Selenium_PRJ.PageMethods.Demo_Admin;
using ELIT_Selenium_TR.Config;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELIT_Selenium_PRJ.TestCases.Demo_AdminTests
{
    [TestFixture]
    class Add_Module_Test : ReportsGenerationClass
    {

        Add_Module_Method AM;

        [Test, Order(1)]
        [Category("Add Module Testing")]

        public void Create_Module()
        {
            AM = new Add_Module_Method(GetDriver());

            try
            {
                AM.GoToPage("https://dev.elit.ai/");
                AM.Username("ATHANIGA");
                AM.Password("Atsdxb@003");
                AM.LoginNow();
                _test.Log(Status.Pass, "Supplier Logged In");

                AM.Sidebar();
                AM.Module();
                AM.Modulecode("User 1");
                AM.Modulename("General 2");
                AM.ModuleIcon();
                AM.ModuleDescription("Add Module has been done");
                AM.Submit();
                _test.Log(Status.Pass, "Add Module has been done");

                AM.LogOut();
                AM.closeBrowser();
                _test.Log(Status.Pass, "Profile Logged Out");

            }
            catch (Exception ex)
            {
                if ((ex.GetType() == typeof(OpenQA.Selenium.NoSuchElementException) | (ex.GetType() == typeof(OpenQA.Selenium.WebDriverTimeoutException))))
                {
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" + time.ToString("dd_MM_yyyy_hh_mm_ss") + ".png";
                    String screenShotPath = Capture(_driver, fileName);
                    _test.Log(Status.Fail, ex.ToString());
                    _test.Log(Status.Fail, "Snapshot below: " + _test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
                }
                else
                {
                    try
                    {
                        AM.ErrorValidation();
                    }
                    catch (Exception innerexception)
                    {
                        DateTime time = DateTime.Now;
                        String fileName = "Screenshot_" + time.ToString("dd_MM_yyyy_hh_mm_ss") + ".png";
                        String screenShotPath = Capture(_driver, fileName);
                        _test.Log(Status.Fail, innerexception.ToString());
                        _test.Log(Status.Fail, "Snapshot below: " + _test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
                    }
                }
            }
        }
        }
}
