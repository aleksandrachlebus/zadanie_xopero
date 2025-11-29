using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace ZadanieXopero.PageObjects
{
    internal class CheckoutCompletePage
    {
        IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "[data-test='complete-header']")]
        public IWebElement completeHeader;
        [FindsBy(How = How.Id, Using = "back-to-products")]
        public IWebElement backToProductsButton;

        public CheckoutCompletePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
