using AppiumMobileTests.ObjectForms;

namespace AppiumMobileTests.Tests
{
    public class SummatorTests : SummatorBaseTest
    {
        [TestCase("3", "5", "8")]
        [TestCase("3.5", "5", "8.5")]
        [TestCase("3", "5.875", "8.875")]
        [TestCase("3.14", "5.875", "9.015")]
        public void Test_Summator_ValidData(string num1, string num2, string result)
        {
            var form = new SummatorForm(driver);
            form.Calculate(num1, num2);

            var sum = form.TextBoxResult.Text;
            var expectedSum = result;

            var expectedResult = double.Parse(num1) + double.Parse(num2);

            Assert.AreEqual(expectedSum, sum, expectedResult.ToString());
        }

        [TestCase("", "", "error")]
        [TestCase("1", "", "error")]
        [TestCase("", "2", "error")]
        [TestCase("qer", "eqr", "error")]
        [TestCase("dsaf", "4", "error")]
        [TestCase("5", "asdf", "error")]
        public void Test_SummatorTests_InvalidData(string num1, string num2, string result)
        {
            var window = new SummatorForm(driver);
            window.Calculate(num1, num2);

            var sum = window.TextBoxResult.Text;
            var expectedSum = result;

            Assert.AreEqual(expectedSum, sum);
        }
    }
}