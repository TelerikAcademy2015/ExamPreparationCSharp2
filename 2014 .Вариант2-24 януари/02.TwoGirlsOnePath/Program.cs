using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


class TwoGirlsOnePath
{
    static void Main(string[] args)
    {
        BigInteger[] paths = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();
        BigInteger mollyFlowers = 0;
        int mollyCurrentCell = 0;

        BigInteger dollyFlowers = 0;
        int dollyCurrentCell = paths.Length - 1;
        while (true)
        {
            if (paths[mollyCurrentCell] == 0 || paths[dollyCurrentCell] == 0)
            {
                if (paths[mollyCurrentCell] == 0 && paths[dollyCurrentCell] == 0)
                {
                    Console.WriteLine("Draw");
                    Console.WriteLine(mollyFlowers + " " + dollyFlowers);

                }
                else
                {
                    if (paths[mollyCurrentCell] == 0)
                    {

                        dollyFlowers += paths[dollyCurrentCell];
                        Console.WriteLine("Dolly");
                        Console.WriteLine(mollyFlowers + " " + dollyFlowers);
                    }
                    else
                    {
                        mollyFlowers += paths[mollyCurrentCell];
                        Console.WriteLine("Molly");
                        Console.WriteLine(mollyFlowers + " " + dollyFlowers);
                    }
                }


                break;
            }
            BigInteger mollyCurrentFlowers = paths[mollyCurrentCell];
            BigInteger dollyCurrentFlowers = paths[dollyCurrentCell];

            if (mollyCurrentCell == dollyCurrentCell)
            {
                if (paths[mollyCurrentCell] % 2 == 0)
                {
                    mollyFlowers += paths[mollyCurrentCell] / 2;
                    dollyFlowers += paths[dollyCurrentCell] / 2;
                    paths[mollyCurrentCell] = 0;
                    paths[dollyCurrentCell] = 0;
                    mollyCurrentFlowers = paths[mollyCurrentCell];
                    dollyCurrentFlowers = paths[mollyCurrentCell];
                    mollyCurrentCell = (int)((mollyCurrentCell + mollyCurrentFlowers) % paths.Length);
                    dollyCurrentCell = (dollyCurrentCell - dollyCurrentFlowers % paths.Length) > 0 ? (Math.Abs(dollyCurrentCell - (int)(dollyCurrentFlowers % paths.Length))) : (paths.Length - 1 - Math.Abs((dollyCurrentCell - (int)((dollyCurrentFlowers - 1) % paths.Length))));


                }
                else
                {
                    mollyFlowers += paths[mollyCurrentCell] / 2;
                    dollyFlowers += paths[dollyCurrentCell] / 2;
                    mollyCurrentFlowers = paths[mollyCurrentCell];
                    dollyCurrentFlowers = paths[mollyCurrentCell];
                    paths[mollyCurrentCell] = 1;
                    paths[dollyCurrentCell] = 1;
                    mollyCurrentCell = (int)((mollyCurrentCell + mollyCurrentFlowers) % paths.Length);
                    dollyCurrentCell = (dollyCurrentCell - dollyCurrentFlowers % paths.Length) > 0 ? (Math.Abs(dollyCurrentCell - (int)(dollyCurrentFlowers % paths.Length))) : (paths.Length - 1 - Math.Abs((dollyCurrentCell - (int)((dollyCurrentFlowers - 1) % paths.Length))));
                }
            }
            else
            {
                mollyFlowers += paths[mollyCurrentCell];
                dollyFlowers += paths[dollyCurrentCell];
                paths[mollyCurrentCell] = 0;
                paths[dollyCurrentCell] = 0;
                mollyCurrentCell = (int)((mollyCurrentCell + mollyCurrentFlowers) % paths.Length);
                dollyCurrentCell = (dollyCurrentCell - dollyCurrentFlowers % paths.Length) > 0 ? (Math.Abs(dollyCurrentCell - (int)(dollyCurrentFlowers % paths.Length))) : (paths.Length - 1 - Math.Abs((dollyCurrentCell - (int)((dollyCurrentFlowers - 1) % paths.Length))));
            }



        }
    }
}

