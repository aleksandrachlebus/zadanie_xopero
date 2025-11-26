using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ZadanieXopero.PageObjects
{
    internal class CartPage
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-backpack")]
        private IWebElement removeSauceLabsBackpacke;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-bike-light")]
        private IWebElement removeSauceLabsBikeLight;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-bolt-t-shirt")]
        private IWebElement removeSauceLabsBoltTShirt;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-fleece-jacket")]
        private IWebElement removeSauceLabsFleeceJacket;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-onesie")]
        private IWebElement removeSauceLabsOnesie;

        [FindsBy(How = How.Id, Using = "remove-test.allthethings()-t-shirt-(red)")]
        private IWebElement removeTestAllTheThingsTShirtRed;

        [FindsBy(How = How.Id, Using = "checkout")]
        private IWebElement checkout;

        [FindsBy(How = How.Id, Using = "continue-shopping")]
        private IWebElement continueShopping;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void CleanCart()
        {
            try { removeSauceLabsBackpacke.Click();}
            catch (NoSuchElementException e)
            { Console.WriteLine("Product SauceLabsBackpacke was not in a cart"); }

            try { removeSauceLabsBikeLight.Click(); }
            catch (NoSuchElementException e)
            { Console.WriteLine($"Product SauceLabsBickeLight was not in a cart. {e.Message}"); }

            try { removeSauceLabsBoltTShirt.Click(); }
            catch (NoSuchElementException e)
            { Console.WriteLine($"Product SauceLabsBoltTShirt was not in a cart. {e.Message}"); }

            try { removeSauceLabsFleeceJacket.Click(); }
            catch (NoSuchElementException e)
            { Console.WriteLine($"Product SauceLabsFleeceJacket was not in a cart. {e.Message}"); }

            try { removeSauceLabsOnesie.Click(); }
            catch (NoSuchElementException e)
            { Console.WriteLine($"Product SauceLabsOnesie was not in a cart. {e.Message}"); }

            try { removeTestAllTheThingsTShirtRed.Click(); }
            catch (NoSuchElementException e)
            { Console.WriteLine($"Product AllTheThingsTShirtRed was not in a cart. {e.Message}"); }
        }

        public void ContinueShopping()
        { 
            continueShopping.Click();
        }

        public void CheckoutShopping()
        {
            checkout.Click();
        }
    }
}
