using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


class ProgStrangeNumbers
{

    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        var sb = new StringBuilder();
        BigInteger sum = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if(char.IsLower(text[i]))
            {
                switch (text[i])
                {
                    case 'f': sb.Append(0); break;
                    case 'b': sb.Append(1); break;
                    case 'o': sb.Append(2); break;
                    case 'm': sb.Append(3); break;
                    case 'l': sb.Append(4); break;
                    case 'p': sb.Append(5); break;
                    case 'h': sb.Append(6); break;
                }
            }
        }
        int degree = 0;
        for (int i = sb.Length-1; i >= 0; i--)
        {
            sum += Convert.ToInt32(sb[i] - '0') * (BigInteger)(Math.Pow(7, degree));
            degree++;
        }
        Console.WriteLine(sum);

    }
}

