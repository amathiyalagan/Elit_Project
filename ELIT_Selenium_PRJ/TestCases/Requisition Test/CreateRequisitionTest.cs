using AventStack.ExtentReports;
using ELIT_Selenium_TR.Config;
using ELIT_Selenium_TR.PageMethods.Requisition;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELIT_Selenium_TR.TestCases.Requisition_Test
{
    [TestFixture]
    public class CreateRequisitionTest : ReportsGenerationClass
    {
        CreateRequisition CR;

        [Test,Order(1)]
        [Category("Requisition with Create Line")]

        public void Requisition()
        {
            CR = new CreateRequisition(GetDriver());

            try
            {
                CR.GoToPage("https://atsuat.elit.ai/");
                CR.UserName("PPRITI");
                CR.Password("Atsdxb@003");
                CR.SignIn();
                _test.Log(Status.Pass, "Buyer Logged in");

                CR.Requisition();
                CR.Select_Requisition();
                _test.Log(Status.Pass, "Opened Requisition");

                CR.Create();
                CR.Title("Catalog_CVA0019");
                CR.Catalog_Type("Non Catalog");
                CR.Requested_by("Gowda Mr.Rajashekara");
                CR.Operating_Unit("Appstec ERP Solutions Pvt. Ltd.");
                CR.Ship_To_Location("India-Bangalore");
                CR.Emergency();
                CR.Note_To_Approver("Approve the PR");
                CR.Description("Catalog_CVA0018");
                CR.Fileupload(@"C:\Users\ATSTC004\Pictures\ELIT-155.png");
                _test.Log(Status.Pass, "Requisition Header Filled");

                CR.Lines();
                CR.Create_Line_Services("Create Line", "Fixed Price Services", "Cleaning Items", "12Pack", "10", "10", "Kallepalli Ms.Sirisha", "16-Jun-2022", "YES", "Please Provide ASAP", @"C:\Users\ATSTC004\Pictures\ELIT-155.png", "Finance", "BESCOM", "DUBAI", "Bangalore Limited", "Please Provide Details ASAP");
                _test.Log(Status.Pass, "Line of Fixed Price Service Type is Created");

                CR.Create_Line_Goods("Create Line", "Goods", "ATS-0001", "Administation", "Each", "10", "10", "Kallepalli Mr.Ramana", "16-Jun-2022", "YES", @"C:\Users\ATSTC004\Pictures\ELIT-155.png", "Admin", "DEWA", "DUBAI", "DEWA DEWA", "Please Provide Details ASAP");
                _test.Log(Status.Pass, "Line of Goods Type is Created");


                CR.Action();
                CR.Preview();
                _test.Log(Status.Pass, "Entered Preview Mode");

                CR.Action();
                CR.Submit();
                _test.Log(Status.Pass, "Requisition Submitted Succesfully");

                CR.LogOut();
                _test.Log(Status.Pass, "Buyer Logged Out");

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
                        CR.ErrorValidation();
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
                CR.CloseBrowser();
            }
        }
    }
}
