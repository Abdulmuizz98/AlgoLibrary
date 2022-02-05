using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLibrary.LeetCode
{
    class Problems
    {
        public int RomanToInt(string s)
        {
            const string openB = "(";
            const string closeB = ")";

            s = s.Replace("CM", "(900)");
            s = s.Replace("CD", "(400)");
            s = s.Replace("XC", "(90)");
            s = s.Replace("XL", "(40)");
            s = s.Replace("IX", "(9)");
            s = s.Replace("IV", "(4)");

            s = s.Replace("M", "(1000)");
            s = s.Replace("D", "(500)");
            s = s.Replace("C", "(100)");
            s = s.Replace("L", "(50)");
            s = s.Replace("X", "(10)");
            s = s.Replace("V", "(5)");
            s = s.Replace("I", "(1)");

            int sum = 0;
            while (s != "")
            {
                int startIndex = s.IndexOf(openB);
                int endIndex = s.IndexOf(closeB);
                int range = endIndex - startIndex + 1;

                string numString = s.Substring(startIndex, range);
                numString = numString.Replace(openB, "");
                numString = numString.Replace(closeB, "");

                int num = int.Parse(numString);
                sum += num;

                if (s == "") break;
                s = s.Substring(range);

            }
            return sum;
        }
    }
}
