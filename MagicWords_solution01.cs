using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        int Value = Int32.Parse(Console.ReadLine());
        List<string> StrArray = new List<string>();
        for (int i = 0; i < Value; i++)
        {
            StrArray.Add(Console.ReadLine());
        }
        for (int i = 0; i < Value; i++)
        {
            string CurrentString = StrArray[i];
            int Index = CurrentString.Length % (Value + 1);
            StrArray.Insert(Index, CurrentString);
            if (Index < i)
            {
                StrArray.RemoveAt(i + 1);
            }
            else
            {
                StrArray.RemoveAt(i);
            }
            
        }
        StringBuilder Result = new StringBuilder();
        int MaxLength = 0;
        foreach (var Str in StrArray)
        {
            MaxLength = Math.Max(MaxLength, Str.Length);
        }
        for (int i = 0; i < MaxLength; i++)
        {
            foreach (var Str in StrArray)
            {
                if (Str.Length > i)
                {
                    Result.Append(Str[i]);
                }
            }
        }
        Console.WriteLine(Result.ToString());
    }
}

