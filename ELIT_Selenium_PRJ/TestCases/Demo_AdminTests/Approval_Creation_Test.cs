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
    class Approval_Creation_Test : ReportsGenerationClass
    {

        Approval_Creation_Method AC;

        [Test, Order(1)]
        [Category("Approval Creation Testing")]

        public void Create_Approval()
        {
            AC = new Approval_Creation_Method(GetDriver());

            try
            {
                AC.GoToPage("http://localhost:3000/");
                AC.Username("ATHANIGA");
                AC.Password("Atsdxb@003");
                AC.LoginNow();
                _test.Log(Status.Pass, "Supplier Logged In");

                AC.Sidebar();
                AC.ApprovalCreation();
                AC.ApprovalType("Bank Account Approval");
                AC.AuthorizedPerson("Ms.Sirisha Sagi");
                AC.Level("1");
                AC.DelegateUser("Ms. Ashaka singh");
                AC.Submit();
                _test.Log(Status.Pass, "Approval Creation has been done");

                AC.LogOut();
                AC.closeBrowser();
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
                        AC.ErrorValidation();
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