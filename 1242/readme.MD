# Explicação do Código "Werewolf Suspects"

## Visão Geral
Este código tem o objetivo de identificar possíveis suspeitos de serem um lobisomem com base em informações de parentesco e uma lista de vítimas. O código processa uma lista de relacionamentos entre pais e filhos, identifica os ancestrais das vítimas e determina quais habitantes não podem ser lobisomens.

## Estrutura do Código

1. **Leitura da entrada**
   - O código começa lendo o número total de habitantes da vila.
   - Em seguida, ele processa os relacionamentos entre pais e filhos até encontrar a palavra "BLOOD".
   - Após "BLOOD", o código lê os números das vítimas.

2. **Construção das estruturas de dados**
   - O código usa dois dicionários:
     - `ancestors`: Para armazenar todos os ancestrais diretos e indiretos de cada habitante.
     - `children`: Para armazenar os filhos de cada habitante.
   
   - Conforme os relacionamentos são lidos, os ancestrais são registrados de forma transitiva, garantindo que todos os ancestrais de um ancestral também sejam armazenados corretamente.

3. **Identificação de suspeitos**
   - O código identifica todos os ancestrais das vítimas.
   - Os suspeitos são aqueles que **não** são ancestrais de qualquer vítima e **não** estão na lista de vítimas.

4. **Saída de resultados**
   - Se houver suspeitos, eles são impressos em ordem crescente.
   - Caso contrário, o código imprime "0".

## Exemplo de Entrada e Saída
### Entrada
```
8
1 3
3 6
4 5
6 2
4 6
8 1
BLOOD
3
8
```
### Saída
```
4 5 7
```

## Complexidade
A complexidade do algoritmo é aproximadamente **O(N²)** no pior caso, pois cada nó pode propagar sua ancestralidade para múltiplos descendentes.

## Possíveis Melhorias
- Utilizar busca em largura (BFS) para otimizar a construção da árvore genealógica.
- Usar um conjunto para evitar recalcular ancestrais repetidamente.
