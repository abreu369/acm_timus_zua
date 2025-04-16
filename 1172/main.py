from functools import lru_cache

BASE = 1000
BASE_WIDTH = 3

class BigInt:
    def __init__(self, value=0):
        self.v = []
        if value != 0:
            while value > 0:
                self.v.append(value % BASE)
                value //= BASE

    def __add__(self, other):
        res = BigInt()
        carry = 0
        maxlen = max(len(self.v), len(other.v))
        for i in range(maxlen):
            a = self.v[i] if i < len(self.v) else 0
            b = other.v[i] if i < len(other.v) else 0
            s = a + b + carry
            res.v.append(s % BASE)
            carry = s // BASE
        if carry:
            res.v.append(carry)
        return res

    def __sub__(self, other):
        res = BigInt()
        carry = 0
        for i in range(len(self.v)):
            a = self.v[i]
            b = other.v[i] if i < len(other.v) else 0
            diff = a - b - carry
            if diff < 0:
                diff += BASE
                carry = 1
            else:
                carry = 0
            res.v.append(diff)
        while res.v and res.v[-1] == 0:
            res.v.pop()
        return res

    def __mul__(self, other):
        if isinstance(other, int):
            res = BigInt()
            carry = 0
            for i in range(len(self.v)):
                m = self.v[i] * other + carry
                res.v.append(m % BASE)
                carry = m // BASE
            if carry:
                res.v.append(carry)
            return res
        raise NotImplementedError

    def __rmul__(self, other):
        return self * other

    def __floordiv__(self, other):
        if isinstance(other, int):
            res = BigInt()
            carry = 0
            for i in reversed(range(len(self.v))):
                cur = carry * BASE + self.v[i]
                res.v.insert(0, cur // other)
                carry = cur % other
            while res.v and res.v[-1] == 0:
                res.v.pop()
            return res
        raise NotImplementedError

    def __eq__(self, other):
        return self.v == other.v

    def __lt__(self, other):
        if len(self.v) != len(other.v):
            return len(self.v) < len(other.v)
        for i in reversed(range(len(self.v))):
            if self.v[i] != other.v[i]:
                return self.v[i] < other.v[i]
        return False

    def __str__(self):
        if not self.v:
            return "0"
        parts = [str(self.v[-1])]
        for x in reversed(self.v[:-1]):
            parts.append(f'{x:0{BASE_WIDTH}}')
        return ''.join(parts)

@lru_cache(maxsize=None)
def A(i, j, k):
    if i == 0 and j == 0 and k == 0:
        return BigInt(1)
    if i < 0:
        return BigInt(0)
    return j * A(j - 1, min(i, k), max(i, k)) + k * A(k - 1, min(i, j), max(i, j))

@lru_cache(maxsize=None)
def B(i, j, k):
    if i < 0:
        return BigInt(0)
    return A(i, min(j, k), max(j, k)) - (i * B(i - 1, j, k))

def main():
    N = int(input())
    result = B(N - 1, N, N) // 2
    print(result)

if __name__ == "__main__":
    main()
