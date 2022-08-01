using AventStack.ExtentReports;
using ELIT_Selenium_TR.Config;
using ELIT_Selenium_TR.PageMethods.Raise_Invoice;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELIT_Selenium_TR.TestCases.Raise_Invoice_Test
{
    [TestFixture]

    public class RaiseInvoiceTest : ReportsGenerationClass
    {

        RaiseInvoice RI;

        [Test, Order(1)]
        [Category("Raise Invoice")]
        public void Rasie_Invoice()
        {
            RI = new RaiseInvoice(GetDriver());

            try
            {
                RI.GoToPage("https://uat.elit.ai/");
                RI.UserName("ASWATHANN@GMAIL.COM");
                RI.Password("Atsdxb@003");
                RI.SignIn();

                RI.Supplier();
                RI.SupplierProfile();
                RI.PurchaseOrder();
                RI.PO_Search("1028");
                RI.Raise_Invoice();
                RI.Line_Select();
                RI.Create_Invoice("Create Invoice");
                RI.Invoice_Number("05454");
                RI.Invoice_Date("17-06-2022 12:00 AM");
                RI.Invoice_Description("invoice done");
                RI.FileUpload(@"C:\Users\ATSTC004\Pictures\ELIT-155.png");
                RI.Invoice_Lines();
                RI.Invoice_Lines_Pager();
                RI.Invoice_Lines_Details();
                RI.Action();
                RI.Submit();
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
                        RI.ErrorValidation();
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
                RI.closeBrowser();
            }
        }


    }
}
