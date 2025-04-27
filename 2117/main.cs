using System;

namespace Solution{
    class Program{
        static ulong SquareRoot(ulong n){
            var x = (ulong)Math.Sqrt(n);
            return x + (x * x < n ? 1UL : 0UL);
        }

        static ulong Solve(ulong n){
            if (n == 0)
                return 1;

            ulong k = 1;
            for (ulong i = 2; i * i * i <= n; ++i){
                while (n % (i * i) == 0){
                    k *= i;
                    n /= (i * i);
                }

                while (n % i == 0)
                    n /= i;
            }

            for (ulong x = SquareRoot(n); x != 1 && x * x == n; x = SquareRoot(n)){
                k *= x;
                n /= x * x;
            }

            return 1 + k / 2;
        }

        static void Main(string[] args){
            Console.Write("Digite um número: ");
            if (ulong.TryParse(Console.ReadLine(), out ulong n)){
                Console.WriteLine(Solve(n));
            }else{
                Console.WriteLine("Entrada inválida.");
            }
        }
    }
}
