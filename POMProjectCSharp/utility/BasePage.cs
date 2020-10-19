
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace POMProjectCSharp.utility
{
    class BasePage
    {
		public static void waitForElement(IWebDriver driver, double timeInSeconds, By locator)
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
		}

		public static void explictWait(IWebDriver driver, By locator)
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
		}

		public static void implicitWait(IWebDriver driver, double timeOutSeconds)
		{
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOutSeconds);
		}

		public static String randomStringWithNumber()
		{
			return Guid.NewGuid().ToString().Substring(0, 8);
		}

		public static String randomNumberOnly(int howManyDigit)
		{
			String inputDigit = "";
			HashSet<Double> number = new HashSet<Double>();
			Random random = new Random();
			double my = random.NextDouble();
			number.Add(my);
			
			foreach (Double mylist in number)
			{
				inputDigit = inputDigit + mylist.ToString().ToString().Substring(2, howManyDigit + 2);
			}
			return inputDigit;
		}

		public static void selectDropDown(IWebElement element, String visibleText)
		{
			SelectElement select = new SelectElement(element);
			select.SelectByText(visibleText);
		}

		public static void actionMouseHover(IWebDriver driver, IWebElement element)
		{
            Actions action = new Actions(driver);
			action.MoveToElement(element).Build().Perform();
		}

		public void actionDragAndDrop(IWebDriver driver, IWebElement source, IWebElement target)
		{
			Actions action = new Actions(driver);
			action.DragAndDrop(source, target).Build().Perform();
		}

		public void actionhandlingNewTabWindow(IWebDriver driver)
		{
			String parentWindow = driver.CurrentWindowHandle;
			int n = driver.WindowHandles.Count;
	
			ArrayList list;
			for (int i = 0; i < n; i++)
			{
				list = new ArrayList();
				list.Add(driver.WindowHandles[i]);
				if (!parentWindow.Equals(driver.WindowHandles[i]))
				{
					String windowsName = (string)list[i];
					driver.SwitchTo().Window(windowsName);
				}

			}
		}

		public void acceptAlertMessage(IWebDriver driver)
		{
			driver.SwitchTo().Alert().Accept();
		}

		public void rejectAlertMessage(IWebDriver driver)
		{
			driver.SwitchTo().Alert().Dismiss();
		}

		public static String getTextAlertMessage(IWebDriver driver)
		{
			String textAlertMessage = driver.SwitchTo().Alert().Text;
			return textAlertMessage;
		}

		public static void sendTextMessageInAlert(IWebDriver driver, String stringsendtoalert)
		{
			driver.SwitchTo().Alert().SendKeys(stringsendtoalert);
		}

		public static void handlingIframeByName(IWebDriver driver, String frameName, By element)
		{
			driver.SwitchTo().DefaultContent();
			driver.SwitchTo().Frame(frameName).FindElements(element);
		}

		public static void handlingIframeByIndex(IWebDriver driver, int indexOfIFrame, By element)
		{
			driver.SwitchTo().DefaultContent();
			driver.SwitchTo().Frame(indexOfIFrame).FindElements(element);
		}

		public static void scrollingByDownpixels(IWebDriver driver, int downPixels)
		{
			IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
			javascriptExecutor.ExecuteScript("windows.scrollBy(0," + downPixels + ")");
		}

		public static void scrollingByElement(IWebDriver driver, IWebElement element)
		{
			IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
			javascriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
		}

		public static void takeSnapshot(IWebDriver driver, String nameOfScreenShot)
		{
			DateFormat dateFormate = new DateFormat();
			String timestamp = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");

			ITakesScreenshot takeScreenshot = ((ITakesScreenshot)driver);

			/*string folderName = @"C:\\Users\\arjun\\source\\repos\\POMProjectCSharp\\POMProjectCSharp\\snapshot";

            if (!System.IO.Directory.Exists(folderName))
            {
                System.IO.Directory.CreateDirectory(folderName);
            }*/
			takeScreenshot.GetScreenshot().SaveAsFile(@"C:\\Users\\arjun\\source\\repos\\POMProjectCSharp\\POMProjectCSharp\\snapshot\\myscreen.png");
			//takeScreenshot.GetScreenshot().SaveAsFile(folderName + nameOfScreenShot + timestamp + ".png");
		}

		public static void tearDown(IWebDriver driver)
		{
			driver.Close();
			driver.Quit();
		}
	}
}
