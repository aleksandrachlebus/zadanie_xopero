using Allure.NUnit;
using ZadanieXopero.DTO;
using ZadanieXopero.PageObjects;

namespace ZadanieXopero.Tests
{
    [AllureNUnit]
    public class AddToCartTest : BaseTest
    {
        LoginPage loginPage;
        ProductsPage productsPage;
        CartPage cartPage;

        [SetUp]
        public void Setup()
        {
            loginPage = new LoginPage(driver);
            cartPage = new CartPage(driver);
            productsPage = new ProductsPage(driver);
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
            
            List<Product> productsList = cartPage.GetProductsInCart();
            Assert.That(productsList.Count, Is.EqualTo(1));

            Assert.That(productsList[0].quantity, Is.EqualTo(1));
            Assert.That(productsList[0].name, Is.EqualTo("Sauce Labs Backpack"));
            Assert.That(productsList[0].description, Is.EqualTo(
                "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection."));
            Assert.That(productsList[0].price, Is.EqualTo("$29.99"));
            Assert.That(cartPage.removeSauceLabsBackpacke.Enabled);
            Assert.That(cartPage.continueShopping.Enabled);
            Assert.That(cartPage.checkout.Enabled);
        }
    }
}
