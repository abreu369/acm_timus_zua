using System;

class Program{
    
    static readonly string[] a = { "ni", "eno", "tuo", "tupni", "notup", "tuptuo" };
    static string s;
    static int ls;
    static int beg;

    static bool Cmp(){
        if (ls == 0) return true;

        foreach (var pattern in a){
            int al = pattern.Length;
            if (ls >= al){
                bool match = true;
                for (int j = 0; j < al; j++){
                    char chFromEnd = s[s.Length - beg - j - 1];
                    if (chFromEnd != pattern[j]){
                        match = false;
                        break;
                    }
                }

                if (match){
                    ls -= al;
                    beg += al;
                    return true;
                }
            }
        }
        return false;
    }

    static void Main(){
        if (!int.TryParse(Console.ReadLine(), out int n))
            return;

        for (int i = 0; i < n; i++){
            s = Console.ReadLine();
            ls = s.Length;
            beg = 0;

            while (ls != 0 && Cmp()) { }

            Console.WriteLine(ls == 0 ? "YES" : "NO");
        }
    }
}
