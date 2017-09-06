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
            Console.WriteLine(GetBinaryValue(-5));
            Console.ReadKey();
        }

        public static bool CheckForTwos(List<int> array)
        {
            for (int i = 0; i < array.Count - 1; i++)
            {
                if (array[i] > 1)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<int> Sign(List<int> array)
        {
            for (int i = 0; i < array.Count; i++)//flip the values
            {
                if (array[i] == 0)
                    array[i] = 1;
                else
                    array[i] = 0;
            }
            //add 1 to the final position in the array
            array[array.Count - 1] += 1;

            //check if adding that above 1 in the last spot of the array has increased the value to 2, and adjust the array accordingly so long as it is not in proper binary format
            while (CheckForTwos(array))
            {
                for (int i = 0; i < array.Count - 1; i++)
                {
                    if (array[i] > 1)
                    {
                        array[i] = 1;
                        array[i - 1] += 1;
                    }
                }
            }
            return array;
        }

        public static string GetBinaryValue(int value)
        {
            //THIS VAR ANS IS SIMPLY USED TO FIND THE INTTOBINARY CONVERSION BUILTIN TO VS TO USE TO COMPArE TO THE ANSWER IN THE DEBUG.ASSERT STATEMENT, THE ACTUAL ANSWER IS NOT BEING DETERMINED THIS WAY
            var ans = Convert.ToString(value, 2);
            //END DEBUG SECTION

            bool isNegative = false;
            if(value < 0)
            {
                value *= -1;//make it positive and do all the conversion to binary and then convert that answer to its negative form
                isNegative = true;
            }


            //variables for the modulus method
            int quotient = 1;
            int remainder;
            List<int> list = new List<int>();
            List<int> listReversed = new List<int>();
            string answer = "";

            //variables for the bitwise method
            List<int> listExperiment = new List<int>();
            List<int> listExperimentReversed = new List<int>();
            int valueExperiment = value;
            int bit;

            Console.WriteLine("Intitial Integer Value: " + value);

            //populate the list with the correct integer values as per the necessary calculations
            //can i just exclude the below part and replace it with bitwise operators?


            while (valueExperiment > 0)//actually this needs to be until hits 0 or -1, so i need to add some stuff here i think
            {//you can actually do both this and the hexadecimal algorithms as one and just not hard code 1 and 15 and instead make them variables that change based on the desired conversion type
                bit = valueExperiment & 1;
                listExperiment.Add(bit);
                valueExperiment >>= 1;
            }


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

            for (int i = 0; i < listExperiment.Count(); i++)
            {
                listExperimentReversed.Add(listExperiment[listExperiment.Count() - 1 - i]);
            }
            listExperiment = listExperimentReversed;


            if (isNegative)
            {
                Sign(list);
                Sign(listExperiment);
            }



            //assert
            string debuganswer = "";
            foreach (int num in listExperiment) debuganswer += num.ToString();
            //Debug.Assert(debuganswer == ans);

            

            answer = "Modulus Conversion Method Answer: ";
            foreach (int num in list) answer += num.ToString();
            answer += "\nBitwise Operator Conversion Method Answer: ";
            foreach (int num in listExperiment) answer += num.ToString();


            //begin debug section
            
            //end debug section

            return answer;
        }
    }
}
