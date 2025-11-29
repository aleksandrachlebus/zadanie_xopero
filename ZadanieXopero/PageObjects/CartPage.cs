using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using ZadanieXopero.DTO;

namespace ZadanieXopero.PageObjects
{
    internal class CartPage
    {
        IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "[data-test='inventory-item']")]
        public IList<IWebElement> productsHtmlList;
        [FindsBy(How = How.Id, Using = "remove-sauce-labs-backpack")]
        public IWebElement removeSauceLabsBackpacke;
        [FindsBy(How = How.Id, Using = "remove-sauce-labs-bike-light")]
        public IWebElement removeSauceLabsBikeLight;
        [FindsBy(How = How.Id, Using = "remove-sauce-labs-bolt-t-shirt")]
        public IWebElement removeSauceLabsBoltTShirt;
        [FindsBy(How = How.Id, Using = "remove-sauce-labs-fleece-jacket")]
        public IWebElement removeSauceLabsFleeceJacket;
        [FindsBy(How = How.Id, Using = "remove-sauce-labs-onesie")]
        public IWebElement removeSauceLabsOnesie;
        [FindsBy(How = How.Id, Using = "remove-test.allthethings()-t-shirt-(red)")]
        public IWebElement removeTestAllTheThingsTShirtRed;
        [FindsBy(How = How.Id, Using = "checkout")]
        public IWebElement checkout;
        [FindsBy(How = How.Id, Using = "continue-shopping")]
        public IWebElement continueShopping;

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
        public List<Product> GetProductsInCart()
        {
            List<Product> productsList = new List<Product>();
            foreach (IWebElement productHtml in productsHtmlList)
            {
                int quantity = Int32.Parse(productHtml.FindElement(By.CssSelector("[data-test='item-quantity']")).Text);
                String productName = productHtml.FindElement(By.CssSelector("[data-test='inventory-item-name']")).Text;
                String productDescription = productHtml.FindElement(By.CssSelector("[data-test='inventory-item-desc']")).Text;
                String productPrice = productHtml.FindElement(By.CssSelector("[data-test='inventory-item-price']")).Text;
                Product product = new Product(quantity, productName, productDescription, productPrice);
                productsList.Add(product);
            }
            return productsList;
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
