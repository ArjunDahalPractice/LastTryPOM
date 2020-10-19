using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using POMProjectCSharp.utility;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;
using PageFactory = SeleniumExtras.PageObjects.PageFactory;

namespace POMProjectCSharp.page
{
    class CreateNewCustomerPage
    {
        IWebDriver driver;

        public CreateNewCustomerPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Customers']")] public IWebElement CUSTOMER_TAB_CLICK;
        [FindsBy(How = How.XPath, Using = "//a[text()='Add Customer']")] public IWebElement CUSTOMER_ADDTAB_CLICK;
        [FindsBy(How = How.XPath, Using = "//input[@id='account']")] public IWebElement CUSTOMER_FULLNAME_INPUT;
        [FindsBy(How = How.XPath, Using = "//*[@id='cid']")] public IWebElement CUSTOMER_COMPANY_SELECT;
        [FindsBy(How = How.XPath, Using = "//input[@id='email']")] public IWebElement CUSTOMER_EMAIL_INPUT;
        [FindsBy(How = How.XPath, Using = "//input[@id='phone']")] public IWebElement CUSTOMER_PHONENUMBER_INPUT;
        [FindsBy(How = How.XPath, Using = "//input[@id='address']")] public IWebElement CUSTOMER_ADDRESS_INPUT;
        [FindsBy(How = How.XPath, Using = "//input[@id='city']")] public IWebElement CUSTOMER_CITY_INPUT;
        [FindsBy(How = How.XPath, Using = "//input[@id='state']")] public IWebElement CUSTOMER_STATE_INPUT;
        [FindsBy(How = How.XPath, Using = "//input[@id='zip']")] public IWebElement CUSTOMER_ZIPCODE_INPUT;
        [FindsBy(How = How.XPath, Using = "//*[@id='group']")] public IWebElement CUSTOMER_GROUP_INPUT;
        [FindsBy(How = How.XPath, Using = "//button[@id='submit']")] public IWebElement CUSTOMER_SAVEBUTTON_CLICK;
        [FindsBy(How = How.XPath, Using = "//a[text()='List Customers']")] public IWebElement CUSTOMER_LIST_TAB_CLICK;


        public void CUSTOMERTAB_CLICK()
        {
            BasePage.waitForElement(driver, 60, By.XPath("//span[text()='Customers']"));
            CUSTOMER_TAB_CLICK.Click();
        }

        public void CUSTOMERADDTAB_CLICK()
        {
            BasePage.waitForElement(driver, 60, By.XPath("//a[text()='Add Customer']"));
            CUSTOMER_ADDTAB_CLICK.Click();
        }

        public void CUSTOMERLIST_TAB_CLICK()
        {
            BasePage.waitForElement(driver, 60, By.XPath("//a[text()='List Customers']"));
            CUSTOMER_LIST_TAB_CLICK.Click();
        }

        public void CUSTOMERFULLNAME_INPUT(String customerFullName)
        {
            BasePage.waitForElement(driver, 60, By.XPath("//input[@id='account']"));
            CUSTOMER_FULLNAME_INPUT.SendKeys(customerFullName);
        }

        public String actualCustomerName(IWebDriver driver)
        {
            ArrayList list = new ArrayList();
            // iterate 10 row data
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    String table = driver
                            .FindElement(By.XPath("//*[@id='page-wrapper']/div[3]/div[1]/div/div/div[2]/table/tbody/tr[" + i
                                    + "]" + "/td[" + j + "]"))
                            .Text;
                    list.Add(table);
                }
            }
            //this method run after create customer so i choose index (2) which will be recent added customer 
            //if i need to find between index 0-10 then i have to use if condition.. 
            return (string)list[2];
        }

        public void CUSTOMERCOMPANY_SELECT(String companyVisibleText)
        {
            BasePage.selectDropDown(CUSTOMER_COMPANY_SELECT, companyVisibleText);
            CUSTOMER_COMPANY_SELECT.Click();
        }
        public void CUSTOMEREMAIL_INPUT(String customerEmail)
        {
            CUSTOMER_EMAIL_INPUT.SendKeys(customerEmail);
            /*int index = customerEmail.IndexOf('@');
             * AjaxElementLocatorFactory aj = new AjaxElementLocatorFactory(driver, 60);
            String firstPart = customerEmail.Substring(0, index);
            String lastpart = customerEmail.Substring(index, customerEmail.Length);
            CUSTOMER_EMAIL_INPUT.SendKeys(firstPart + BasePage.randomStringWithNumber() + lastpart);*/
        }

        public void CUSTOMERPHONENUMBER_INPUT(String customerPhoneNumber)
        {
            CUSTOMER_PHONENUMBER_INPUT.SendKeys(customerPhoneNumber);
        }

        public void CUSTOMERADDRESS_INPUT(String customerAddress)
        {
            CUSTOMER_ADDRESS_INPUT.SendKeys(customerAddress);
        }
        public void CUSTOMERCITY_INPUT(String customerCity)
        {
            CUSTOMER_CITY_INPUT.SendKeys(customerCity);
        }

        public void CUSTOMERSTATE_INPUT(String customerState)
        {
            CUSTOMER_STATE_INPUT.SendKeys(customerState);
        }

        public void CUSTOMERZIPCODE_INPUT(String customerZipcode)
        {
            CUSTOMER_ZIPCODE_INPUT.SendKeys(customerZipcode);
        }
        public void CUSTOMERGROUP_INPUT(String groupVisibleText)
        {
            BasePage.selectDropDown(CUSTOMER_GROUP_INPUT, groupVisibleText);
            CUSTOMER_GROUP_INPUT.Click();
        }

        public void CUSTOMERSAVEBUTTON_CLICK()
        {
            CUSTOMER_SAVEBUTTON_CLICK.Click();
        }

    }
}
