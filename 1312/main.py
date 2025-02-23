import math

def is_valid_placement(H, W, r1, r2, r3, x1, y1, x2, y2, x3, y3):
    # Проверяем, что все тарелки помещаются на поднос
    if not (r1 <= x1 <= W - r1 and r1 <= y1 <= H - r1):
        return False
    if not (r2 <= x2 <= W - r2 and r2 <= y2 <= H - r2):
        return False
    if not (r3 <= x3 <= W - r3 and r3 <= y3 <= H - r3):
        return False
    
    # Проверяем, что тарелки не пересекаются
    def dist(xa, ya, xb, yb):
        return math.sqrt((xa - xb)**2 + (ya - yb)**2)
    
    if dist(x1, y1, x2, y2) < r1 + r2:
        return False
    if dist(x1, y1, x3, y3) < r1 + r3:
        return False
    if dist(x2, y2, x3, y3) < r2 + r3:
        return False
    
    return True

def solve(H, W, r1, r2, r3):
    # Попробуем простое размещение: разместим тарелки по краям.
    for x1 in range(r1, W - r1 + 1):
        for y1 in range(r1, H - r1 + 1):
            for x2 in range(r2, W - r2 + 1):
                for y2 in range(r2, H - r2 + 1):
                    for x3 in range(r3, W - r3 + 1):
                        for y3 in range(r3, H - r3 + 1):
                            if is_valid_placement(H, W, r1, r2, r3, x1, y1, x2, y2, x3, y3):
                                # Если найдено валидное размещение
                                return f"{x1:.4f} {y1:.4f} {x2:.4f} {y2:.4f} {x3:.4f} {y3:.4f}"
    
    # Если решение не найдено
    return "0"

# Ввод данных
H, W = 800, 400
r1, r2, r3 = 200, 200, 50

# Вывод решения
print(solve(H, W, r1, r2, r3))
