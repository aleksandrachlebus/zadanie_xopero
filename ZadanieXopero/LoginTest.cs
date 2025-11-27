using Allure.NUnit;
using System.Configuration;
using ZadanieXopero.PageObjects;

namespace ZadanieXopero
{
    [AllureNUnit]
    public class Tests : BaseTest
    {
        LoginPage loginPage;

        [SetUp]
        public void Setup()
        {
            loginPage = new LoginPage(driver);
        }

        [Test]
        public void LoginCorrectCredentialsTest()
        {
            allureReport.LogStep("Login With Correct Credentials Test");
            //string loginPageUrl = ConfigurationManager.AppSettings["Url"];
            //driver.Navigate().GoToUrl(loginPageUrl);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage.LogIn("standard_user", "secret_sauce");
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html")); 
        }

        [Test]
        public void LoginWrongPasswordTest()
        {
            allureReport.LogStep("Login With Wrong Password Test");
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage.LogIn("standard_user", "wrong_password");
            Assert.That(loginPage.Error.Text, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
        }

        [Test]
        public void LoginEmptyPasswordTest()
        {
            allureReport.LogStep("Login With Empty Password Test");
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage.LogIn("standard_user", "");
            Assert.That(loginPage.Error.Text, Is.EqualTo("Epic sadface: Password is required"));
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
        }

        [Test]
        public void LoginEmptyUserTest()
        {
            allureReport.LogStep("Login With Empty User Test");
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage.LogIn("", "secret_sauce");
            Assert.That(loginPage.Error.Text, Is.EqualTo("Epic sadface: Username is required"));
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
        }

        [Test]
        public void LoginNotExistingUserTest()
        {
            allureReport.LogStep("Login With Not Existing User Test");
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage.LogIn("not_existing_user", "secret_sauce");
            Assert.That(loginPage.Error.Text, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
        }
    }
}
