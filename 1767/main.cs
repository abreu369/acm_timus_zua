using System;
using System.Linq;

class Program{
    static uint Solve((int, int)[] p)
    {
        var q = new (int, int)[4]
        {
            (Math.Min(p[0].Item1, p[1].Item1), Math.Min(p[0].Item2, p[1].Item2)),
            (Math.Max(p[0].Item1, p[1].Item1), Math.Max(p[0].Item2, p[1].Item2)),
            (Math.Min(p[2].Item1, p[3].Item1), Math.Min(p[2].Item2, p[3].Item2)),
            (Math.Max(p[2].Item1, p[3].Item1), Math.Max(p[2].Item2, p[3].Item2))
        };

        int Intersection(int s1, int t1, int s2, int t2)
        {
            return s1 < t1
                ? Math.Min(Math.Min(s2 - t1, t2 - t1), s2 - s1)
                : Math.Min(Math.Min(t2 - s1, s2 - s1), t2 - t1);
        }

        int d1 = Intersection(q[0].Item1, q[2].Item1, q[1].Item1, q[3].Item1);
        if (d1 < 0)
            return 0;

        int d2 = Intersection(q[0].Item2, q[2].Item2, q[1].Item2, q[3].Item2);
        if (d2 < 0)
            return 0;

        long dx1 = p[1].Item1 - p[0].Item1;
        long dy1 = p[1].Item2 - p[0].Item2;
        long dx2 = p[3].Item1 - p[2].Item1;
        long dy2 = p[3].Item2 - p[2].Item2;

        return (dx1 * dx2 ^ dy1 * dy2) < 0 ? (uint)Math.Max(d1, d2) : (uint)(d1 + d2);
    }

    static void Main()
    {
        var p = new (int, int)[4];

        for (int i = 0; i < 4; i++)
        {
            var input = Console.ReadLine()?.Split();
            if (input == null || input.Length < 2)
                throw new ArgumentException("Input Invalid.");

            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);
            p[i] = (x, y);
        }

        Console.WriteLine(Solve(p));
    }
}
