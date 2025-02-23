def solve(N, data):
    # Mapeamento para o resultado
    result = [0] * N
    
    # Testar todas as combinações de veracidade das afirmações
    for mask in range(1 << N):
        # Inicializamos o vetor de cartões
        cards = [-1] * N
        valid = True
        
        # Verificar se as afirmações podem ser verdadeiras
        for i in range(N):
            a, b, c = data[i]
            b -= 1  # Corrigindo o índice para ser 0-based
            
            if (mask >> i) & 1:
                # Se a primeira afirmação é verdadeira para o amigo i
                if cards[i] != -1 and cards[i] != a:
                    valid = False
                    break
                cards[i] = a
                if b != i:
                    if cards[b] != -1 and cards[b] != c:
                        valid = False
                        break
                    cards[b] = c
            else:
                # Se a segunda afirmação é verdadeira para o amigo i
                if cards[i] != -1 and cards[i] != c:
                    valid = False
                    break
                cards[i] = c
                if b != i:
                    if cards[b] != -1 and cards[b] != a:
                        valid = False
                        break
                    cards[b] = a
        
        if valid:
            # Se for válido, registra o resultado
            for i in range(N):
                a, b, c = data[i]
                if (mask >> i) & 1:
                    result[i] = 1
                else:
                    result[i] = 2
            break
    
    return result

# Entrada padrão de exemplo
N = 5
data = [
    (3, 4, 3),
    (1, 3, 2),
    (3, 2, 5),
    (2, 5, 4),
    (3, 4, 1)
]

# Chamando a função
result = solve(N, data)

# Exibindo o resultado
print(" ".join(map(str, result)))
