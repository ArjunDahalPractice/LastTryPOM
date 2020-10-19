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
using System.Threading.Tasks;

namespace POMProjectCSharp.test
{
    public class TechFiosLoginTest
    {
        IWebDriver driver;
        TechfiosLoginPage techfiosLoginPage;

        [Test]
        public void validUserShouldBeAbleToLogin()
        {
            driver = BrowserFactory.lunchBrowser();
            techfiosLoginPage = PageFactory.InitElements<TechfiosLoginPage>(driver);
            // Assertion if we lunch correct web site
            String expectedTitle = "Login - iBilling";
            String actualTitle = techfiosLoginPage.titleOfLoginPage();
            Assert.AreEqual(expectedTitle, actualTitle, "Wrong page lunch");
            techfiosLoginPage.typeUserNameAndPassword("demo@techfios.com", "abc123");
            // Login with valid username and password
        }

        [Test]
        public void verifyDashBoardTitle()
        {
            //verify sucessfully login with assetion of dashboard title
            String expectedTitle = "Dashboard";
            String actualTitle = techfiosLoginPage.dashboardPage();
            Console.WriteLine(actualTitle);
            Assert.AreEqual(expectedTitle, actualTitle, "Lunch Wrong Page");
            BasePage.tearDown(driver);
        }
    }
}
