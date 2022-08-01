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
    class Approval_Attribute_Test : ReportsGenerationClass
    {
        Approval_Attribute_Method AAM;

        [Test, Order(1)]
        [Category("Approval Attribute Testing")]

        public void Create_Approval_Attribute()
        {
            AAM = new Approval_Attribute_Method(GetDriver());

            try
            {
                AAM.GoToPage("http://localhost:3000/");
                AAM.Username("ATHANIGA");
                AAM.Password("Atsdxb@003");
                AAM.LoginNow();
                _test.Log(Status.Pass, "Supplier Logged In");

                AAM.Sidebar();
                AAM.ApprovalAttribute();
                AAM.ApprovalType("Contract Approval");
                AAM.AttributeType("DROPDOWN");
                AAM.AttributeCode("Contract_Type");
                AAM.Attributename("Contract_Type");
                AAM.Viewlink("Y3JlYXRlQXBwcm92YWxBdHRyaWJ1dGVz");
                AAM.linkParameter("Contract_Type");
                AAM.Submit();
                _test.Log(Status.Pass, "Approval Attribute Creation has been Done");

                AAM.LogOut();
                AAM.closeBrowser();
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
                        AAM.ErrorValidation();
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
