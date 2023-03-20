
using PTLabTask0;

namespace PTLabTask0Test
{
    [TestClass]
    public class UnitTest1
    {
        Calculator calc = new Calculator();

        [TestMethod]
        public void AdditionTest()
        {
            int result = calc.Add(2, 2);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void SubtractionTest()
        {
            int result = calc.Subtract(2, 2);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            int result = calc.Multiply(2, 2);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void DivisionTest()
        {
            double result = calc.Divide(10, 2);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void DivisionTestExpectedFailure()
        {
            double result = calc.Divide(10, 0);
            Assert.AreEqual(30, result);
        }
    }
}