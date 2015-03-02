using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        var list = new List<int>();
        string cage = string.Empty;

        while (true)
        {
            cage = Console.ReadLine();
            if (cage != "END")
            {
                list.Add(int.Parse(cage));
            }
            else { break; }
        }
        int cycleCounter = 1;

        while (true)
        {
            //checks for end of the game
            if (list.Count < cycleCounter)
            {
                break;
            }

            //find the sum of the first i-th elements
            int sum = 0;
            for (int i = 0; i < cycleCounter; i++)
            {
                sum += list[i];
            }
            
            //checks if there are "s" cages
            if (sum + cycleCounter > list.Count)
            {
                break;
            }

            //find the sum of the sum of the first i-th elements
            BigInteger sumsOfsumEelemnts = 0;
            BigInteger productOfsumElements = 1;
            for (int i = cycleCounter; i < sum + cycleCounter; i++)
            {
                sumsOfsumEelemnts += list[i];
                productOfsumElements *= list[i];
            }
            var bufferBuilder = new StringBuilder();
            bufferBuilder = bufferBuilder.Append(sumsOfsumEelemnts.ToString())
                .Append(productOfsumElements.ToString());

            for (int i = sum + cycleCounter; i < list.Count; i++)
            {
                bufferBuilder = bufferBuilder.Append(list[i].ToString());
            }
            list.Clear();
            for (int i = 0; i < bufferBuilder.Length; i++)
            {
                if (bufferBuilder[i] != '0' && bufferBuilder[i] != '1')
                {
                    list.Add(bufferBuilder[i]-'0');
                }
            }
            cycleCounter++;
        }

        Console.WriteLine(String.Join(" ",list));
    }
}

