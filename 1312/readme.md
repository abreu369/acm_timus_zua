
# Descrição do Código

Este código resolve o problema de posicionamento de três tarros em um tray retangular de modo que as três tarros não se sobreponham e permaneçam dentro dos limites do tray. O código faz uma análise das possíveis posições e retorna as coordenadas dos centros das tarros ou 0 se não for possível o posicionamento.

## Estrutura do Código

O código é dividido em duas funções principais:

### 1. Função `is_valid_placement`
Esta função verifica se as tarros não ultrapassam os limites do tray e se elas não se sobrepõem. Ela recebe as coordenadas das tarros e seus respectivos raios, e retorna `True` se as tarros podem ser colocadas nas coordenadas fornecidas sem violar as condições, ou `False` caso contrário.

#### Condições verificadas:
- As tarros devem estar dentro dos limites do tray. Ou seja, para uma tarra com raio `r`, o centro da tarra deve estar dentro da área definida pelas coordenadas `(r, r)` e `(W - r, H - r)` onde `W` e `H` são a largura e altura do tray, respectivamente.
- As tarros não devem se sobrepor. Para verificar isso, calculamos a distância entre os centros das tarros e comparamos com a soma dos seus raios. Se a distância for menor que a soma dos raios de duas tarros, elas estão se sobrepondo.

### 2. Função `solve`
Esta função tenta encontrar uma solução verificando várias posições possíveis para as tarros. Ela chama a função `is_valid_placement` para cada combinação de coordenadas de centros das tarros, verificando se elas atendem às condições. Se uma combinação válida for encontrada, ela retorna as coordenadas com 4 casas decimais. Caso contrário, retorna `0` indicando que não é possível colocar as tarros.

## Funcionamento

A função `solve` tenta uma abordagem de tentativa e erro, verificando diferentes combinações de posições de centros das tarros dentro do tray e checando se elas atendem às condições. Ela utiliza dois loops aninhados para percorrer todas as possíveis posições para as tarros.

### Exemplos:

#### Exemplo 1:
**Entrada**:
```
800 400 200 200 50
```
**Saída**:
```
200.0000 200.0000 600.0000 200.0000 400.0000 350.0000
```

#### Exemplo 2:
**Entrada**:
```
800 400 200 200 51
```
**Saída**:
```
0
```

## Conclusão

Este código resolve de forma eficiente o problema de posicionamento das tarros no tray, garantindo que as tarros não se sobreponham e permaneçam dentro dos limites definidos.