using Allure.NUnit;
using OpenQA.Selenium;
using ZadanieXopero.PageObjects;

namespace ZadanieXopero.Tests
{
    [AllureNUnit]
    internal class AddToCartTest : BaseTest
    {
        LoginPage loginPage;
        ProductsPage productsPage;
        CartPage cartPage;
        CheckoutStepOnePage checkoutPage;

        [SetUp]
        public void Setup()
        {
            loginPage = new LoginPage(driver);
            cartPage = new CartPage(driver);
            productsPage = new ProductsPage(driver);
            checkoutPage = new CheckoutStepOnePage(driver);
        }

        [Test]
        public void AddProductToCartTest()
        {
            allureReport.LogStep("Add Product To Cart Test");
            userCredentials = GetUserCredentials("LoginCorrectCredentialsTestData");
            driver.Navigate().GoToUrl(urls.loginPageUrl);
            loginPage.LogIn(userCredentials.User, userCredentials.Password);
            productsPage.GoToCart();
            cartPage.CleanCart();
            cartPage.ContinueShopping();

            productsPage.addSauceLabsBackpacke();
            Assert.That(productsPage.getAmountOfProductsInCart(), Is.EqualTo("1"));

            productsPage.GoToCart();
            Assert.That(driver.FindElement(By.CssSelector("div.cart_item:nth-child(3) > div:nth-child(1)")).Text, Is.EqualTo("1"));
            Assert.That(driver.FindElement(By.CssSelector("#item_4_title_link > div:nth-child(1)")).Text, Is.EqualTo("Sauce Labs Backpack"));
            Assert.That(driver.FindElement(By.CssSelector("div.cart_item:nth-child(3) > div:nth-child(2) > div:nth-child(2)")).Text,
                Is.EqualTo("carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection."));
            Assert.That(driver.FindElement(By.CssSelector("div.cart_item:nth-child(3) > div:nth-child(2) > div:nth-child(3) > div:nth-child(1)")).Text.Contains("29.99"));
        }

        [Test]
        public void ShoppingProcessTest() 
        {
            allureReport.LogStep("Shopping Process Test");
            userCredentials = GetUserCredentials("LoginCorrectCredentialsTestData");
            driver.Navigate().GoToUrl(urls.loginPageUrl);
            loginPage.LogIn(userCredentials.User, userCredentials.Password);
            productsPage.GoToCart();
            cartPage.CleanCart();
            cartPage.ContinueShopping();

            productsPage.addSauceLabsBackpacke();
            productsPage.addSauceLabsBikeLight();
            productsPage.GoToCart();
            cartPage.CheckoutShopping();
            checkoutPage.ProvideCustomerDataAndContinue("Jan", "Kowalski", "11-111");
        }
    }
}
