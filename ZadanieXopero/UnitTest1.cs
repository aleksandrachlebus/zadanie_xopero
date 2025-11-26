using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

namespace ZadanieXopero
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        [Test]
        public void Test1() {

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            //driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            //driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            //driver.FindElement(By.Id("login-button")).Click();

            //driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            //driver.FindElement(By.Id("password")).SendKeys("wrong_password");
            //driver.FindElement(By.Id("login-button")).Click();

            //driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            //driver.FindElement(By.Id("password")).SendKeys("");
            //driver.FindElement(By.Id("login-button")).Click();

            //driver.FindElement(By.Id("user-name")).SendKeys("not_existing_user");
            //driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            //driver.FindElement(By.Id("login-button")).Click();

            driver.FindElement(By.Id("user-name")).SendKeys("");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();
            String value = driver.FindElement(By.CssSelector("[data-test='error']")).Text;
            Assert.That(value, Is.EqualTo("Epic sadface: Username is required"));
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
      //      Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));

            //WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));
            //wait.Until(driver => driver.FindElement(By.Id("shopping_cart_link")).Displayed);
        }

        [TearDown]
        public void TearDown() {
            driver.Close();
            driver.Quit(); 
        }
    }
}
