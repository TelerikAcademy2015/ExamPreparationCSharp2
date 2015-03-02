using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;


class MovingLetters
{
    static void Main()
    {
        string text = Console.ReadLine();
        string resultText = ExtractLetters(text);
        string resultSecondText = MoveLetters(resultText);
        Console.WriteLine(resultSecondText);
    }



    static string ExtractLetters(string text)
    {
        string[] wordsArr = text.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder sb = new StringBuilder();
        int length = 0;
        for (int i = 0; i < wordsArr.Length; i++)
        {
            if (wordsArr[i].Length > length)
            {
                length = wordsArr[i].Length;
            }
        }

        for (int i = 0; i < length; i++)
        {
            foreach (var word in wordsArr)
            {
                if ((word.Length - 1) - i < 0)
                {
                }
                else
                {
                    sb.Append(word[(word.Length - 1) - i]);
                }
            }
        }

        string result = sb.ToString();
        return result;
    }

    static string MoveLetters(string text)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            int moveLength = 0;
            char currentChar = Convert.ToChar(text[i]);
            if (char.IsLower(currentChar))
            {
                moveLength = currentChar - 96;
            }
            else
            {
                moveLength = currentChar - 64;
            }

            int insertIndex = (moveLength+i) % text.Length ;
            string letter = text[i].ToString();
            text = text.Remove(i, 1);
            text = text.Insert(insertIndex, letter);
        }
        return text;
    }
}

