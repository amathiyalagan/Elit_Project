using System;
using System.Collections.Generic;
using System.Linq;
using AventStack.ExtentReports;
using ELIT_Selenium_TR.Config;
using ELIT_Selenium_TR.PageMethods.Purchase_Order;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Text;

namespace ELIT_Selenium_TR.TestCases.Purchase_Order_Test
{
    [TestFixture]
    public class PurchaseOrderTest : ReportsGenerationClass
    {
        PurchaseOrderCreation POC;

        [Test, Order(1)]
        [Category("Purchase Order Creation")]
        public void PurchaseOrderCreationTest()
        {
            try
            { 
                POC = new PurchaseOrderCreation(GetDriver());

                POC.GoToPage("https://atsuat.elit.ai/");
                POC.UserName("PPRITI");
                POC.Password("Atsdxb@003");
                POC.SignIn();
                _test.Log(Status.Pass, "Buyer Logged in");

                POC.Orders();
                POC.Purchase_order();
                POC.Create();
                POC.Header_Title("PO 0110062022");
                POC.Operating_Unit("Appstec ERP Solutions Pvt. Ltd.");
                POC.Order_Type("Standard Purchase Order");
                POC.Supplier("ORACLE SYSTEMS LIMITED");
                POC.Supplier_Site("ORACLE SYSTEM");
                POC.Supplier_Contact("Mohammad  Mohammad ");
                //POC.Currency_Code("UAE Dirham");
                POC.Notes_To_Approver("Please Approve the Purchase Order");
                POC.Attachment(@"C:\Users\ATSTC004\Pictures\ELIT-1.png");
                _test.Log(Status.Pass, "Filled Header");
                POC.Terms_Conditions();
                POC.Ship_To_Location("India-Bangalore");
                POC.Bill_to_Location("India-Bangalore");
                POC.Payment_Terms("15 Days");
                POC.Freight_Terms("Due");
                POC.Carrier("Aramex");
                _test.Log(Status.Pass, "Filled Terns and Conditions");
                POC.Lines();
                POC.CL_Goods("Create Line", "Goods", "ATS-0001", "100", "1250", "India-Bangalore", "16-Jun-2022", "16-Jun-2022", "GOODS", "QUANTITY",@"C:\Users\ATSTC004\Pictures\ELIT-1.png");
                POC.CL_Services("Create Line", "Fixed Price Services", "Administation", "Each", "150", "1000", "India-Bangalore", "1000", "990", "1100", "16-Jun-2022", "16-Jun-2022", "SERVICES", "AMOUNT", @"C:\Users\ATSTC004\Pictures\ELIT-1.png");
                POC.Action();
                POC.Preview();
                POC.Submit();
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
                        POC.ErrorValidation();
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
                POC.closeBrowser();
            }
        }
    }
}
