using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ZadanieXopero.PageObjects
{
    internal class LoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "user-name")]
        private IWebElement userName;
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;
        [FindsBy(How = How.Id, Using = "login-button")]
        private IWebElement loginButton;
        [FindsBy(How = How.CssSelector, Using = "[data-test='error']")]
        private IWebElement error;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public IWebElement Error { get => error; }

        public void LogIn(string user, string pwd)
        {
            userName.SendKeys(user);
            password.SendKeys(pwd);
            loginButton.Click();
        }
    }
}
