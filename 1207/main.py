def find_balancing_line(points):
    n = len(points)  # Número de pontos
    for i in range(n):  # Iterar sobre o primeiro ponto
        for j in range(i + 1, n):  # Iterar sobre o segundo ponto (evitando repetição)
            a, b = points[i], points[j]  # Selecionamos os pontos que formam a reta
            left, right = 0, 0  # Contadores de pontos à esquerda e à direita
            
            for k in range(n):  # Percorrer todos os outros pontos
                if k == i or k == j:  # Ignorar os pontos usados para formar a reta
                    continue
                x_k, y_k = points[k]  # Coordenadas do ponto k
                x_a, y_a = a
                x_b, y_b = b
                
                # Cálculo do lado usando produto vetorial
                side = (x_b - x_a) * (y_k - y_a) - (y_b - y_a) * (x_k - x_a)
                
                if side > 0:  # Ponto à esquerda da reta
                    left += 1
                elif side < 0:  # Ponto à direita da reta
                    right += 1
            
            # Se metade dos pontos está em cada lado, achamos a resposta
            if left == right == (n // 2 - 1):
                return i + 1, j + 1  # Retorna os índices dos pontos (1-based)

# Entrada dos dados
n = int(input())  # Lê o número de pontos
points = [tuple(map(int, input().split())) for _ in range(n)]  # Lê as coordenadas

# Encontrar e imprimir os índices dos pontos que formam a reta de equilíbrio
i, j = find_balancing_line(points)
print(i, j)


