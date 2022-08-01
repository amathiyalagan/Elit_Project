using AventStack.ExtentReports;
using ELIT_Selenium_PRJ.PageMethods.Inventory;
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
    class InventoryTest : ReportsGenerationClass
    {

        inventorymethod im;

        [Test, Order(1)]
        [Category("Inventory Testing")]

        public void Inventory()
        {
            im = new inventorymethod(GetDriver());

            try
            {
                im.GoToPage("http://localhost:3000/");
                im.Username("ATHANIGA");
                im.Password("Atsdxb@003");
                im.LoginNow();
                _test.Log(Status.Pass, "Supplier Logged In");
                im.Sidebar();
                im.Orders();
                im.language();
                im.OperatingUnit("Appstec ERP Solutions");
                im.Itemnumber("02354");
                im.Category("Computer Software for Microcomputers");
                im.UOM("CAN");
                im.UnitPrice("2000");
                im.Taxpercentage("2%");
                im.Description("Add Inventory has been done");
                im.Add();
                _test.Log(Status.Pass, "Add Inventory has been done");
                im.Profile_logout();
                im.Logout();
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
                        im.ErrorValidation();
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
        }   }
}

