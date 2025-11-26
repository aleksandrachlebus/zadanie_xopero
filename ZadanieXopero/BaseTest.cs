using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ZadanieXopero
{
    public abstract class BaseTest
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            //Remove below comment to run in headless mode
            //chromeOptions.AddArguments("--headless");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
