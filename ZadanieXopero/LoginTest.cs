using Allure.NUnit;
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
            userCredentials = GetUserCredentials("LoginCorrectCredentialsTestData");
            driver.Navigate().GoToUrl(urls.loginPageUrl);
            loginPage.LogIn(userCredentials.User, userCredentials.Password);
            Assert.That(driver.Url, Is.EqualTo(urls.productsPageUrl)); 
        }

        [Test]
        public void LoginWrongPasswordTest()
        {
            allureReport.LogStep("Login With Wrong Password Test");
            userCredentials = GetUserCredentials("LoginWrongPasswordTestData");
            driver.Navigate().GoToUrl(urls.loginPageUrl);
            loginPage.LogIn(userCredentials.User, userCredentials.Password);
            Assert.That(loginPage.Error.Text, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
            Assert.That(driver.Url, Is.EqualTo(urls.loginPageUrl));
        }

        [Test]
        public void LoginEmptyPasswordTest()
        {
            allureReport.LogStep("Login With Empty Password Test");
            userCredentials = GetUserCredentials("LoginEmptyPasswordTestData");
            driver.Navigate().GoToUrl(urls.loginPageUrl);
            loginPage.LogIn(userCredentials.User, userCredentials.Password);
            Assert.That(loginPage.Error.Text, Is.EqualTo("Epic sadface: Password is required"));
            Assert.That(driver.Url, Is.EqualTo(urls.loginPageUrl));
        }

        [Test]
        public void LoginEmptyUserTest()
        {
            allureReport.LogStep("Login With Empty User Test");
            userCredentials = GetUserCredentials("LoginEmptyUserTestData");
            driver.Navigate().GoToUrl(urls.loginPageUrl);
            loginPage.LogIn(userCredentials.User, userCredentials.Password);
            Assert.That(loginPage.Error.Text, Is.EqualTo("Epic sadface: Username is required"));
            Assert.That(driver.Url, Is.EqualTo(urls.loginPageUrl));
        }

        [Test]
        public void LoginNotExistingUserTest()
        {
            allureReport.LogStep("Login With Not Existing User Test");
            userCredentials = GetUserCredentials("LoginNotExistingUserTestData");
            driver.Navigate().GoToUrl(urls.loginPageUrl);
            loginPage.LogIn(userCredentials.User, userCredentials.Password);
            Assert.That(loginPage.Error.Text, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
            Assert.That(driver.Url, Is.EqualTo(urls.loginPageUrl));
        }
    }
}
