using System;
using System.Collections.Generic;

class Program{
    static int N;

    struct Statement{
        public int a, b, c;
    }

    static Statement[] A = new Statement[1000];

    class Node{
        public List<int> v = new();
        public bool b, t;
    }

    static Node[] nodes = new Node[4000];

    static bool _dfs(int i, int e){
        // From node i seeks until it encounters node e (which leads to a contradiction)
        if (i == e || nodes[i ^ 1].t) // If e is reached, or the inverse of this node is true, fail
            return true;
        if (nodes[i].b) // Already visited
            return false;
        nodes[i].b = true;

        foreach (int u in nodes[i].v)
            if (_dfs(u, e))
                return true;

        return false;
    }

    static bool dfs(int i, int e){
        // Cleans the 'visited' info and does dfs
        for (int k = 0; k < N * 4; k++)
            nodes[k].b = false;
        return _dfs(i, e);
    }

    static void dfs2(int i){
        if (nodes[i].t)
            return;
        nodes[i].t = true;
        foreach (int u in nodes[i].v)
            dfs2(u);
    }

    static void add(int i, int a, int j, int b){
        nodes[i * 4 + a].v.Add(j * 4 + b);
    }

    static void Main(){
        string input = Console.ReadLine();
        N = int.Parse(input);

        for (int i = 0; i < nodes.Length; i++)
            nodes[i] = new Node();

        for (int i = 0; i < N; i++){
            string[] parts = Console.ReadLine().Split();
            A[i].a = int.Parse(parts[0]);
            A[i].b = int.Parse(parts[1]);
            A[i].c = int.Parse(parts[2]);
        }

        for (int i = 0; i < N; i++){
            // Internal implications of each statement
            add(i, 0, i, 3);
            add(i, 1, i, 2);
            add(i, 2, i, 1);
            add(i, 3, i, 0);

            for (int j = 0; j < N; j++){
                if (i == j) continue;

                if (A[j].a == A[i].a)
                    add(i, 0, j, 1);
                if (A[j].c == A[i].a)
                {
                    add(i, 0, j, 3);
                    add(j, 2, i, 1);
                }
                if (A[j].c == A[i].c)
                    add(i, 2, j, 3);
                if (A[j].b == i + 1)
                {
                    add(i, 0, j, 3);
                    add(j, 2, i, 1);
                }
            }
        }

        for (int i = 0; i < N; i++)
            if (!dfs(i * 4, i * 4 + 1))
                dfs2(i * 4);

        for (int i = 0; i < N; i++)
            Console.Write((nodes[i * 4].t ? 1 : 2) + " ");
    }
}
