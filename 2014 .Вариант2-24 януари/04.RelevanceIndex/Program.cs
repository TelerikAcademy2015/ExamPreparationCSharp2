using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        string word = Console.ReadLine();
        int lines = int.Parse(Console.ReadLine());
        var text = new string[lines][];
        int[] numberOfOccurances = new int[lines];
        for (int i = 0; i < lines; i++)
        {
            text[i] = Console.ReadLine()
                .Split(new char[] { ',', '.', '(', ')', ';', '-', '!', '?',' '}, StringSplitOptions.RemoveEmptyEntries);

            int count = 0;
            for (int j = 0; j < text[i].Length; j++)
            {
                if (text[i][j].ToUpper() == word.ToUpper())
                {
                    text[i][j] = text[i][j].ToUpper();
                    count++;
                }
            }
            numberOfOccurances[i] = count;
        }


        for (int i = 0; i < lines; i++)
        {
            int lineWithMaxOccurances = -1;
            int maxOccurances = -1;
            for (int j = 0; j < lines; j++)
            {
                if (numberOfOccurances[j] > maxOccurances)
                {
                    maxOccurances = numberOfOccurances[j];
                    lineWithMaxOccurances = j;
                }
            }

            Console.WriteLine(String.Join(" ", text[lineWithMaxOccurances]));
            numberOfOccurances[lineWithMaxOccurances] = -1;

        }
    }
}

