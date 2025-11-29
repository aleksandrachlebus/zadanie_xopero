using Allure.NUnit;
using ZadanieXopero.DTO;
using ZadanieXopero.PageObjects;

namespace ZadanieXopero.Tests
{
    [AllureNUnit]
    [TestFixture]
    [Category("UI")]
    public class ShoppingTest : BaseTest
    {
        LoginPage loginPage;
        ProductsPage productsPage;
        CartPage cartPage;
        CheckoutStepOnePage checkoutStepOnePage;
        CheckoutStepTwoPage checkoutStepTwoPage;
        CheckoutCompletePage checkoutCompletePage;

        [SetUp]
        public void Setup()
        {
            loginPage = new LoginPage(driver);
            cartPage = new CartPage(driver);
            productsPage = new ProductsPage(driver);
            checkoutStepOnePage = new CheckoutStepOnePage(driver);
            checkoutStepTwoPage = new CheckoutStepTwoPage(driver);
            checkoutCompletePage = new CheckoutCompletePage(driver);
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
            checkoutStepOnePage.ProvideCustomerDataAndContinue("Jan", "Kowalski", "11-111");

            List<Product> productsList = checkoutStepTwoPage.GetProductsToCheckout();
            Assert.That(productsList.Count, Is.EqualTo(2));

            Assert.That(productsList[0].quantity, Is.EqualTo(1));
            Assert.That(productsList[0].name, Is.EqualTo("Sauce Labs Backpack"));
            Assert.That(productsList[0].description, Is.EqualTo(
                "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection."));
            Assert.That(productsList[0].price, Is.EqualTo("$29.99"));

            Assert.That(productsList[1].quantity, Is.EqualTo(1));
            Assert.That(productsList[1].name, Is.EqualTo("Sauce Labs Bike Light"));
            Assert.That(productsList[1].description, Is.EqualTo(
                "A red light isn't the desired state in testing but it sure helps when riding your bike at night. Water-resistant with 3 lighting modes, 1 AAA battery included."));
            Assert.That(productsList[1].price, Is.EqualTo("$9.99"));

            Assert.That(checkoutStepTwoPage.paymentInfoValue.Text, Is.EqualTo("SauceCard #31337"));
            Assert.That(checkoutStepTwoPage.shippingInfoValue.Text, Is.EqualTo("Free Pony Express Delivery!"));
            Assert.That(checkoutStepTwoPage.subtotalLabel.Text, Is.EqualTo("Item total: $39.98"));
            Assert.That(checkoutStepTwoPage.taxLabel.Text, Is.EqualTo("Tax: $3.20"));
            Assert.That(checkoutStepTwoPage.totalLabel.Text, Is.EqualTo("Total: $43.18"));

            Assert.That(checkoutStepTwoPage.cancelButton.Enabled);
            checkoutStepTwoPage.FinishShopping();

            Assert.That(checkoutCompletePage.completeHeader.Text, Is.EqualTo("Thank you for your order!"));
            Assert.That(checkoutCompletePage.backToProductsButton.Enabled);
        }
    }
}
