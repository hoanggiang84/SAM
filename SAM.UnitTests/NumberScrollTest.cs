using System;
using System.Globalization;
using NUnit.Framework;
using SAM.Library;

namespace SAM.UnitTests
{
    [TestFixture]
    public class NumberScrollTest
    {
        private double RoundDouble(double number, int fractionLength)
        {
            return Math.Round(number, fractionLength, MidpointRounding.AwayFromZero);
        }

        private int num;
        [SetUp]
        public void Setup()
        {
            num = new Random().Next(1000); 
        }

        [Test]
        public void ScrollUpNumberString_InvalidNumber_ReturnZero()
        {
            Assert.AreEqual(0, NumberScroll.Scroll("abc"));
        }

        [Test]
        public void ScrollUpNumberStringAtBeyondNumberLength_ReturnNumber()
        {
            var numberLength = num.ToString().Length;
            Assert.AreEqual(num, NumberScroll.Scroll(num.ToString(CultureInfo.InvariantCulture), numberLength + num));
        }

        [Test]
        public void ScrollUpNumberStringAtNonPositiveIndex_ReturnNumber()
        {
            var nonPositiveIndex = -(new Random().Next(1000));
            Assert.AreEqual(num, NumberScroll.Scroll(num.ToString(CultureInfo.InvariantCulture), nonPositiveIndex));
        }

        [Test]
        public void ScrollUpNullString_ReturnZero()
        {
            Assert.AreEqual(0, NumberScroll.Scroll(string.Empty));
        }

        [Test]
        public void ScrollUpNumberStringAtNumberLength_IncreaseNumberbyOne()
        {
            var numberLength = num.ToString().Length;
            Assert.AreEqual(num + 1, NumberScroll.Scroll(num.ToString(CultureInfo.InvariantCulture), numberLength));
        }

        [Test]
        public void ScrollUpNumberStringAtAnyIndex_IncreaseNumberAtThatIndex(
            [Range(1, 10)]  int index)
        {
            // Eg. Scroll 1000 at index 1 return 2000
            num = 1000000000;
            var numberLength = num.ToString().Length;
            var dVal = Math.Pow(10, (numberLength - index));
            Assert.AreEqual(num + dVal, NumberScroll.Scroll(num.ToString(), index), string.Format("Number: {0}. Index: {1}", num, index));
        }

        [Test]
        public void ScrollUpDoubleNumberAtIndex_IncreaseNumberAtIndex(
            [Range(5,7)] int index)
        {
            var dblNum = 123.567;
            var dval = Math.Pow(10, 3 - index + 1);
            Assert.AreEqual(RoundDouble(dblNum + dval, 3), NumberScroll.Scroll(dblNum.ToString(), index));
        }

        [Test]
        public void ScrollUpNegativeNumberAtIndexInIntegerPart_IncreaseNumberAtIndex(
            [Range(2,4)] int index)
        {
            var dblnum = -234.678;
            var realNumber = new RealNumber(dblnum.ToString());
            var dval = Math.Pow(10, realNumber.Integer.Length - index);
            var expected = RoundDouble(dblnum + dval, 3);
            Assert.AreEqual(expected, NumberScroll.Scroll(dblnum.ToString(), index));
        }

        [Test]
        public void ScrollUpNegativeNumberAtIndexInFractionalPart_IncreaseNumberAtIndex(
            [Range(6, 8)] int index)
        {
            var dblnum = -234.678;
            var realNumber = new RealNumber(dblnum.ToString());
            var dval = Math.Pow(10, realNumber.Integer.Length - index + 1);
            var expected = RoundDouble(dblnum + dval, 3);
            Assert.AreEqual(expected, NumberScroll.Scroll(dblnum.ToString(), index));
        }

        [Test]
        public void ScrollUpNegativeNumberAtMinusIndexInFractionalPart_ReturnNumber()
        {
            var index = 1;
            var dblnum = -234.678;
            Assert.AreEqual(-134.678, NumberScroll.Scroll(dblnum.ToString(), index));
        }

        [Test]
        public void ScrollDownDoubleNumbetAtIndex_DecreaseNumber()
        {
            var index = 1;
            var dblnum = -234.678;
            Assert.AreEqual(-334.678, NumberScroll.Scroll(dblnum.ToString(), index, ScrollDirection.DOWN));
        }

    }
}
