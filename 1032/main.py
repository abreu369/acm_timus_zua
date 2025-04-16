def main():
    A = [0] * 10500
    S = [0] * 10500

    n = int(input())
    s = 0
    S[0] = 0

    for i in range(n):
        A[i] = int(input())
        s += A[i]
        S[i + 1] = s

    for i in range(n + 1):
        for j in range(i):
            if (S[i] - S[j]) % n == 0:
                print(i - j)
                for k in range(j, i):
                    print(A[k], end=' ')
                print()
                return

    print(0)

if __name__ == "__main__":
    main()
