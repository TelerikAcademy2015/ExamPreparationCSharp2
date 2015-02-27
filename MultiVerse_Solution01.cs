using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
class Program
{
    public static BigInteger Decode(string Code)
    {
        //This variable will store the final result.
        BigInteger DecValue = 0;
        //This variable will store the temp digit during calculations.
        BigInteger TempNum = 0;

        //NOTE: We read the string backwards!
        for (int i = 0; i < Code.Length; i++)
        {
            DecValue *= 13;
            //First we check if we have a digit or a letter on the current position.
            if (BigInteger.TryParse(Code[i].ToString(), out TempNum))
            {
                //In case of a digit we simply add the value. 
                
                DecValue += TempNum;
            }
            else
            {
                //In case of a letter we use a switch statement to 
                //calculate accordingly. 
                switch (Code[i].ToString())
                {
                    case "A":
                        DecValue += 10;
                        break;
                    case "B":
                        DecValue += 11;
                        break;
                    case "C":
                        DecValue += 12;
                        break;
                }
            }
        }
        return DecValue;
    }
    public static string IndexOfCode(string Code)
    {
        string Result = "";
        List<string> Values = new List<string>() { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", 
            "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA"};
        int Index = Values.IndexOf(Code);
        switch (Index)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
                Result = Index.ToString();
                break;
            case 10: Result = "A"; break;
            case 11: Result = "B"; break;
            case 12: Result = "C"; break;
        }
        return Result;
    }


    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < input.Length; i += 3)
        {
            var temp = input.Substring(i, 3);
            result.Append(IndexOfCode(temp));
        }
        Console.WriteLine(Decode(result.ToString()));
    }
}

