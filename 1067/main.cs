using System;
using System.Collections.Generic;

class Dir{
    public Dictionary<string, Dir> Subs = new Dictionary<string, Dir>();
}

class Program{
    
    static Dir[] dirs = new Dir[50001];
    static int p = 1;

    static Dir AddDir(Dir dir, string str)
    {
        if (!dir.Subs.ContainsKey(str))
            dir.Subs[str] = dirs[p++] = new Dir();
        return dir.Subs[str];
    }

    static void Print(Dir dir, int depth = 0)
    {
        foreach (var entry in dir.Subs)
        {
            Console.WriteLine(new string(' ', depth) + entry.Key);
            Print(entry.Value, depth + 1);
        }
    }

    static void Main()
    {
        for (int i = 0; i < dirs.Length; i++)
            dirs[i] = new Dir();

        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string path = Console.ReadLine();
            string[] parts = path.Split('\\');
            Dir dir = dirs[0];
            foreach (var part in parts)
                dir = AddDir(dir, part);
        }

        Print(dirs[0]);
    }
}
