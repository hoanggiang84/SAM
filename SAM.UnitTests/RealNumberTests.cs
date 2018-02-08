using NUnit.Framework;
using SAM.Library;

namespace SAM.UnitTests
{
    [TestFixture]
    public class RealNumberTests
    {
        [Test]
        public void DotRealNumber_IntegerAndFractionalPart()
        {
            var num = ".567";
            var realNum = new RealNumber(num);
            Assert.AreEqual("", realNum.Integer, string.Format("Integer part of real number: {0}", num));
            Assert.AreEqual("567", realNum.Fractional, string.Format("Fractional part of real number: {0}", num));
        }

        [Test]
        public void DotNegativeRealNumber_IntegerAndFractionalPart()
        {
            var num = "-.567";
            var realNum = new RealNumber(num);
            Assert.AreEqual("-", realNum.Integer, string.Format("Integer part of real number: {0}", num));
            Assert.AreEqual("567", realNum.Fractional, string.Format("Fractional part of real number: {0}", num));
        }

        [Test]
        public void DotRealNumber2_IntegerAndFractionalPart()
        {
            var num = "123.";
            var realNum = new RealNumber(num);
            Assert.AreEqual("123", realNum.Integer, string.Format("Integer part of real number: {0}", num));
            Assert.AreEqual("", realNum.Fractional, string.Format("Fractional part of real number: {0}", num));
        }

        [Test]
        public void PositiveRealNumber_IntegerAndFractionalPart()
        {
            var num = "123.567";
            var realNum = new RealNumber(num);
            Assert.AreEqual("123", realNum.Integer, string.Format("Integer part of real number: {0}",num));
            Assert.AreEqual("567", realNum.Fractional, string.Format("Fractional part of real number: {0}", num));
        }

        [Test]
        public void NegativeRealNumber_IntegerAndFractionalPart()
        {
            var num = "-123.567";
            var realNum = new RealNumber(num);
            Assert.AreEqual("-123", realNum.Integer, string.Format("Integer part of real number: {0}", num));
            Assert.AreEqual("567", realNum.Fractional, string.Format("Fractional part of real number: {0}", num));
        }

        [Test]
        public void IntegerNumber_IntegerAndFractionalPart()
        {
            var num = "123";
            var realNum = new RealNumber(num);
            Assert.AreEqual("123", realNum.Integer, string.Format("Integer part of real number: {0}", num));
            Assert.AreEqual("", realNum.Fractional, string.Format("Fractional part of real number: {0}", num));
        }
    }
}