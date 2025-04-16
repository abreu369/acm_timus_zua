using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Filter(List<List<int>> graph, int x, bool[] visited)
    {
        visited[x] = true;

        foreach (var y in graph[x])
        {
            if (!visited[y])
                Filter(graph, y, visited);
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine()!);
        var a = new List<List<int>>(new List<int>[n]);
        var s = new List<List<int>>(new List<int>[n]);

        for (int i = 0; i < n; i++)
        {
            a[i] = new List<int>();
            s[i] = new List<int>();
        }

        string? line;
        while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()) && line != "BLOOD")
        {
            int spaceIndex = line.IndexOf(' ');
            int c = int.Parse(line[..spaceIndex]) - 1;
            int p = int.Parse(line[(spaceIndex + 1)..]) - 1;

            a[c].Add(p);
            s[p].Add(c);
        }

        var visited = new bool[n];
        string? input;
        while (!string.IsNullOrWhiteSpace(input = Console.ReadLine()))
        {
            if (int.TryParse(input, out int x))
            {
                Filter(a, x - 1, visited);
                Filter(s, x - 1, visited);
            }
        }

        var r = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
                r.Add(i);
        }

        r.Sort();

        if (r.Count > 0)
        {
            foreach (var x in r)
                Console.Write($"{x + 1} ");
        }
        else
        {
            Console.WriteLine("0");
        }
    }
}
