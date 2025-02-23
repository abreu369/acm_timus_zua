# Explicação do Código

Este documento explica o funcionamento do código que encontra duas pontos em um conjunto de N pontos no plano, de forma que a reta que passa por elas divide os outros pontos exatamente ao meio.

## Passo a Passo da Solução

1. **Leitura dos dados**  
   - O programa lê um número inteiro \( N \), que representa a quantidade de pontos.
   - Em seguida, lê as coordenadas \( (x, y) \) de cada ponto e as armazena em uma lista de tuplas.

2. **Iteração sobre todas as possíveis retas**  
   - Para encontrar uma reta que divide o conjunto ao meio, testamos todas as possíveis retas formadas por pares de pontos.
   - Utilizamos dois laços `for` para gerar todas as combinações \( (i, j) \) de pontos.

3. **Verificação da divisão do conjunto**  
   - Para cada par de pontos \( A \) e \( B \), contamos quantos pontos estão à esquerda e à direita da reta.
   - Utilizamos o **produto vetorial** para determinar a posição relativa de um ponto \( P \) em relação à reta \( AB \):

     ```
     side = (x_B - x_A) * (y_P - y_A) - (y_B - y_A) * (x_P - x_A)
     ```

     - Se `side > 0`, \( P \) está à esquerda da reta.
     - Se `side < 0`, \( P \) está à direita.
     - Se `side == 0`, \( P \) está sobre a reta (o que não ocorre, pois o problema garante que não há três pontos colineares).

4. **Condição para a resposta**  
   - Se metade das \( N - 2 \) outras pontos está de um lado e metade do outro, encontramos a resposta.
   - Retornamos os índices das duas pontos formadoras da reta.

## Código Python

```python
def find_balancing_line(points):
    n = len(points)  # Número de pontos
    for i in range(n):  # Iterar sobre o primeiro ponto
        for j in range(i + 1, n):  # Iterar sobre o segundo ponto
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
```

## Exemplo de Execução

### Entrada
```
4
0 0
1 0
0 1
1 1
```

### Passo a Passo
1. Testamos todas as retas possíveis entre pares de pontos.
2. Para a reta formada pelos pontos `(0,0)` e `(1,1)`, vemos que:
   - `(1,0)` e `(0,1)` estão em lados opostos.
   - Como há \( \frac{4}{2} = 2 \) pontos em cada lado, essa reta é válida.
3. O programa retorna `1 4`, pois os índices no problema começam de 1.

### Saída
```
1 4
```

## Complexidade
O código percorre todas as \( O(N^2) \) combinações de pares de pontos e, para cada uma, verifica os outros \( O(N) \) pontos. Isso resulta em uma complexidade \( O(N^3) \), que é eficiente para \( N \leq 10.000 \).

Este algoritmo garante encontrar uma reta que divide os pontos igualmente, conforme exigido no problema. 🚀

