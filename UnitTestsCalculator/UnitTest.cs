using CSharpCalculator;
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(10)]
namespace UnitTestsCalculator
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestFixture]
    [Parallelizable]
    public class Abs
    {
        readonly Calculator calculator = new Calculator();

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Test setup");
        }

        [Test]
        public void AbsZeroValue()
        {
            Assert.AreEqual(0, calculator.Abs(0));
        }

        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("Test teardown");
        }
        [Test]
        public void AbsNegativeDoubleValue()
        {
            Assert.AreEqual(6, calculator.Abs(-5.5));
        }
        [Test]
        public void AbsDoubleValue()
        {
            Assert.AreEqual(6, calculator.Abs(5.5));
        }
        [Test]
        public void AbsNegativeIntegerValue()
        {
            Assert.AreEqual(10, calculator.Abs(-10));
        }
        [Test]
        public void AbsIntegerValue()
        {
            Assert.AreEqual(10, calculator.Abs(10));
        }
        [Test]
        public void AbsStringValue()
        {
            System.NotFiniteNumberException ex = Assert.ThrowsException<System.NotFiniteNumberException>(() => calculator.Abs("HI"));
            Assert.AreEqual("Wrong input", ex.Message);
        }
        [Test]
        public void AbsStringNumber()
        {
            Assert.AreEqual(10, calculator.Abs("10"));
        }
    }
    [TestClass]
    [Parallelizable]
    public class Sub
    {
        readonly Calculator calculator = new Calculator();
        [Test]
        public void SubIntegerValues()
        {
            Assert.AreEqual(5,calculator.Sub(10,5));
        }
        [Test]
        public void SubStringsValues()
        {
            Assert.AreEqual(5, calculator.Sub("10", "5"));
        }

    }

    [TestClass]
    [Parallelizable]
    public class Sum
    {
        readonly Calculator calculator = new Calculator();
        [Test]
        public void SubDoubleValues()
        {
            Assert.AreEqual(15.0, calculator.Add(10.0, 5.0));
        }
        [Test]
        public void SubStringsValues()
        {
            Assert.AreEqual(15, calculator.Add("10", "5"));
        }

    }
    [TestClass]
    [Parallelizable]
    public class Sqrt
    {
        readonly Calculator calculator = new Calculator();
        [Test]
        public void SqrtPositiveIntegerValue()
        {
            Assert.AreEqual(5, calculator.Sqrt(25));
        }
        [Test]
        public void SqrtPositiveStringsValue()
        {
            Assert.AreEqual(5, calculator.Sqrt("25"));
        }
        [Test]
        public void SqrtNegativeIntegerValue()
        {
            Assert.AreNotEqual(5, calculator.Sqrt(-25));
        }
        [Test]
        public void SqrtNegativeStringsValue()
        {
            Assert.AreNotEqual(5, calculator.Sqrt("-25"));
        }


    }
    [TestClass]
    [Parallelizable]
    public class Pow
    {
        readonly Calculator calculator = new Calculator();
        [Test]
        public void PowPositiveIntegerValue()
        {
            Assert.Equals(625, calculator.Pow(25,2));
        }
        [Test]
        public void PowPositiveStringsValue()
        {
            Assert.Equals(625, calculator.Pow("25",2));
        }
        [Test]
        public void PowNegativeIntegerValue()
        {
            Assert.AreNotEqual(125, calculator.Pow(-5,3));
        }
        [Test]
        public void PowNegativeStringsValue()
        {
            Assert.AreNotEqual(25, calculator.Pow("-5",2));
        }
        [Test]
        public void PowZeroValue()
        {
            Assert.AreNotEqual(0, calculator.Pow(0,2));
        }

    }
    [TestClass]
    [Parallelizable]
    public class Cos
    {
        readonly Calculator calculator = new Calculator();
        [TestInitialize]
        public void Setup()
        {

            Console.WriteLine("Test setup");

        }

        [TestMethod]
        public void CosZeroValue()
        {
            Assert.AreEqual(1, calculator.Cos(0));
        }

        [TestCleanup]
        public void Teardown()
        {

            Console.WriteLine("Test teardown");

        }
        [TestMethod]
        public void CosCommonValue()
        {
            Assert.AreEqual(0.5, calculator.Cos(60));
        }
        [TestMethod]
        public void CosNegativeValue()
        {
            Assert.AreEqual(0.54, calculator.Cos(-1));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CosStringBadValue()
        {
            System.NotFiniteNumberException ex = Assert.ThrowsException<System.NotFiniteNumberException>(() => calculator.Cos("BE"));
            Assert.AreEqual("Wrong input", ex.Message);
        }

    }

    [TestClass]
    [Parallelizable]
    public class Sin
    {
        readonly Calculator calculator = new Calculator();
        [TestInitialize]
        public void Setup()
        {

            Console.WriteLine("Test setup");

        }

        [TestMethod]
        public void SinZeroValue()
        {
            Assert.AreEqual(0, calculator.Sin(0));
        }
        public void SinZeroStringValue()
        {
            Assert.AreEqual(0, calculator.Sin("0"));
        }
        [TestCleanup]
        public void Teardown()
        {

            Console.WriteLine("Test teardown");

        }
        [TestMethod]
        public void SinCommonValue()
        {
            Assert.AreEqual(0.5, calculator.Sin(30));
        }
        public void SinCommonStringValue()
        {
            Assert.AreEqual(0.5, calculator.Sin("30"));
        }
        [TestMethod]
        public void SinNegativeValue()
        {
            Assert.AreEqual(-0.84, calculator.Sin(-1));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SinStringBadValue()
        {
            System.NotFiniteNumberException ex = Assert.ThrowsException<System.NotFiniteNumberException>(() => calculator.Sin("BE"));
            Assert.AreEqual("Wrong input", ex.Message);
        }
    }

    [TestFixture]
    [Parallelizable]
    public class Divide
    {
        readonly Calculator calculator = new Calculator();

        [Test, Sequential]
        public void DefaultIntegerDevide(
            [Values(10, 24, 40)] int input,
            [Values(5, 12, 20)] int expectedResult)
        {
            Assert.AreEqual(expectedResult, calculator.Divide(input, 2));

        }
        [TestCase(7.0, 2, 3.5)]
        [TestCase(11.0, 3, 3.6666666666666665)]

        public void DefaultDoubbleDivide(double firstNumer, double secondNumber, double expectedResult)
        {
            Assert.AreEqual(expectedResult, calculator.Divide(firstNumer, secondNumber));

        }
    }
    [TestFixture]
    [Parallelizable]
    public class Multiple
    {
        readonly Calculator calculator = new Calculator();


        [TestCase(7.0, 2, 14)]
        [TestCase("3", 3, 9)]
        [TestCase(0, "0", 0)]

        public void MultipleDifferentValues(double firstNumer, double secondNumber, double expectedResult)
        {
            Assert.AreEqual(expectedResult, calculator.Multiply(firstNumer, secondNumber));

        }
    }
    [TestClass]
    [Parallelizable]
    public class InCompare
    {
        readonly Calculator calculator = new Calculator();
        [Test]
        public void IsPositivePositiveValue()
        {
            Assert.IsTrue(calculator.isPositive(1));
        }
        [Test]
        public void IsPositiveNegativeValue()
        {
            Assert.IsFalse(calculator.isPositive(-1));
        }
        [Test]
        public void IsNegativeNegativeValue()
        {
            Assert.IsTrue(calculator.isNegative(-1));
        }
        [Test]
        public void IsNegativePositiveValue()
        {
            Assert.IsFalse(calculator.isNegative(11));
        }
        [Test]
        public void IsNegativeString()
        {
            Assert.IsTrue(calculator.isNegative("-1"));
        }
        [Test]
        public void IsPositiveString()
        {
            Assert.IsTrue(calculator.isPositive("1"));
        }
        [Test]
        public void IsPositiveZero()
        {
            Assert.IsFalse(calculator.isPositive(0));
        }
        [Test]
        public void IsNegativeZero()
        {
            Assert.IsFalse(calculator.isNegative(0));
        }
    }
}