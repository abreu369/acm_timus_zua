from collections import defaultdict

def find_werewolf_suspects(n, relationships, victims):
    ancestors = defaultdict(set)
    children = defaultdict(set)
    
    # Строим дерево родственных связей
    for child, parent in relationships:
        children[parent].add(child)
        ancestors[child].add(parent)
        ancestors[child].update(ancestors[parent])
    
    # Находим всех предков жертв
    victim_ancestors = set()
    for victim in victims:
        victim_ancestors.update(ancestors[victim])
    
    # Определяем подозреваемых: тех, кто не является предком жертв
    suspects = set(range(1, n + 1)) - victim_ancestors - set(victims)
    
    print(" ".join(map(str, sorted(suspects))) if suspects else "0")

# Чтение входных данных
n = int(input().strip())
relationships = []
while True:
    line = input().strip()
    if line == "BLOOD":
        break
    relationships.append(tuple(map(int, line.split())))

victims = set()
while True:
    try:
        line = input().strip()
        if not line:
            break
        victims.add(int(line))
    except EOFError:
        break

find_werewolf_suspects(n, relationships, victims)
