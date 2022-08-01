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
    class Dashboard_Action_Test : ReportsGenerationClass
    {
        Dashboard_Action_Method DAM;

        [Test, Order(1)]
        [Category("Add dashboard Action")]

        public void Create_dashboard_Action()
        {
            DAM = new Dashboard_Action_Method(GetDriver());

            try
            {
                DAM.GoToPage("http://localhost:3000/");
                DAM.Username("ATHANIGA");
                DAM.Password("Atsdxb@003");
                DAM.LoginNow();
                _test.Log(Status.Pass, "Supplier Logged In");

                DAM.Sidebar();
                DAM.DashboardActions();
                DAM.Actioncode("Auction");
                DAM.ActionName("AuctionCreation");
                DAM.ActionPath("/1eb9e046-7fd6-4da9-b356-2b8f152cb344");
                DAM.ActionIcon();
                DAM.Submit();
                _test.Log(Status.Pass, "Add Dashboard Action has been done");

                DAM.DashboardAssignment();
                DAM.Action("Auction Creation");
                DAM.Role("Administrator");
                DAM.Submit();
                _test.Log(Status.Pass, "Add Dashboard Assignment has been done");


                DAM.LogOut();
                DAM.closeBrowser();
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
                        DAM.ErrorValidation();
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
