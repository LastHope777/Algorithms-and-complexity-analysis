# Лабораторная работа 1  
1. Разбейте связный список вокруг некоторого значения так, чтобы все меньшие узлы 
оказались перед узлами, большими или равными этому значению.  
2. Найдите в односвязном списке k-ый с конца элемент. Список реализован «вручную», есть 
только операция получения следующего элемента и указатель на первый элемент. 
Алгоритм должен быть оптимален по времени и памяти.  
3. Есть однонаправленный список из структур. В нём random указывает на какой-то элемент 
этого же списка. Напишите функцию, которая копирует этот список с сохранением 
структуры (т.е. если в старом списке random первой ноды указывал на 4-ю, в новом списке 
должно быть то же самое – рандом первой ноды указывает на 4-ю ноду нового списка). 
Сложность алгоритма должна быть O(n), константная дополнительная память плюс память 
под элементы нового списка. Выделение памяти под все данные одним блоком (как под 
массив) не допускается, список должен быть разбросанным по частям.  
# Лабораторная работа 2  
1. Дана строка со скобками. Проверьте правильность расстановки скобок за время О(n).  
а) в строке содержатся только круглые скобки;  
б) скобки могут быть любые.  
2. Реализуйте «вручную» стек со стандартными функциями push/pop и дополнительной 
функцией min, возвращающей минимальный элемент стека. Все эти функции должны 
работать за O(1). Память должна быть оптимальна.  
3. Задача «Поддержания max в окне». Дан массив размером n и счетчик k, определяющий 
размер окна в массиве. Окно двигается от начала до конца массива. Необходимо найти 
максимум в окне и напечатать все их значения. Время работы алгоритма должно быть 
О(n) и не зависеть от k.   
4. Дан массив размера n+1. Элементы массива числа из множества {1, 2, 3 … n}. Найдите 
повторяющееся число за время О(n), не используя дополнительной памяти. 
Повторяющихся элементов может быть несколько.  
5. Обнулите столбец N и строку M матрицы, если элемент в ячейке (N, M) нулевой. Затраты 
памяти и времени работы должны быть минимизированы.  
# Лабораторная работа 3  
1. Реализуйте наивный алгоритм и алгоритм Кнута-Морриса-Пратта для поиска подстроки в 
строке. Сравните эффективность алгоритмов на различных входных данных.  
2. Реализуйте алгоритм, который находит все палиндромные подстроки в данной строке.  
3. Реализуйте алгоритм кодирования Хаффмана для сжатия текстовых данных.  
4. Реализуйте алгоритм для определения циклов в графе.  
# Практическая работа 1  
Написать два алгоритма:  
Пузырьковая сортировка и быстрая сортировка (quicksort).
# Практическая работа 2  
Найдите первые N чисел Фибоначчи двумя способами: с помощью рекурсии и с помощью 
итерации. Сравните эффективность алгоритмов.  
# Практическая работа 3  
Написать реализацию алгоритма оптимального заполнения рюкзака.  
