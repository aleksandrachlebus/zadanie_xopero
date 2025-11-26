using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ZadanieXopero.PageObjects
{
    internal class CheckoutStepOnePage
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "first-name")]
        private IWebElement firstName;
        [FindsBy(How = How.Id, Using = "last-name")]
        private IWebElement lastName;
        [FindsBy(How = How.Id, Using = "postal-code")]
        private IWebElement postalCode;
        [FindsBy(How = How.Id, Using = "continue")]
        private IWebElement continueButton;
        [FindsBy(How = How.Id, Using = "cancel")]
        private IWebElement cancelButton;

     public CheckoutStepOnePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void ProvideCustomerDataAndContinue(string name, string surname, string zipCode)
        {
            firstName.SendKeys(name);
            lastName.SendKeys(surname);
            postalCode.SendKeys(zipCode);
            continueButton.Click();
        }
    } 
}
