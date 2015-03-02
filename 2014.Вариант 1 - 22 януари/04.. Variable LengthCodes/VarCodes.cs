using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        int numberOfLetters = int.Parse(Console.ReadLine());
        string[] words = new string[numberOfLetters];
        //read the numbers
        for (int i = 0; i < numberOfLetters; i++)
        {
            words[i] = Console.ReadLine();
        }

        var dictionary = new Dictionary<string, char>();
        //fill the dictionary
        for (int i = 0; i < numberOfLetters; i++)
        {
            dictionary.Add(words[i].Substring(1, words[i].Length - 1), words[i][0]);
        }
        //new stringbuilder
        var builder = new StringBuilder(50000);
        for (int i = 0; i < numbers.Length; i++)
        {
            builder.Append(ConvertToBinary(numbers[i]));
        }
        string[] resultNumbers = SplitWords(builder);
        int length = SplitWords(builder).Length;
        builder.Clear();
        for (int i = 0; i < length; i++)
        {
            if (dictionary.ContainsKey(resultNumbers[i]))
            {
                builder.Append(dictionary[resultNumbers[i]]);
            }
        }
        Console.WriteLine(builder);
    }

    static StringBuilder ConvertToBinary(int number)
    {
        int count = 8;
        var sb = new StringBuilder();

        while (number > 0)
        {
            sb.Insert(0, number % 2);
            number /= 2;
            count--;
        }
        if (count > 0)
        {
            sb.Insert(0, "0");
            count--;
        }

        return sb;
    }

    static string[] SplitWords(StringBuilder sb)
    {
        string[] numbers = sb.ToString().Split(new char[] { '0' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = numbers[i].Length.ToString();
        }


        return numbers;
    }
}

