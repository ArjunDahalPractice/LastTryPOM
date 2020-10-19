using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace POMProjectCSharp.page
{
    class TechfiosLoginPage
    {
        IWebDriver driver;

        public TechfiosLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Element library
        [FindsBy(How = How.XPath, Using = "//input[@id='username']")] private IWebElement LOGIN_USERNAME_FIELD;
        [FindsBy(How = How.XPath, Using = "//input[@id='password']")] private IWebElement LOGIN_PASSWORD_FIELD;
        [FindsBy(How = How.XPath, Using = "//button[@name='login']")] private IWebElement LOGIN_SIGNBUTTON;
        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Dashboard')]")] private IWebElement DASHBOARD_PAGE_TITLE;

        // Interact with method
        public void typeUserNameAndPassword(String username, String password)
        {
            LOGIN_USERNAME_FIELD.SendKeys(username);
            LOGIN_PASSWORD_FIELD.SendKeys(password);
            LOGIN_SIGNBUTTON.Click();
        }

        public String titleOfLoginPage()
        {
            return driver.Title;
        }

        public IWebElement getDASHBOARD_PAGE_TITLE()
        {
            return DASHBOARD_PAGE_TITLE;
        }

        public String dashboardPage()
        {
            return DASHBOARD_PAGE_TITLE.Text;
        }

    }
}
