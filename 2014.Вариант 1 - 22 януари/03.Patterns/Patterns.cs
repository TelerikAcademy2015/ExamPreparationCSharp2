using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Patterns
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = numbers[j];
            }
        }
        int bestSum = int.MinValue;
        int sum = int.MinValue;
        for (int i = 0; i < n - 2; i++)
        {
            for (int j = 0; j < n - 4; j++)
            {
                if (matrix[i, j] < matrix[i, j + 1] && matrix[i, j + 1] < matrix[i, j + 2] &&
                    matrix[i, j + 2] < matrix[i + 1, j + 2] && matrix[i + 1, j + 2] < matrix[i + 2, j + 2] &&
                    matrix[i + 2, j + 2] < matrix[i + 2, j + 3] && matrix[i + 2, j + 3] < matrix[i + 2, j + 4])
                {
                    sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j + 2] +
                    +matrix[i + 2, j + 2] + matrix[i + 2, j + 3] + matrix[i + 2, j + 4];
                    if (bestSum < sum)
                    {
                        bestSum = sum;
                    }
                }
            }
        }





        if (bestSum != int.MinValue)
        {
            Console.WriteLine("YES " + bestSum);
        }
        else
        {
            sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        sum += matrix[i, j];
                    }
                }
            }
            Console.WriteLine("NO " + sum);
        }


    }
}

