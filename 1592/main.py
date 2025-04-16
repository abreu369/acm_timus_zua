def main():
    n = int(input())
    v = []

    for _ in range(n):
        h, m, s = map(int, input().split(':'))
        v.append((s + 60 * (m + 60 * h)) % (12 * 60 * 60))

    v.sort()
    total_seconds = 12 * 60 * 60 * n - sum(v)

    min_time = float('inf')
    mint = 0
    prev = 0

    for i in range(n):
        current = v[i]
        total_seconds += n * (current - prev) - 12 * 60 * 60
        if total_seconds < min_time:
            min_time = total_seconds
            mint = current
        prev = current

    if mint < 3600:
        mint += 3600 * 12

    print(f"{mint // 3600}:{(mint // 60) % 60:02}:{mint % 60:02}")

if __name__ == "__main__":
    main()
