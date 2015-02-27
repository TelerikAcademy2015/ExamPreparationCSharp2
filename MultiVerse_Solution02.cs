using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_Exam2013_Multiverse
{
    class Solution02
    {
        static void Main()
        {
            List<string> Values = new List<string>() { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", 
            "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA"};
            string input = Console.ReadLine();
            long Decimal = 0;
            for (int i = 0; i < input.Length; i+=3)
            {
                var TempDigit = input.Substring(i, 3);
                var CurrentDigit = Values.IndexOf(TempDigit);
                Decimal *= 13;
                Decimal += CurrentDigit;
            }
            Console.WriteLine(Decimal);
        }
    }
}
