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
        public static double ScrollUp(string number, int index = -1)
        {
            double num;
            if (!double.TryParse(number, out num))
                return 0;

            if (index <= 0 || index > number.Length)
                return num;

            var numberLength = number.Length;
            var dVal = Math.Pow(10, numberLength - index);
            num += dVal;

            return num;
        }
    }
}
