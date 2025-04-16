using System;
using System.IO;

class Program
{
    const int INF = 1000000000;
    const long P = 1000000007;
    const int N = 1000500;

    static int[] A = new int[10500];
    static int[] S = new int[10500];

    static void Main()
    {
        #if MISTMAC
            // Para testes locais: redireciona entrada e saída
            Console.SetIn(new StreamReader("input.txt"));
            Console.SetOut(new StreamWriter("output.txt") { AutoFlush = true });
        #endif

        int n = int.Parse(Console.ReadLine());
        int s = 0;
        S[0] = 0;

        string[] input = Console.ReadLine().Split();
        for (int i = 0; i < n; i++)
        {
            A[i] = int.Parse(input[i]);
            s += A[i];
            S[i + 1] = s;
        }

        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if ((S[i] - S[j]) % n == 0)
                {
                    Console.WriteLine(i - j);
                    for (int k = j; k < i; k++)
                        Console.Write(A[k] + " ");
                    Console.WriteLine();
                    return;
                }
            }
        }

        Console.WriteLine("0");
    }
}
