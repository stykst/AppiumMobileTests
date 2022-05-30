using AppiumMobileTests.ObjectForms;

namespace AppiumMobileTests.Tests
{
    public class VivinoTests : VivinoBaseTest
    {
        [Test]
        public void Test_Vivino()
        {
            // Login in the app
            var form = new VivinoForm(driver);
            form.LogIn(TestAccountEmail, TestAccountPassword);

            // Search for a wine
            var input = "Katarzyna Reserve Red 2006";
            form.SearchForWine(input);

            // Assert that the data of first result are correct
            var wineName = form.ElementWineName.Text;
            Assert.AreEqual("Reserve Red 2006", wineName);
            
            var rating = double.Parse(form.ElementRating.Text);
            Assert.IsTrue(rating >= 1 && rating <= 5);

            form.GetHighlights();
            var highlights = form.ElementHighlightsDescription.Text;
            Assert.AreEqual("Among top 1% of all wines in the world", highlights);

            form.GetFacts();
            var wineFactsTitle = form.ElementFactsTitle.Text;
            Assert.AreEqual("Grapes", wineFactsTitle);

            form.GetFacts();
            var wineFactsText = form.ElementFactsText.Text;
            Assert.AreEqual("Cabernet Sauvignon,Merlot", wineFactsText);
        }
    }
}