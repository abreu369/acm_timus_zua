using System;
using System.Collections.Generic;
using System.Linq;

class BigInt {
    private const int Base = 1000;
    private const int BaseWidth = 3;
    public List<int> v = new();

    public BigInt(int a = 0)
    {
        if (a != 0)
            v.Add(a);
    }

    public static BigInt operator +(BigInt a, BigInt b)
    {
        BigInt c = new();
        int carry = 0;
        int size = Math.Max(a.v.Count, b.v.Count);
        while (a.v.Count < size) a.v.Add(0);
        while (b.v.Count < size) b.v.Add(0);

        for (int i = 0; i < size; i++)
        {
            int sum = a.v[i] + b.v[i] + carry;
            c.v.Add(sum % Base);
            carry = sum / Base;
        }
        if (carry > 0)
            c.v.Add(carry);

        return c;
    }

    public static BigInt operator -(BigInt a, BigInt b)
    {
        BigInt c = new();
        int carry = 0;
        int size = Math.Max(a.v.Count, b.v.Count);
        while (a.v.Count < size) a.v.Add(0);
        while (b.v.Count < size) b.v.Add(0);

        for (int i = 0; i < size; i++)
        {
            int newcarry = 0;
            if (a.v[i] < b.v[i] + carry)
                newcarry = 1;

            c.v.Add(((Base + a.v[i]) - (b.v[i] + carry)) % Base);
            carry = newcarry;
        }

        while (c.v.Count > 0 && c.v[^1] == 0)
            c.v.RemoveAt(c.v.Count - 1);

        return c;
    }

    public static BigInt operator *(BigInt a, int t)
    {
        BigInt c = new();
        int carry = 0;

        for (int i = 0; i < a.v.Count; i++)
        {
            int mul = a.v[i] * t + carry;
            c.v.Add(mul % Base);
            carry = mul / Base;
        }

        if (carry > 0)
            c.v.Add(carry);

        return c;
    }

    public static BigInt operator *(int t, BigInt b) => b * t;

    public static BigInt operator /(BigInt a, int t)
    {
        BigInt c = new();
        int carry = 0;

        for (int i = a.v.Count - 1; i >= 0; i--)
        {
            int current = carry * Base + a.v[i];
            c.v.Add(current / t);
            carry = current % t;
        }

        c.v.Reverse();
        while (c.v.Count > 0 && c.v[^1] == 0)
            c.v.RemoveAt(c.v.Count - 1);

        return c;
    }

    public static bool operator ==(BigInt a, BigInt b)
    {
        return a.v.SequenceEqual(b.v);
    }

    public static bool operator !=(BigInt a, BigInt b) => !(a == b);

    public static bool operator <(BigInt a, BigInt b)
    {
        if (a.v.Count != b.v.Count)
            return a.v.Count < b.v.Count;

        for (int i = a.v.Count - 1; i >= 0; i--)
        {
            if (a.v[i] != b.v[i])
                return a.v[i] < b.v[i];
        }

        return false;
    }

    public static bool operator >(BigInt a, BigInt b) => b < a;

    public override bool Equals(object obj) => obj is BigInt other && this == other;
    public override int GetHashCode() => v.Aggregate(0, (a, b) => a ^ b);

    public string Str()
    {
        if (v.Count == 0)
            return "0";

        string ret = v[^1].ToString();
        for (int i = v.Count - 2; i >= 0; i--)
            ret += v[i].ToString().PadLeft(BaseWidth, '0');

        return ret;
    }
}

class Program
{
    static BigInt[,,] C = new BigInt[31, 31, 31];
    static bool[,,] calced = new bool[31, 31, 31];

    static BigInt A(int i, int j, int k)
    {
        if (i == 0 && j == 0 && k == 0)
            return new BigInt(1);
        if (i < 0)
            return new BigInt(0);

        if (!calced[i, j, k])
        {
            C[i, j, k] = j * A(j - 1, Math.Min(i, k), Math.Max(i, k))
                      + k * A(k - 1, Math.Min(i, j), Math.Max(i, j));
            calced[i, j, k] = true;
        }

        return C[i, j, k];
    }

    static BigInt B(int i, int j, int k)
    {
        if (i < 0)
            return new BigInt(0);

        return A(i, Math.Min(j, k), Math.Max(j, k)) - (i * B(i - 1, j, k));
    }

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine((B(N - 1, N, N) / 2).Str());
    }
}
