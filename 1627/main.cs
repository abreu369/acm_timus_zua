using System;

class Program{
    static readonly long p = (long)1e9;
    const int maxn = 81;
    static long[,] A = new long[maxn, maxn]; // The Laplacian matrix
    static int[,] B = new int[maxn, maxn];   // The vertex number of each room
    static char[,] S = new char[9, 10];      // The input
    static int n, m, r = -1;

 // Calculates the determinant of the Laplacian
    static long Calc(){
        long ret = 1;
        for (int i = 1; i <= r; i++){
            for (int j = i + 1; j <= r; j++){
                // We can't calculate the modular inverse, but we can whittle down the pivot column:
                while (A[j, i] != 0){
                    long t = A[i, i] / A[j, i];
                    for (int k = i; k <= r; k++)
                        A[i, k] = (p * p + A[i, k] - t * A[j, k]) % p;

                    // Swap rows
                    for (int k = 0; k <= r; k++){
                        long temp = A[i, k];
                        A[i, k] = A[j, k];
                        A[j, k] = temp;
                    }

                    ret = -ret;
                }
            }
            ret = (p * p + ret * A[i, i]) % p;
        }
        return ret;
    }

    // Connects two rooms in the graph
    static void Add(int i, int j, int i2, int j2) {
        if (i2 < 0 || i2 >= n || j2 < 0 || j2 >= m)
            return;

        if (S[i2, j2] == '.'){
            int a = B[i, j], b = B[i2, j2];
            A[a, a]++;
            A[a, b] = A[b, a] = -1;
        }
    }

    static void Main(){
        string[] nm = Console.ReadLine().Split();
        n = int.Parse(nm[0]);
        m = int.Parse(nm[1]);

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < m; j++){
                S[i, j] = line[j];
                B[i, j] = (S[i, j] != '*') ? ++r : r;
            }
        }

        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                if (S[i, j] == '.')
                    foreach (int p in new int[] { -1, 1 }){
                        Add(i, j, i + p, j);
                        Add(i, j, i, j + p);
                    }

        Console.WriteLine(Calc());
    }
}
