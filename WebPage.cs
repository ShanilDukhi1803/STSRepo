using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSeleniumTest.Pages
{
    public class WebPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait _wait;

        public WebPage(IWebDriver driver)
        {
            this.driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        protected IWebElement FindElement(By selector) => driver.FindElement(selector);

        protected IList<IWebElement> FindElements(By selector) => driver.FindElements(selector);

        protected void WaitForElementVisibility(By selector)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            _wait.Until(d => driver.FindElement(selector));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}
