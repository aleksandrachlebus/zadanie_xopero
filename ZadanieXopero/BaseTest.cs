using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ZadanieXopero.Reports;

namespace ZadanieXopero
{
    public abstract class BaseTest
    {
        public IWebDriver driver;
        protected AllureReport allureReport;
        string projectLocation = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("ZadanieXopero"));
        protected string testDataPath = "\\ZadanieXopero\\TestData\\";
        protected const string urlsTestDataFileName = "UrlsTestData";
        public UrlsData urls;
        public UserCredentialsData userCredentials;

        [SetUp]
        public void Setup()
        {
            allureReport = new AllureReport();
            ChromeOptions chromeOptions = new ChromeOptions();
            //Remove below comment to run in headless mode
            //chromeOptions.AddArguments("--headless");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            urls = GetApplicationUrls();
        }

        public UserCredentialsData GetUserCredentials(string fileName) 
        {
            using StreamReader reader = new(projectLocation + testDataPath + fileName + ".json");
            var json = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<UserCredentialsData>(json);
        }

        public UrlsData GetApplicationUrls()
        {
            using StreamReader reader = new(projectLocation + testDataPath + urlsTestDataFileName + ".json");
            var json = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<UrlsData>(json);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
