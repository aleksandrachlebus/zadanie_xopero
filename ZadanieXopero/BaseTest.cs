using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ZadanieXopero.Reports;

namespace ZadanieXopero
{
    public abstract class BaseTest
    {
        public IWebDriver driver;
        protected AllureReport allureReport;

        [SetUp]
        public void Setup()
        {
            allureReport = new AllureReport();
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
