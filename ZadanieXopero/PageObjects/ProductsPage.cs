using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ZadanieXopero.PageObjects
{
    internal class ProductsPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-backpack")]
        private IWebElement addToCartSauceLabsBackpacke;

        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-bike-light")]
        private IWebElement addToCartSauceLabsBikeLight;

        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-bolt-t-shirt")]
        private IWebElement addToCartSauceLabsBoltTShirt;

        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-fleece-jacket")]
        private IWebElement addToCartSauceLabsFleeceJacket;

        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-onesie")]
        private IWebElement addToCartSauceLabsOnesie;

        [FindsBy(How = How.Id, Using = "add-to-cart-test.allthethings()-t-shirt-(red)")]
        private IWebElement addToCartTestAllThethingsTShirtRed;

        [FindsBy(How = How.Id, Using = "shopping_cart_container")]
        private IWebElement shoppingCartContainer;

        [FindsBy(How = How.CssSelector, Using = "[data-test='shopping-cart-badge']")]
        private IWebElement shoppingCartBadge;

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToCart() 
        {
            shoppingCartContainer.Click();
        }

        public void addSauceLabsBackpacke()
        { 
            addToCartSauceLabsBackpacke.Click();
        }

        public void addSauceLabsBikeLight()
        { 
            addToCartSauceLabsBikeLight.Click();
        }

        public String getAmountOfProductsInCart()
        {
            return shoppingCartBadge.Text;
        }

    }
}
