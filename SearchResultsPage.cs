using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSeleniumTest.Pages
{
    public class SearchResultsPage(IWebDriver driver) : WebPage(driver)
    {
        private static readonly By SearchResultsItemsCss = By.CssSelector("[class$='inventory_list']");
        private static readonly By AddItemToCart = By.CssSelector("[id$='add-to-cart-sauce-labs-backpack']");
        private static readonly By CheckOutCart = By.CssSelector("[id$='shopping_cart_container']");
        private static readonly By CheckOutButton = By.CssSelector("[id$='checkout']");

        private IWebElement AddFirstItem => FindElement(AddItemToCart);
        private IWebElement Cart => FindElement(CheckOutCart);
        private IWebElement CheckOut => FindElement(CheckOutButton);

        public bool WaitForPageToLoad()
        {
            WaitForElementVisibility(SearchResultsItemsCss);
            return true;
        }

        public void CompleteCheckoutCart()
        {
            AddToCart();
            ClickCart();
            CompleteShopping();
        }

        private void AddToCart()
        {
            WaitForElementVisibility(AddItemToCart);
            AddFirstItem.Click();
        }

        private void ClickCart()
        {
            WaitForElementVisibility(CheckOutCart);
            Cart.Click();
        }

        private void CompleteShopping()
        {
            WaitForElementVisibility(CheckOutButton);
            CheckOut.Click();
        }
    }
}
