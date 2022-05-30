using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace AppiumMobileTests.Tests
{
    public class VivinoBaseTest
    {
        private const string AppiumServerUri = "http://[::1]:4723/wd/hub";
        private const string AppPackage = "vivino.web.app";
        private const string AppStartupActivity = "com.sphinx_solution.activities.SplashActivity";
        protected const string TestAccountEmail = "test_vivino@gmail.com";
        protected const string TestAccountPassword = "p@ss987654321";
        protected AndroidDriver<AndroidElement> driver;
        //private WebDriverWait wait;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("appPackage", AppPackage);
            options.AddAdditionalCapability("appActivity", AppStartupActivity);
            driver = new AndroidDriver<AndroidElement>(
                new Uri(AppiumServerUri), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
    }
}