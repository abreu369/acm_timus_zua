# Galaxpol - Bloqueio de Rotas dos Ladrões

## Introdução
A Galaxpol precisa interceptar um grupo de ladrões que planejam roubar um microprocessador valioso do Museu Planetário da Terra. O objetivo é bloquear todas as rotas entre o refúgio dos ladrões e o museu utilizando um número limitado de policiais.

## Descrição do Problema

O sistema de transporte interplanetário é representado como um grafo:
- Cada planeta possui uma estação de transporte.
- Algumas estações estão conectadas por canais de teletransporte bidirecionais.
- Algumas estações exigem diferentes quantidades de policiais para serem controladas.
- As estações do museu (S) e do refúgio dos ladrões (F) **não podem ser bloqueadas**.

Dado um número K de policiais, precisamos verificar se é possível bloquear todas as rotas entre S e F respeitando essa quantidade.

## Entrada
1. Um inteiro `K` (1 < K ≤ 10000) - número total de policiais.
2. Quatro inteiros `N M S F`:
   - `N` (3 ≤ N ≤ 100) - número de estações.
   - `M` (N-1 ≤ M ≤ N*(N-1)/2) - número de canais de teletransporte.
   - `S` (1 ≤ S ≤ N) - índice da estação do museu.
   - `F` (1 ≤ F ≤ N) - índice da estação do refúgio dos ladrões.
3. `N` inteiros representando a quantidade de policiais necessários para controlar cada estação.
4. `M` pares de inteiros representando os canais de teletransporte.

## Saída
- **"YES"** se for possível bloquear todas as rotas com K policiais.
- **"NO"** caso contrário.

## Algoritmo

1. **Representar o sistema de teletransporte como um grafo** usando uma lista de adjacência.
2. **Encontrar os caminhos possíveis entre F e S** usando busca em largura (BFS).
3. **Identificar as estações críticas** que devem ser bloqueadas para impedir a passagem.
4. **Calcular o número total de policiais necessários para bloquear essas estações**.
5. **Comparar com K** e determinar a resposta correta.

## Implementação em Python

```python
from collections import deque

def can_block_routes(K, N, M, S, F, police_needed, edges):
    # Criar a lista de adjacência
    graph = {i: [] for i in range(1, N + 1)}
    for u, v in edges:
        graph[u].append(v)
        graph[v].append(u)
    
    # Encontrar os nós críticos que pertencem a todos os caminhos entre S e F
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
def main():
    K = int(input().strip())
    N, M, S, F = map(int, input().split())
    police_needed = list(map(int, input().split()))
    edges = [tuple(map(int, input().split())) for _ in range(M)]
    
    result = can_block_routes(K, N, M, S, F, police_needed, edges)
    print(result)

if __name__ == "__main__":
    main()
```

## Complexidade
- **Construção do grafo:** \(O(M)\)
- **Busca BFS:** \(O(N + M)\)
- **Cálculo de policiais necessários:** \(O(N)\)
- **Complexidade total:** \(O(N + M)\), eficiente para os limites do problema.

## Exemplo de Entrada e Saída
### Entrada 1
```
10
5 5 1 5
1 6 6 11 1
1 2
1 3
2 4
3 4
4 5
```
### Saída 1
```
NO
```

### Entrada 2
```
10
5 5 1 5
1 4 4 11 1
1 2
1 3
2 4
3 4
4 5
```
### Saída 2
```
YES
```

## Conclusão
Este algoritmo verifica se é possível bloquear todas as rotas entre os ladrões e o museu usando BFS para determinar os caminhos e calculando a quantidade de policiais necessários. Se a quantidade for menor ou igual a K, então a resposta é "YES", caso contrário, "NO".

