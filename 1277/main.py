
def can_block_routes(K, N, M, S, F, police_needed, edges):
    from collections import deque
    
    # Criar a lista de adjacência
    graph = {i: [] for i in range(1, N + 1)}
    for u, v in edges:
        graph[u].append(v)
        graph[v].append(u)

    # Encontrar os nós que pertencem a todos os caminhos entre S e F
    def bfs(start, avoid):
        queue = deque([start])
        visited = set([start])
        parents = {start: None}

        while queue:
            node = queue.popleft()
            for neighbor in graph[node]:
                if neighbor not in visited and neighbor not in avoid:
                    visited.add(neighbor)
                    queue.append(neighbor)
                    parents[neighbor] = node
                    if neighbor == S:
                        return parents
        return None

    # Executar BFS a partir do refúgio dos ladrões
    avoid_set = {S, F}
    path_nodes = set()
    
    parents = bfs(F, avoid_set)
    if not parents:
        return "NO"

    # Reconstruir caminho de F para S
    node = S
    while node is not None:
        path_nodes.add(node)
        node = parents[node]

    # Remover S e F, pois não podem ser bloqueados
    path_nodes.discard(S)
    path_nodes.discard(F)

    # Verificar se temos policiais suficientes
    total_police_needed = sum(police_needed[node - 1] for node in path_nodes)
    return "YES" if total_police_needed <= K else "NO"

# Ler entrada
K = int(input().strip())
N, M, S, F = map(int, input().split())
police_needed = list(map(int, input().split()))
edges = [tuple(map(int, input().split())) for _ in range(M)]

# Resolver o problema
result = can_block_routes(K, N, M, S, F, police_needed, edges)
print(result)
