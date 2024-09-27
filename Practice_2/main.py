import time

def fibonacci(n):
    if (n <= 1):
        return n
    else:
        return (fibonacci(n-1) + fibonacci(n-2))
n = int(input("Введите число членов последовательности: ")) #Лучше вводить меньше 35
print("Последовательность Фибоначчи:")
t0_def = time.time()
for i in range(n):
    print(fibonacci(i+1), end = " ") # +1 Для того, чтобы не выводился 0
t1_def = time.time()
res_for_def = t1_def - t0_def
print("\nВремя работы с использованием рекурсии: ", res_for_def, "\n")

fib1 = fib2 = 1
t0_it = time.time()
print(fib1, fib2, end=' ')
for i in range(2, n):
    fib1, fib2 = fib2, fib1 + fib2
    print(fib2, end=' ')
t1_it = time.time()
res_for_def = t1_it - t0_it
print("\nВремя работы с использованием итерации: ", res_for_def, "\n")
