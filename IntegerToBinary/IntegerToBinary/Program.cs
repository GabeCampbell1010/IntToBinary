using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetBinaryValue(46));
            Console.ReadKey();
        }
        public static string GetBinaryValue(int value)
        {
            //THIS VAR ANS IS SIMPLY USED TO FIND THE INTTOBINARY CONVERSION BUILTIN TO VS TO USE TO COMPArE TO THE ANSWER IN THE DEBUG.ASSERT STATEMENT, THE ACTUAL ANSWER IS NOT BEING DETERMINED THIS WAY
            var ans = Convert.ToString(value, 2);
            //END DEBUG SECTION

            int quotient = 1;
            int remainder;
            List<int> list = new List<int>();
            List<int> listReversed = new List<int>();
            string answer = "";

            while (quotient != 0)
            {
                quotient = value / 2;
                remainder = value % 2;
                list.Add(remainder);
                value = quotient;
            }

            //reverse the list to make it in the correct order
            for (int i = 0; i < list.Count(); i++)
            {
                listReversed.Add(list[list.Count() - 1 - i]);
            }
            list = listReversed;

            foreach (int num in list) answer += num.ToString();

            //begin debug section
            Debug.Assert(answer == ans);
            //end debug section

            return answer;
        }
    }
}
