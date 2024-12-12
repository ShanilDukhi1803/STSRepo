using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSeleniumTest.Pages
{
    public class HomePage(IWebDriver driver) : WebPage(driver)  
    {
        private IWebElement LoginName => FindElement(By.CssSelector("input[id$='user-name']"));
        private IWebElement Password => FindElement(By.CssSelector("input[id$='password']"));
        private IWebElement LoginButton => FindElement(By.CssSelector("input[id$='login-button']"));

        //private IWebElement ErrorMessage => FindElement(By.CssSelector("input[id$='login-button']"));

        private static readonly By ErrorMessage = By.CssSelector("input[id$='login-button']");
        private IWebElement ErrorSadFace => FindElement(ErrorMessage);

        public void EnterLoginDetails(string userName, string password)
        {
            LoginName.Click();
            LoginName.SendKeys(userName);
            Password.Click();
            Password.SendKeys(password);
            LoginButton.Click();
        }

        public bool WaitForErrorMessage()
        {
            WaitForElementVisibility(ErrorMessage);
            return true;
        }
    }
}
