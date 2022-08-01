using AventStack.ExtentReports;
using ELIT_Selenium_TR.Config;
using ELIT_Selenium_TR.PageMethods.RFQ.Standard;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELIT_Selenium_TR.TestCases.RFQTests.Standard
{
    [TestFixture]
    class StandardSRCreationTest : ReportsGenerationClass
    {
        StandardRFQCreation SRC;

        [Test, Order(1)]
        [Category("Standard RFQ Creation")]
        public void Standard_RFQ_Creation_Approvals()
        {
            SRC = new StandardRFQCreation(GetDriver());

            try
            {
                SRC.GoToPage("https://atsuat.elit.ai/");
                SRC.UserName("SIRISHA.SAGI");
                SRC.Password("Atsdxb@003");
                SRC.SignIn();
                _test.Log(Status.Pass, "Buyer Logged In");

                SRC.Sourcing();
                SRC.Quotation();
                SRC.Create();
                _test.Log(Status.Pass, "Clicked on Create NEW RFQ");

                SRC.Header_Title("STANDARD RFQ CREATION on June2022");
                SRC.Document_Type("Standard");
                SRC.Secutity("Public");
                SRC.OU("Appstec ERP Solutions Pvt. Ltd.");
                SRC.PO_Type("Standard");
                SRC.Enable_EMD();
                SRC.Description("STANDARD RFQ CREATION 37 of 40 on APR2022");
                _test.Log(Status.Pass, "Filled Header");
                
                SRC.Terms_Conditions();
                SRC.Bill_to_Address("India-Bangalore");
                SRC.Ship_To_Address("India-Bangalore");
                SRC.Payment_Terms("15 Days");
                SRC.Freight_Terms("AIR");
                SRC.EMD("10", "17-Jun-2022", "Bank Guarantee", "Should pay as per Conditions");
                _test.Log(Status.Pass, "Filled Terms and Conditions");

                SRC.Requirements();
                SRC.Requirement_AddSection("Technical", "Technical");
                SRC.Requirement_AddSection("Commercial", "Commercial");
                SRC.Requirement_AddRequirement_Internal("Technical", "Technical-Internal", "Internal", "Number", "Please Evaluate", "5", "5");
                SRC.Requirement_AddRequirement_Supplier("Technical", "Technical-Supplier", "Supplier", "Number", "Please Evaluate", "5");
                SRC.Requirement_AddRequirement_Internal("Commercial", "Commercial-Internal", "Internal", "Number", "Please Evaluate", "5", "5");
                SRC.Requirement_AddRequirement_Supplier("Commercial", "Commercial-Supplier", "Supplier", "Number", "Please Evaluate", "5");
                _test.Log(Status.Pass, "Requirements added Successfully");

                SRC.Collaboration_Team();
                SRC.CT_TargetDate("18-Jun-2022");
                SRC.Add_CollaborationTeam("Kallepalli Ms.Sirisha", "Scoring", "Technical-Internal", "18-Jun-2022");
                //SRC.Add_CollaborationTeam("Sagi Ms.Sirisha", "Scoring", "Commercial-Internal", "18-Jun-2022");
                _test.Log(Status.Pass, "Collaboration Team added Successfully");

                SRC.Controls();
                SRC.Controls_CloseDate("18-06-2022 5:00 PM");
                SRC.Controls_Rules_AllowSupplier();
                SRC.Controls_Rules_FullQuantity();
                SRC.Controls_Rules_MARS();
                SRC.Controls_Rules_QuoteWithdrawal();
                SRC.Controls_Rules_ManualClose();
                SRC.Controls_Rules_ManualExtend();
                SRC.Controls_Rules_StaggeredAward();
                SRC.Controls_Rules_PublishApproval();
                SRC.Controls_Rules_ManualCloseApproval();
                SRC.Controls_Rules_ManualExtendApprove();
                SRC.Controls_Rules_AwardingApproval();
                _test.Log(Status.Pass, "Controls added Successfully");

                SRC.Notes_Attachments();
                SRC.NA_Note_to_Supplier("Please Find Attachments Below");
                SRC.NA_AddAttachment("Supplier Requirement Details", "File", @"C:\Users\ATSTC004\Pictures\ELIT-155.png", "To Supplier", "Requirement");
                SRC.NA_AddAttachment("Internal Requirement Details", "File", @"C:\Users\ATSTC004\Pictures\ELIT-155.png", "To Internal", "Requirement");
                _test.Log(Status.Pass, "Attachments added Successfully");

                SRC.Lines();
                SRC.Lines_DisplayRank("Win/Lose");
                SRC.Lines_Ranking("Scoring");
                SRC.Lines_CostFactors("Buyer & Supplier");
                _test.Log(Status.Pass, "Lines added Successfully");

                //Goods Type Line
                SRC.CL_Goods("Create Line", "Goods", "MBA001", "150", "JP Nagar, Bangalore", "28-Jul-2022", "28-Jul-2022");
                _test.Log(Status.Pass, "Line Created Successfully");

                //SRC.Add_Attribute("Density", "Durability", "Required", "Number", "6");
                //_test.Log(Status.Pass, "Attributes added Successfully");

                //SRC.Add_CostFactor("DUTY", "5");
                //_test.Log(Status.Pass, "CostFactors added Successfully");

                SRC.LinesCreate_Apply();
                _test.Log(Status.Pass, "Created Line Successfully!!");
               

                //Fixed Price Service Type Line
                SRC.CL_Services("Create Line", "Fixed Price Services", "Computer Accessories and Supplies", "Box of 100", "100", "JP Nagar, Bangalore", "1200", "1700", "1600", "28-Jul-2022", "28-Jul-2022");

                //SRC.Add_Attribute("Density", "Durability", "Required", "Date", "12-Jun-2022");
                //_test.Log(Status.Pass, "Attributes added Successfully");

                //SRC.Add_CostFactor("DUTY", "5");
               //_test.Log(Status.Pass, "CostFactors added Successfully");

                SRC.LinesCreate_Apply();
                _test.Log(Status.Pass, "Created Line Successfully!!");


                //Goods Type Line
                SRC.CL_Goods("Create Line", "Goods", "MBA001", "150", "JP Nagar, Bangalore", "28-Jul-2022", "28-Jul-2022");
                _test.Log(Status.Pass, "Line Created Successfully");

                //SRC.Add_Attribute("Density", "Durability", "Required", "Number", "6");
                //_test.Log(Status.Pass, "Attributes added Successfully");

                //SRC.Add_CostFactor("DUTY", "5");
                //_test.Log(Status.Pass, "CostFactors added Successfully");
                
                SRC.LinesCreate_Apply();
                _test.Log(Status.Pass, "Created Line Successfully!!");

                //Fixed Price Service Type Line
                SRC.CL_Services("Create Line", "Fixed Price Services", "Computer Accessories and Supplies", "Box of 100", "100", "JP Nagar, Bangalore", "1200", "1700", "1600", "28-Jul-2022", "28-Jul-2022");

                //SRC.Add_Attribute("Density", "Durability", "Required", "Date", "12-Jun-2022");
                //_test.Log(Status.Pass, "Attributes added Successfully");

                //SRC.Add_CostFactor("DUTY", "5");
                //_test.Log(Status.Pass, "CostFactors added Successfully");

                SRC.LinesCreate_Apply();
                _test.Log(Status.Pass, "Created Line Successfully!!");

                SRC.Supplier();
                SRC.Supplier("ATS ELIT CORPORATION", "DUBAI", "Ramana Kallepalli");
                SRC.Supplier("SHALIMAR PAINTS", "JEBEL ALI", "John Doe");
                _test.Log(Status.Pass, "Suppliers added Successfully");

                SRC.Action();
                SRC.Preview();
                _test.Log(Status.Pass, "Entered Preview Mode");
                SRC.Action();
                SRC.Publish();
                //SRC.ActionReqPublish();
                //SRC.PublishDescription("Please Approve for Publish");
                //SRC.ReqPublish();

                //_test.Log(Status.Pass, "Requested for Publish");

                SRC.LOGOUT();
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
                        SRC.ErrorValidation();
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
                SRC.closeBrowser();
            }
        }

        [Test, Order(2)]
        [Category("Standard RFQ Creation")]
        public void Standard_RFQ_Creation()
        {
            SRC = new StandardRFQCreation(GetDriver());

            try
            {
                SRC.GoToPage("https://uat.elit.ai/");
                SRC.UserName("ATHANIGA");
                SRC.Password("Atsdxb@003");
                SRC.SignIn();
                _test.Log(Status.Pass, "Buyer Logged In");

                SRC.Sourcing();
                SRC.Quotation();
                SRC.Create();
                _test.Log(Status.Pass, "Clicked on Create NEW RFQ");

                SRC.Header_Title("RFQ CREATION 39 of 40 on APR2022");
                SRC.Document_Type("Standard");
                SRC.Secutity("Public");
                SRC.OU("Appstec Technology Services");
                SRC.PO_Type("Standard");
                SRC.Enable_EMD();
                SRC.Description("STANDARD RFQ CREATION 39 of 40 on APR2022");
                _test.Log(Status.Pass, "Filled Header");

                SRC.Terms_Conditions();
                SRC.Bill_to_Address("BLR");
                SRC.Ship_To_Address("BLR");
                SRC.Payment_Terms("50%");
                SRC.Freight_Terms("AIR");
                SRC.EMD("10", "20-Apr-2022", "Bank Guarantee", "Should pay as per Conditions");
                _test.Log(Status.Pass, "Filled Terms and Conditions");

                SRC.Requirements();
                SRC.Requirement_AddSection("Technical", "Technical");
                SRC.Requirement_AddSection("Commercial", "Commercial");
                SRC.Requirement_AddRequirement_Internal("Technical", "Technical-Internal", "Internal", "Number", "Please Evaluate", "5", "5");
                SRC.Requirement_AddRequirement_Supplier("Technical", "Technical-Supplier", "Supplier", "Date", "Please Evaluate", "20-Apr-2022");
                SRC.Requirement_AddRequirement_Internal("Commercial", "Commercial-Internal", "Internal", "Number", "Please Evaluate", "5", "5");
                SRC.Requirement_AddRequirement_Supplier("Commercial", "Commercial-Supplier", "Supplier", "URL", "Please Evaluate", "https://djhablog.medium.com/selenium-with-nunit-extentreports-df8ac63acb2c");
                _test.Log(Status.Pass, "Requirements added Successfully");

                SRC.Collaboration_Team();
                SRC.CT_TargetDate("20-Apr-2022");
                SRC.Add_CollaborationTeam("Mr.Ramana Kallepalli", "Scoring", "Technical-Internal", "20-Apr-2022");
                SRC.Add_CollaborationTeam("Ms.Sirisha Sagi", "Scoring", "Commercial-Internal", "20-Apr-2022");
                _test.Log(Status.Pass, "Collaboration Team added Successfully");

                SRC.Controls();
                SRC.Controls_CloseDate("20-04-2022 9:00 PM");
                SRC.Controls_Rules_AllowSupplier();
                SRC.Controls_Rules_FullQuantity();
                SRC.Controls_Rules_MARS();
                SRC.Controls_Rules_QuoteWithdrawal();
                SRC.Controls_Rules_ManualClose();
                SRC.Controls_Rules_ManualExtend();
                SRC.Controls_Rules_StaggeredAward();
                _test.Log(Status.Pass, "Controls added Successfully");

                SRC.Notes_Attachments();
                SRC.NA_Note_to_Supplier("Please Find Attachments Below");
                SRC.NA_AddAttachment("Supplier Requirement Details", "File", @"C:\Users\ATS003A\Pictures\ELIT-120.png", "To Supplier", "Requirement");
                SRC.NA_AddAttachment("Internal Requirement Details", "File", @"C:\Users\ATS003A\Pictures\ELIT-120.png", "To Internal", "Requirement");
                _test.Log(Status.Pass, "Attachments added Successfully");

                SRC.Lines();
                SRC.Lines_DisplayRank("Win/Lose");
                SRC.Lines_Ranking("Scoring");
                SRC.Lines_CostFactors("Buyer & Supplier");
                _test.Log(Status.Pass, "Lines added Successfully");

                //Goods Type Line
                SRC.CL_Goods("Create Line", "Goods", "34567", "150", "BLR", "20-Apr-2022", "20-Apr-2022");
                _test.Log(Status.Pass, "Line Created Successfully");

                //SRC.Add_Attribute("Density", "Durability", "Required", "Number", "5");
                //_test.Log(Status.Pass, "Attributes added Successfully");

                //SRC.Add_CostFactor("DUTY", "5");
                //_test.Log(Status.Pass, "CostFactors added Successfully");

                SRC.LinesCreate_Apply();
                _test.Log(Status.Pass, "Created Line Successfully!!");


                //Fixed Price Service Type Line
                SRC.CL_Services("Create Line", "Fixed Price Services", "Computer Accessories and Supplies", "Box of 100", "100", "BLR", "1200", "1700", "1600", "20-Apr-2022", "20-Apr-2022");

                //SRC.Add_Attribute("Density", "Durability", "Required", "Number", "5");
                //_test.Log(Status.Pass, "Attributes added Successfully");

                //SRC.Add_CostFactor("DUTY", "5");
                //_test.Log(Status.Pass, "CostFactors added Successfully");

                SRC.LinesCreate_Apply();
                _test.Log(Status.Pass, "Created Line Successfully!!");


                //Goods Type Line
                SRC.CL_Goods("Create Line", "Goods", "34567", "150", "BLR", "20-Apr-2022", "20-Apr-2022");
                _test.Log(Status.Pass, "Line Created Successfully");

                //SRC.Add_Attribute("Density", "Durability", "Required", "Number", "5");
                //_test.Log(Status.Pass, "Attributes added Successfully");

                //SRC.Add_CostFactor("DUTY", "5");
                //_test.Log(Status.Pass, "CostFactors added Successfully");

                SRC.LinesCreate_Apply();
                _test.Log(Status.Pass, "Created Line Successfully!!");

                //Fixed Price Service Type Line
                SRC.CL_Services("Create Line", "Fixed Price Services", "Computer Accessories and Supplies", "Box of 100", "100", "BLR", "1000", "1500", "1400", "20-Apr-2022", "20-Apr-2022");

                //SRC.Add_Attribute("Density", "Durability", "Required", "Number", "5");
                //_test.Log(Status.Pass, "Attributes added Successfully");

                //SRC.Add_CostFactor("DUTY", "5");
                //_test.Log(Status.Pass, "CostFactors added Successfully");

                SRC.LinesCreate_Apply();
                _test.Log(Status.Pass, "Created Line Successfully!!");

                SRC.Supplier();
                SRC.Supplier("BENAKE BOXIMAIL PVT LTD", "BENAKE", "Sinchana gowda");
                SRC.Supplier("DUQESYCAB GETAIRMAIL PVT LTD", "BENAKE", "Jyotheesh Kummara");
                _test.Log(Status.Pass, "Suppliers added Successfully");

                SRC.Action();
                SRC.Preview();
                _test.Log(Status.Pass, "Entered Preview Mode");
                SRC.Action();
                SRC.Publish();

                _test.Log(Status.Pass, "Requested for Publish");

                SRC.LOGOUT();
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
                        SRC.ErrorValidation();
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
                SRC.closeBrowser();
            }
        }
    }
}
