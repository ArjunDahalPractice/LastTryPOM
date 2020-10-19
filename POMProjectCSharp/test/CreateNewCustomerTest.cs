using NUnit.Framework;
using OpenQA.Selenium;
using POMProjectCSharp.page;
using POMProjectCSharp.utility;
using SeleniumExtras.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POMProjectCSharp.test
{
     public class CreateNewCustomerTest
    {
        IWebDriver driver;
        String expectedCustomerName;
        CreateNewCustomerPage createCustomer;
        TechfiosLoginPage techfiosLoginPage;

        [Test]
        public void createNewCustomer()
        {
            driver = BrowserFactory.lunchBrowser();
           // techfiosLoginPage = PageFactory.InitElements(new AjaxElementLocatorFactory(driver, 5), this);
            techfiosLoginPage = PageFactory.InitElements<TechfiosLoginPage>(driver);
            techfiosLoginPage.typeUserNameAndPassword("demo@techfios.com", "abc123");
            CreateNewCustomerPage createCustomer = PageFactory.InitElements<CreateNewCustomerPage>(driver);
            createCustomer.CUSTOMERTAB_CLICK();
            createCustomer.CUSTOMERADDTAB_CLICK();
            expectedCustomerName = "Demo" + BasePage.randomStringWithNumber();
            createCustomer.CUSTOMERFULLNAME_INPUT(expectedCustomerName);
            createCustomer.CUSTOMERCOMPANY_SELECT("Techfios");
            createCustomer.CUSTOMEREMAIL_INPUT("abc@yahoo.com");
            createCustomer.CUSTOMERPHONENUMBER_INPUT(BasePage.randomNumberOnly(10));
            createCustomer.CUSTOMERADDRESS_INPUT(BasePage.randomStringWithNumber());
            createCustomer.CUSTOMERCITY_INPUT(BasePage.randomStringWithNumber());
            createCustomer.CUSTOMERSTATE_INPUT(BasePage.randomStringWithNumber());
            createCustomer.CUSTOMERZIPCODE_INPUT(BasePage.randomNumberOnly(5));
            createCustomer.CUSTOMERGROUP_INPUT("April2020");
            createCustomer.CUSTOMERSAVEBUTTON_CLICK();
            BasePage.takeSnapshot(driver, "CreateNewCustomer ");
            BasePage.tearDown(driver);
        }

        [Test]
        public void verifyAddedCustomer()
        {
            driver = BrowserFactory.lunchBrowser();
            techfiosLoginPage = PageFactory.InitElements<TechfiosLoginPage>(driver);
            techfiosLoginPage.typeUserNameAndPassword("demo@techfios.com", "abc123");
            createCustomer = PageFactory.InitElements<CreateNewCustomerPage>(driver);
            createCustomer.CUSTOMERTAB_CLICK();
            createCustomer.CUSTOMERLIST_TAB_CLICK();
            Assert.AreEqual(createCustomer.actualCustomerName(driver), expectedCustomerName, "Wrong page landed");
            BasePage.takeSnapshot(driver, "VerifyAddedCustomer");
            BasePage.tearDown(driver);
        }

    }
}