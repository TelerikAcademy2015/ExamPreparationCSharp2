using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    private static int n;
    private static int m;
    private static char[,] field;
    private static int x;
    private static int y;
    private static int enemies;
    private static int[,] enemiesPositions;
    private static int exitsCounter = 0;

    static void Main()
    {
        EnterInformation();
        FillField();
        FindPath(0, 0);
        Console.WriteLine(exitsCounter);
    }

    static void EnterInformation()
    {
        string[] size = Console.ReadLine().Split(' ');
        n = int.Parse(size[0]);
        m = int.Parse(size[1]);

        string[] startPosition = Console.ReadLine().Split(' ');
        x = int.Parse(startPosition[0]);
        y = int.Parse(startPosition[1]);

        enemies = int.Parse(Console.ReadLine());
        enemiesPositions = new int[enemies, 2];
        for (int i = 0; i < enemies; i++)
        {
            string[] enemyPosition = Console.ReadLine().Split(' ');
            enemiesPositions[i, 0] = int.Parse(enemyPosition[0]);
            enemiesPositions[i, 1] = int.Parse(enemyPosition[1]);
        }
    }
    static void FillField()
    {
        field = new char[n, m];
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                field[i, j] = '*';
            }
        }
        //final and enemies
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (i == x && j == y)
                {
                    field[i, j] = 'f';
                }

                for (int k = 0; k < enemiesPositions.GetLength(0); k++)
                {
                    if (i == enemiesPositions[k, 0] && j == enemiesPositions[k, 1])
                    {
                        field[i, j] = 's';
                    }
                }

            }
        }
    }
    static void FindPath(int row, int col)
    {
        if (row < 0 || row >= field.GetLength(0) || col < 0 || col >= field.GetLength(1))
        {
            return;
        }
        if (field[row, col] == 'f')
        {
            exitsCounter++;
            return;
        }

        if (field[row, col] == 's')
        {
            return;
        }

        field[row, col] = 's';

        FindPath(row + 1, col);
        FindPath(row, col + 1);

        field[row, col] = '*';
    }



    static void FindPathWithIteration()
    {

        for (int i = 0; i < n + m; i++)
        {
            int row = 0;
            int col = 0;
            for (int j = 0; j < n + m; j++)
            {

                if (field[row, col] == 'f')
                {
                    exitsCounter++;
                    break;
                }

                row++;
                Console.WriteLine("D");

                if (row >= field.GetLength(0))
                {
                    Console.WriteLine("U-F");
                    row--; col++;
                    if (field[row, col] == '*' && field[row - 1, col - 1] == '*')
                    {
                        field[row, col - 1] = 's';
                    }
                }
                if (col >= field.GetLength(1))
                {
                    col--; row++;
                    if (field[row, col] == '*' && field[row - 1, col - 1] == '*')
                    {
                        field[row, col] = 's';
                    }
                    Console.WriteLine("B-D");
                }
                if (field[row, col] == 's')
                {
                    row--; col++;
                    Console.WriteLine("U-F");
                }
                else
                {
                    if (field[row - 1, col] == '*' && field[row, col + 1] == '*')
                    {
                        field[row, col] = 's';
                    }
                }

                if ((row == n - 1) && (col == m - 1))
                {
                    if (field[row, col] != 'f')
                    {
                        break;
                    }
                }

            }
            Console.WriteLine();

        }
    }
}



