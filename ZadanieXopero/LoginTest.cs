using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using ZadanieXopero.PageObjects;

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
        public void LoginCorrectCredentialsTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage.LogIn("standard_user", "secret_sauce");
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html")); 
        }

        [Test]
        public void LoginWrongPasswordTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage.LogIn("standard_user", "wrong_password");
            Assert.That(loginPage.Error.Text, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
        }

        [Test]
        public void LoginEmptyPasswordTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage.LogIn("standard_user", "");
            Assert.That(loginPage.Error.Text, Is.EqualTo("Epic sadface: Password is required"));
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
        }

        [Test]
        public void LoginEmptyUserTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage.LogIn("", "secret_sauce");
            Assert.That(loginPage.Error.Text, Is.EqualTo("Epic sadface: Username is required"));
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
        }

        [Test]
        public void LoginNotExistingUserTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage.LogIn("not_existing_user", "secret_sauce");
            Assert.That(loginPage.Error.Text, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
        }

        [TearDown]
        public void TearDown() {
            driver.Quit(); 
        }
    }
}
