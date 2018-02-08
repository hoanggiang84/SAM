using System;
using System.Globalization;
using NUnit.Framework;
using SAM.Library;

namespace SAM.UnitTests
{
    [TestFixture]
    public class NumberScrollTest
    {
        private int num;
        [SetUp]
        public void Setup()
        {
            num = new Random().Next(1000); 
        }

        [Test]
        public void ScrollUpNumberString_InvalidNumber_ReturnZero()
        {
            Assert.AreEqual(0, NumberScroll.ScrollUp("abc"));
        }

        [Test]
        public void ScrollUpNumberStringAtBeyondNumberLength_ReturnNumber()
        {
            var numberLength = num.ToString().Length;
            Assert.AreEqual(num, NumberScroll.ScrollUp(num.ToString(CultureInfo.InvariantCulture), numberLength + num));
        }

        [Test]
        public void ScrollUpNumberStringAtNonPositiveIndex_ReturnNumber()
        {
            var nonPositiveIndex = -(new Random().Next(1000));
            Assert.AreEqual(num, NumberScroll.ScrollUp(num.ToString(CultureInfo.InvariantCulture), nonPositiveIndex));
        }

        [Test]
        public void ScrollUpNullString_ReturnZero()
        {
            Assert.AreEqual(0, NumberScroll.ScrollUp(string.Empty));
        }

        [Test]
        public void ScrollUpNumberStringAtNumberLength_IncreaseNumberbyOne()
        {
            var numberLength = num.ToString().Length;
            Assert.AreEqual(num + 1, NumberScroll.ScrollUp(num.ToString(CultureInfo.InvariantCulture), numberLength));
        }

        [Test]
        public void ScrollUpNumberStringAtNumberLengthMinusOne_IncreaseNumberbyTen()
        {
            var numberLength = num.ToString().Length;
            Assert.AreEqual(num + 10, NumberScroll.ScrollUp(num.ToString(CultureInfo.InvariantCulture), numberLength - 1));
        }

        [Test]
        public void ScrollUpNumberStringAtAnyIndex_IncreaseNumberAtThatIndex([
            Range(1, 10)]  int index)
        {
            // Eg. Scroll 1000 at index 1 return 2000
            num = 1000000000;
            var numberLength = num.ToString().Length;
            var dVal = Math.Pow(10, (numberLength - index));
            Assert.AreEqual(num + dVal, NumberScroll.ScrollUp(num.ToString(), index), string.Format("Number: {0}. Index: {1}", num, index));
        }

    }
}
