from collections import deque

class Vertex:
    def __init__(self, n=0):
        self.out = []
        self.n = n

def explore(u, ans):
    ans.append(u)
    q = deque()
    v = u
    while v.out:
        w = v.out.pop()
        v = w
        q.append(v)
    while q:
        explore(q.popleft(), ans)

def main():
    v = [Vertex(i) for i in range(10001)]
    
    n = int(input())
    last = tot = 0
    
    for _ in range(n):
        m_and_rest = list(map(int, input().split()))
        m = m_and_rest[0]
        last = m_and_rest[1]
        for u in m_and_rest[2:]:
            v[u].n = u
            v[last].out.append(v[u])
            last = u

    ans = []
    explore(v[last], ans)
    print(len(ans) - 1, end=' ')
    for vertex in ans:
        print(vertex.n, end=' ')

if __name__ == "__main__":
    main()
