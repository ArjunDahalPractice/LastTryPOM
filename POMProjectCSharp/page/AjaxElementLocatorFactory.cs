using OpenQA.Selenium;

namespace POMProjectCSharp.page
{
    internal class AjaxElementLocatorFactory
    {
        private IWebDriver driver;
        private int v;

        public AjaxElementLocatorFactory(IWebDriver driver, int v)
        {
            this.driver = driver;
            this.v = v;

        }
    }
}