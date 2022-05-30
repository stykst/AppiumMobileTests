using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace AppiumMobileTests.Tests
{
    public class SummatorBaseTest
    {
        private const string AppiumServerUri = "http://[::1]:4723/wd/hub";
        private const string SummatorAppPath = @"C:\com.example.androidappsummator.apk";
        protected AndroidDriver<AndroidElement> driver;
        private WebDriverWait wait;

        [OneTimeSetUp]
        public void Setup()
        {
            var summatorOptions = new AppiumOptions() { PlatformName = "Android" };
            summatorOptions.AddAdditionalCapability("app", SummatorAppPath);
            driver = new AndroidDriver<AndroidElement>(
                new Uri(AppiumServerUri), summatorOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
    }
}