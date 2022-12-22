using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Determinant
{
    class Program
    {
        
        static int rng;
        static int[,] m;
        static float det = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("De cat sa fie matricea?");
            Console.WriteLine("Matricea va fi generata aleator");
            rng = Convert.ToInt32(Console.ReadLine());
            m = new int[rng, rng];
            Random rnd = new Random();
            for (int i = 0; i < rng; i++)
                for (int j = 0; j < rng; j++)
                    m[i, j] = rnd.Next(10);
            for (int i = 0; i < rng; i++)
            {
                for (int j = 0; j < rng; j++)
                    Console.Write(m[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
            int[] sol = new int[rng];
            bool[] b = new bool[rng];
            Permutari(0, rng, sol, b);
            Console.WriteLine($"Determinantul este egal cu : {det}");
            Console.ReadKey();
        }

        static void Permutari(int k, int n, int[] sol, bool[] b)
        {
            int[] v = new int[n];
            if (k >= n)
            {
                for (int i = 0; i < n; i++)
                    v[i] = sol[i];
                Prelucrare(v);
            }
            else
                for (int i = 0; i < n; i++)
                    if (b[i] == false)
                    {
                        b[i] = true;
                        sol[k] = i;
                        Permutari(k + 1, n, sol, b);
                        b[i] = false;
                    }
        }

        static void Prelucrare(int[] v)
        {
            int grad = 0;
            float produs = 1;
            for (int i = 0; i < rng; i++)
                for (int j = i + 1; j < rng; j++)
                    if (v[i] > v[j]) grad++;
            for (int i = 0; i < rng; i++)
            {
                produs *= m[i, v[i]];
            }
            if (grad % 2 == 0) det += produs;
            else det -= produs;
        }
    }
}