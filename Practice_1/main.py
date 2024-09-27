from random import randint
import random
import time

def quicksort(arr):
    if len(arr) <= 1:
        return arr
    q = random.choice(arr)
    s_arr = []
    m_arr = []
    e_arr = []
    for n in arr:
        if n < q:
            s_arr.append(n)
        elif n > q:
            m_arr.append(n)
        else:
            e_arr.append(n)
    return quicksort(s_arr) + e_arr + quicksort(m_arr)

def Bubble_Sort(arr):
    for i in range(len(arr) - 1):
        for j in range(len(arr) - i - 1):
            if arr[j] > arr[j + 1]:
                arr[j], arr[j + 1] = arr[j + 1], arr[j]
    return arr

arr = []
for i in range(randint(1000,10000)):
    arr.append(randint(0,1000))
arr2 = arr.copy()
t0_bubble = time.time()
sorted_arr1 = Bubble_Sort(arr)
t1_bubble = time.time()
res_for_bubble = t1_bubble - t0_bubble
print("Время работы сортировки Пузырьком:", res_for_bubble)
print(sorted_arr1)
print("Длина массива:", len(arr))

t0_quicksort = time.time()
sorted_arr2 = quicksort(arr2)
t1_quicksort = time.time()
res_for_quicksort = t1_quicksort - t0_quicksort
print("Время работы быстрой сортировки:", res_for_quicksort)
print(sorted_arr2)
