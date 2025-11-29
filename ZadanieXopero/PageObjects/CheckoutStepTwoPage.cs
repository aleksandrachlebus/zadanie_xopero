using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using ZadanieXopero.DTO;

namespace ZadanieXopero.PageObjects
{
    public class CheckoutStepTwoPage
    {
        IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "[data-test='inventory-item']")]
        public IList<IWebElement> productsHtmlList;
        [FindsBy(How = How.CssSelector, Using = "[data-test='payment-info-value']")]
        public IWebElement paymentInfoValue;
        [FindsBy(How = How.CssSelector, Using = "[data-test='shipping-info-value']")]
        public IWebElement shippingInfoValue;
        [FindsBy(How = How.CssSelector, Using = "[data-test='subtotal-label']")]
        public IWebElement subtotalLabel;
        [FindsBy(How = How.CssSelector, Using = "[data-test='tax-label']")]
        public IWebElement taxLabel;
        [FindsBy(How = How.CssSelector, Using = "[data-test='total-label']")]
        public IWebElement totalLabel;
        [FindsBy(How = How.Id, Using = "cancel")]
        public IWebElement cancelButton; 
        [FindsBy(How = How.Id, Using = "finish")]
        public IWebElement finishButton;

        public CheckoutStepTwoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public List<Product> GetProductsToCheckout() 
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

        public void FinishShopping()
        {
            finishButton.Click();
        }
    } 
}
