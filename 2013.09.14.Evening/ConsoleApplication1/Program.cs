using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string[] wordsArr = text.Split(' ');

            int length = 0;
            for (int i = 0; i < wordsArr.Length; i++)
            {
                if (wordsArr[i].Length > length)
                {
                    length = wordsArr[i].Length;
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                foreach (var word in wordsArr)
                {
                    if ((word.Length - 1) - i >= 0)
                    {
                        sb.Append(word[(word.Length - 1) - i]);
                    }
                }
            }

            for (int i = 0; i < sb.Length; i++)
            {
                int moveLength = 0;
                char currentChar = Convert.ToChar(sb[i]);
                if (char.IsLower(currentChar))
                {
                    moveLength = currentChar - 'a'+1;
                }
                else
                {
                    moveLength = currentChar - 'A'+1;
                }

                int insertIndex = (moveLength + i) % sb.Length;
                string letter = sb[i].ToString();
                sb.Remove(i, 1);
                sb.Insert(insertIndex, letter);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
