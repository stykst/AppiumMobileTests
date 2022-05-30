using OpenQA.Selenium.Appium.Android;

namespace AppiumMobileTests.ObjectForms
{
    public class VivinoForm
    {
        private readonly AndroidDriver<AndroidElement> driver;

        public VivinoForm(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public AndroidElement LinkHaveAccount =>
                    driver.FindElementById("vivino.web.app:id/txthaveaccount");
        public AndroidElement TextBoxEmail =>
            driver.FindElementById("vivino.web.app:id/edtEmail");
        public AndroidElement TextBoxPassword =>
            driver.FindElementById("vivino.web.app:id/edtPassword");
        public AndroidElement ButtonLogin =>
            driver.FindElementById("vivino.web.app:id/action_signin");
        public AndroidElement TabWineExplorer =>
            driver.FindElementById("vivino.web.app:id/wine_explorer_tab");
        public AndroidElement FieldSearch =>
            driver.FindElementById("vivino.web.app:id/search_vivino");
        public AndroidElement TextBoxWineInput =>
            driver.FindElementById("vivino.web.app:id/editText_input");
        public AndroidElement ListOfProducts =>
            driver.FindElementById("vivino.web.app:id/listviewWineListActivity");
        public AndroidElement ElementWineName =>
            driver.FindElementById("vivino.web.app:id/wine_name");
        public AndroidElement ElementRating =>
            driver.FindElementById("vivino.web.app:id/rating");
        public AndroidElement ElementSummaryTabs =>
            driver.FindElementById("vivino.web.app:id/tabs");
        public AndroidElement ElementHighlightsDescription =>
            driver.FindElementByAndroidUIAutomator(
                "new UiScrollable(new UiSelector().scrollable(true))" +
                ".scrollIntoView(new UiSelector().resourceIdMatches(" + 
                "\"vivino.web.app:id/highlight_description\"))");
        public AndroidElement ElementFactsTitle =>
            driver.FindElementById("vivino.web.app:id/wine_fact_title");
        public AndroidElement ElementFactsText =>
            driver.FindElementById("vivino.web.app:id/wine_fact_text");

        public void LogIn(string email, string password)
        {
            LinkHaveAccount.Click();

            TextBoxEmail.Clear();
            TextBoxEmail.SendKeys(email);

            TextBoxPassword.Clear();
            TextBoxPassword.SendKeys(password);

            ButtonLogin.Click();
        }

        public void SearchForWine(string input)
        {
            TabWineExplorer.Click();
            FieldSearch.Click();

            TextBoxWineInput.SendKeys(input);

            var firstResul = ListOfProducts
                .FindElementByClassName("android.widget.FrameLayout");
            firstResul.Click();
        }

        public void GetHighlights()
        {
            var highlights = ElementSummaryTabs
                .FindElementByXPath("//android.widget.TextView[1]");
            highlights.Click();
        }

        public void GetFacts()
        {
            var highlights = ElementSummaryTabs
                .FindElementByXPath("//android.widget.TextView[2]");
            highlights.Click();
        }
    }
}
