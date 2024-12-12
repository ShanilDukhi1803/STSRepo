using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Support.UI;
using NUnitSeleniumTest.Pages;


namespace ConsoleApp2
{
    [TestFixture]
    public class SauceLabs
    {
        private const string SearchPhrase = "selenium";
        private const string webUrl = "https://www.saucedemo.com";
        private const string firstName = "Chester";
        private const string lastName = "Tester";
        private const string ZipCode = "4000";

#pragma warning disable CA1859
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
        "NUnit1032:An IDisposable field/property should be Disposed in a TearDown method",
        Justification = "Reason...")]

        private IWebDriver driver;
        private static WebDriverWait _wait;

        [OneTimeSetUp]
        public void SetUpWebDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
        }

        [Test]
        [TestCase("standard_user", "secret_sauce")]
        [TestCase("locked_out_user", "secret_sauce")]
        [TestCase("problem_user", "secret_sauce")]
        [TestCase("performance_glitch_user", "secret_sauce")]
        [TestCase("error_user", "secret_sauce")]
        [TestCase("visual_user", "secret_sauce")]
        public void PerformPerchase(string userName, string password)
        {
            driver.Navigate().GoToUrl(webUrl);

            var homePage = new HomePage(driver);
            var checkOutPage = new CheckoutPage(driver);

            homePage.EnterLoginDetails(userName, password);

            if (homePage.WaitForErrorMessage() != true)
            {
                var searchResultsPage = new SearchResultsPage(driver);
                searchResultsPage.WaitForPageToLoad();

                Assert.That(searchResultsPage.WaitForPageToLoad(), Is.True);

                searchResultsPage.CompleteCheckoutCart();

                checkOutPage.CheckOutInfo(firstName, lastName, ZipCode);
                Assert.That(checkOutPage.VerifySuccessMessage(), Is.True);
            }
            else
            {
                Console.WriteLine("User is locked out");                
            }  
        }

        [OneTimeTearDown]
        public void TearDownDriver() => driver.Quit();
    }

}
