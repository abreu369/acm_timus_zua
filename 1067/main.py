class Dir:
    def __init__(self):
        self.subs = {}

dirs = [Dir() for _ in range(50001)]
p = 1

def add_dir(dir, name):
    global p
    if name not in dir.subs:
        dir.subs[name] = dirs[p]
        p += 1
    return dir.subs[name]

def print_dirs(dir, depth=0):
    for name in sorted(dir.subs):
        print(' ' * depth + name)
        print_dirs(dir.subs[name], depth + 1)

def main():
    N = int(input())
    for _ in range(N):
        path = input()
        parts = path.split('\\')
        dir = dirs[0]
        for part in parts:
            dir = add_dir(dir, part)

    print_dirs(dirs[0])

if __name__ == '__main__':
    main()
