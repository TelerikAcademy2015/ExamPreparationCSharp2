using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TheyAreGreen
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var list = new List<char>();
        int result;

        for (int i = 0; i < n; i++)
        {
            list.Add(char.Parse(Console.ReadLine()));
        }
        int listLength = list.Count;

        var sb = new StringBuilder();
        sb.Append(list[0]);
        bool isTheSame = false;
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < sb.Length; j++)
            {
                if (list[i] == sb[j])
                {
                    isTheSame = true;
                    break;
                }
            }
            if (!isTheSame)
            {
                sb.Append(list[i]);
            }
            isTheSame = false;
        }

        if (sb.Length < listLength)
        {
            if (listLength % 2 == 0)
            {
                if (listLength / sb.Length >= listLength / 2)
                {
                    result = 0;
                }
                else
                {
                    result = 1;
                    for (int i = 1; i <= sb.Length-1; i++)
                    {
                        result *= i;
                    }
                }
            }
            else
            {
                if (listLength / sb.Length > listLength / 2)
                {
                    result = 0;
                }
                else
                {
                    result = 1;
                    for (int i = 1; i <= sb.Length-1; i++)
                    {
                        result *= i;
                    }
                }
            }
        }
        else
        {
            result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
        }
        //Console.WriteLine(sb.ToString());
        Console.WriteLine(result);
    }
}

