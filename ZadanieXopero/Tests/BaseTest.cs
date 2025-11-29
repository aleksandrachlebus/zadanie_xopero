using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;
using ZadanieXopero.DTO;
using ZadanieXopero.Reports;

namespace ZadanieXopero.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver driver;
        protected AllureReport allureReport;
        protected UrlsData urls;
        protected UserCredentialsData userCredentials;
        private string projectLocation = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("ZadanieXopero"));
        private const string testDataPath = "\\ZadanieXopero\\TestData\\";
        private const string urlsTestDataFileName = "UrlsTestData";

        [SetUp]
        public void Setup()
        {
            allureReport = new AllureReport();
            ChromeOptions chromeOptions = new ChromeOptions();
            //Remove below comment to run in headless mode
            //chromeOptions.AddArguments("--headless");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            urls = GetApplicationUrls();
        }

        protected UserCredentialsData GetUserCredentials(string fileName) 
        {
            using StreamReader reader = new(projectLocation + testDataPath + fileName + ".json");
            String json = reader.ReadToEnd();
            return JsonSerializer.Deserialize<UserCredentialsData>(json);
        }

        protected UrlsData GetApplicationUrls()
        {
            using StreamReader reader = new(projectLocation + testDataPath + urlsTestDataFileName + ".json");
            String json = reader.ReadToEnd();
            return JsonSerializer.Deserialize<UrlsData>(json);
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Close();
        }
    }
}
