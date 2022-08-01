using AventStack.ExtentReports;
using ELIT_Selenium_PRJ.PageMethods;
using ELIT_Selenium_TR.Config;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELIT_Selenium_PRJ.TestCases
{
    [TestFixture]
    public class RequisitionApprovalTest : ReportsGenerationClass
    {
        Requisition_Approval RA;
        [Test, Order(1)]
        [Category("Requisition Approval")]

        public void RequisitionApprovalReq()
        {
            RA = new Requisition_Approval(GetDriver());

            try
            {
                RA.GoToPage("http://localhost:3000/");
                RA.UserName("RAMANA.KALLEPALLI");
                RA.Password("Atsdxb@003");
                RA.SignIn();
                _test.Log(Status.Pass, "Approver Logged in");

                RA.Approval();
                RA.Approval_Notification();
                _test.Log(Status.Pass, "Clicked on Supplier Profile");

                RA.Ripplebutton();
                RA.ReqApproval();
                RA.Approval_Search("1373");
                RA.Select_Profile();
                _test.Log(Status.Pass, "Profile Selected Successfully");

                RA.Action();
                RA.Approve();
                RA.Comments("APPROVED");
                RA.Approved();
                RA.LogOut();
                RA.closeBrowser();


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
                        RA.ErrorValidation();
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
            finally
            {
                RA.closeBrowser();
            }

        }

        [Test, Order(2)]
        [Category("Requisition Rejection")]

        public void Rejecting_Requisition_Approval()
        {
            RA = new Requisition_Approval(GetDriver());

            try
            {
                RA.GoToPage("http://localhost:3000/");
                RA.UserName("RAMANA.KALLEPALLI");
                RA.Password("Atsdxb@003");
                RA.SignIn();
                _test.Log(Status.Pass, "Approver Logged in");

                RA.Approval();
                RA.Approval_Notification();
                _test.Log(Status.Pass, "Clicked on Supplier Profile");

                RA.Ripplebutton();
                RA.ReqApproval();
                RA.Approval_Search("1373");
                RA.Select_Profile();
                _test.Log(Status.Pass, "Profile Selected Successfully");

                RA.Action();
                RA.Reject();
                RA.Comments("Rejected");
                RA.Rejected();
                _test.Log(Status.Pass, "Requisition Rejected Successfully");
                RA.LogOut();
                RA.closeBrowser();
                _test.Log(Status.Pass, "Browser Closed");


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
                        RA.ErrorValidation();
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
            finally
            {
                RA.closeBrowser();
            }



        }

    }
}
