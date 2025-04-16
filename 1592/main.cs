using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        List<uint> v = new List<uint>();
        
        for (uint i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(':');
            uint h = uint.Parse(parts[0]);
            uint m = uint.Parse(parts[1]);
            uint s = uint.Parse(parts[2]);
            uint seconds = (s + 60 * (m + 60 * h)) % (12 * 60 * 60);
            v.Add(seconds);
        }

        v.Sort();
        uint sum = 12 * 60 * 60 * n - (uint)v.Sum(x => (long)x);

        uint min = uint.MaxValue;
        uint mint = 0;
        uint prev = 0;

        for (int i = 0; i < v.Count; i++)
        {
            uint current = v[i];
            sum += n * (current - prev) - 12 * 60 * 60;
            if (sum < min)
            {
                min = sum;
                mint = current;
            }
            prev = current;
        }

        if (mint < 3600)
            mint += 3600 * 12;

        Console.WriteLine($"{mint / 3600}:{(mint / 60) % 60:D2}:{mint % 60:D2}");
    }
}
