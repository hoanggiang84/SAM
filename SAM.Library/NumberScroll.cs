using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Library
{
    public static class NumberScroll
    {
        /// <summary>
        /// Increase number at index.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="index">From 1 to number length</param>
        /// <returns></returns>
        public static double Scroll(string number, int index = -1, ScrollDirection dir = ScrollDirection.UP)
        {
            double num;
            if (!double.TryParse(number, out num))
                return 0;

            if (index <= 0 || index > number.Length)
                return num;

            if (index == 1 && num < 0)
                index = 2;

            var realNumber = new RealNumber(number);
            var pow = realNumber.Integer.Length - index;
            pow = (pow >= 0) ? pow : pow + 1;

            switch (dir)
            {
                case ScrollDirection.UP:
                    num += Math.Pow(10, pow);
                    break;
                case ScrollDirection.DOWN:
                    num -= Math.Pow(10, pow);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("dir");
            }
            
            return Math.Round(num, realNumber.Fractional.Length, MidpointRounding.AwayFromZero);
        }
    }

    public enum ScrollDirection
    {
        UP = 1,
        DOWN = -1
    }
}
