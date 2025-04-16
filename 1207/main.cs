using System;
using System.Collections.Generic;

class Program
{
    static bool Check(List<(int x, int y)> p, int i)
    {
        long dx = p[i].x - p[0].x;
        long dy = p[i].y - p[0].y;

        uint k = 0;
        foreach (var point in p)
        {
            long cp = dx * (point.y - p[0].y) - dy * (point.x - p[0].x);
            if (cp < 0)
                k++;
        }

        return 2 * k == p.Count - 2;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine()!);
        var p = new List<(int x, int y)>(n);

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine()!.Split();
            int x = int.Parse(tokens[0]);
            int y = int.Parse(tokens[1]);
            p.Add((x, y));
        }

        int iIndex = 1;
        while (iIndex < n && !Check(p, iIndex))
            iIndex++;

        Console.WriteLine($"1 {1 + iIndex}");
    }
}
