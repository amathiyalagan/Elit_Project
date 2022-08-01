using AventStack.ExtentReports;
using ELIT_Selenium_TR.Config;
using ELIT_Selenium_TR.PageMethods.Raise_Shipment;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELIT_Selenium_TR.TestCases.Raise_Shipment_Test
{
    [TestFixture]

    public class RaiseShipmentTest : ReportsGenerationClass
    {
        RaiseShipment RS;

        [Test, Order(1)]
        [Category("Raise Shipment")]
        public void Rasie_Shipment()
        {
            RS = new RaiseShipment(GetDriver());

            try
            {
                RS.GoToPage("https://uat.elit.ai/");
                RS.UserName("ASWATHANN@GMAIL.COM");
                RS.Password("Atsdxb@003");
                RS.SignIn();

                RS.Supplier();
                RS.SupplierProfile();
                RS.PurchaseOrder();
                RS.PO_Search("1011");
                RS.Raise_Shipment();
                RS.Line_Select();
                RS.Create_Shipment("Create Shipment");
                RS.Shipment_Number("10251");
                RS.Shipment_Date("17-Jun-2022");
                RS.Expected_Receipt_Date("17-Jun-2022");
                RS.Number_Of_Container("2");
                RS.WayBillNumber("10201");
                RS.PackingCode("10425");
                RS.HandlingCode("10215");
                RS.NetWeight("100");
                RS.UOMNetWeight("10");
                RS.carrier("Aramex");
                RS.Comments("raise shipment done");
                RS.FileUpload(@"C:\Users\ATSTC004\Pictures\ELIT-155.png");
                RS.Shipment_Lines();
                //RS.Shipment_Lines_Pager();
                RS.Shipment_Lines_Details("100","12555","india","00021","01005","00206");
                RS.Action();
                RS.Submit();
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
                        RS.ErrorValidation();
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
                RS.closeBrowser();
            }
        }

    }
}
