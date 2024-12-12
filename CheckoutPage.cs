using OpenQA.Selenium;

namespace NUnitSeleniumTest.Pages
{
    public class CheckoutPage(IWebDriver driver) : WebPage(driver) //baseclass
    {
        private IWebElement FirstName => FindElement(By.CssSelector("[id$='first-name']"));
        private IWebElement LastName => FindElement(By.CssSelector("[id$='last-name']"));
        private IWebElement ZipCode => FindElement(By.CssSelector("[id$='postal-code']"));
        private IWebElement Continue => FindElement(By.CssSelector("[id$='continue']"));

        private static readonly By FinishButton = By.CssSelector("[id$='finish']");

        private static readonly By BackHomeButton = By.CssSelector("[id$='back-to-products']");

        private IWebElement Finish => FindElement(FinishButton);
        private IWebElement BackHome => FindElement(BackHomeButton);

        public void CheckOutInfo(string fname, string lname, string zip)
        {
            FirstName.Click();
            FirstName.SendKeys(fname);

            LastName.Click();
            LastName.SendKeys(lname);

            ZipCode.Click();
            ZipCode.SendKeys(zip);

            Continue.Click();

            WaitForElementVisibility(FinishButton);
            Finish.Click();
        }
         

        public bool VerifySuccessMessage()
        {
            WaitForElementVisibility(BackHomeButton);
            return true;
        }
    }
}
