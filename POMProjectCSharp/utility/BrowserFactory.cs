using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace POMProjectCSharp.utility
{
    class BrowserFactory
    {
		static IWebDriver driver;

		public static IWebDriver lunchBrowser()
		{
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("http://www.techfios.com/billing/?ng=admin/");
			driver.Manage().Cookies.DeleteAllCookies();
			driver.Manage().Window.Maximize();
			BasePage.implicitWait(driver, 60);
			return driver;
		}

	}
}
