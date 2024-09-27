using System.Drawing;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

class Program
{
    static void Window(int[] array, int size)
    {

    }
    static void Main(string[] args)
    {
        bool a = true;
        Random random = new Random();
        while (a)
        {
            Console.Clear();
            Console.WriteLine("1. Проверить правильность расстановки скобок\n2. Стек\n3. Поддержание max в оке\n4. Поиск повторяющегося числа\n5. Обнуление стобца и строки в матрице\n0. Выход");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    bool b = true;
                    while (b)
                    {
                        Console.Clear();
                        Console.WriteLine("Выберите условие:\n1. В строке содержатся только круглые скобки\n2. В строке содержатся любые скобки\n0. Выход в главное меню");
                        string chooseFirst = Console.ReadLine();
                        switch (chooseFirst)
                        {
                            case "1":        //О(n)
                                bool flag1 = true;
                                int flag3 = 0;
                                Console.Clear();
                                Console.WriteLine("Введите строку:");
                                string input1 = Console.ReadLine();
                                if (input1 != "")
                                {
                                    foreach (char c in input1)
                                    {
                                        if (c == '(')
                                            flag3++;
                                        if (c == ')' && flag3 == 0)
                                            flag1 = false;
                                        if (c == ')' && flag3 != 0)
                                            flag3--;
                                    }
                                    if (flag1 && flag3 == 0)
                                        Console.WriteLine("Проверка завершена. Скобки расставлены правильно");
                                    else
                                        Console.WriteLine("Проверка завершена. Скобки расставлены неправильно");
                                    b = false;
                                }
                                else
                                    Console.WriteLine("Введена пустая строка!");
                                break;
                            case "2":        //O(n)
                                bool flag2 = true;
                                int flag4 = 0;
                                int flagCircle = 0;
                                int flagFigure = 0;
                                int flagSquare = 0;
                                List<char> last = new List<char>();
                                Console.Clear();
                                Console.WriteLine("Введите строку:");
                                string input2 = Console.ReadLine();
                                if (input2 != "")
                                {
                                    foreach (char c in input2)
                                    {
                                        if (c == '(' ||  c == '[' || c == '{')
                                        {
                                            if (c == '(')
                                                flagCircle++;
                                            if(c == '[')
                                                flagSquare++;
                                            if(c == '{')
                                                flagFigure++;
                                            last.Add(c);
                                        }
                                        if (c == ')' || c == ']' || c == '}')
                                        {
                                            if (c == ')' && flagCircle != 0 && last.Last() == '(')
                                            {
                                                last.RemoveAt(last.Count - 1);
                                                flagCircle--;
                                            }
                                            else if (c == ']' && flagSquare != 0 && last.Last() == '[')
                                            {
                                                last.RemoveAt(last.Count - 1);
                                                flagSquare--;
                                            }
                                            else if (c == '}' && flagFigure != 0 && last.Last() == '{')
                                            {
                                                last.RemoveAt(last.Count - 1);
                                                flagFigure--;
                                            }
                                            else
                                                flag2 = false;
                                        }
                                            
                                    }
                                    if (flag2)
                                        Console.WriteLine("Проверка завершена. Скобки расставлены правильно");
                                    else
                                        Console.WriteLine("Проверка завершена. Скобки расставлены неправильно");
                                    b = false;
                                }
                                else
                                    Console.WriteLine("Введена пустая строка!");
                                break;
                            case "0":
                                b = false;
                                break;
                            default:
                                Console.WriteLine("Введено некорректное значение!");
                                break;
                        }
                        if (b)
                            Console.ReadLine();
                    }

                    break;
                case "2":
                    bool d = true;
                    Stack<int> stack = new Stack<int>();
                    List<int> list = new List<int>();
                    while (d)
                    {
                        Console.Clear();
                        Console.Write("Ваш текущий стэк: ");
                        foreach (int numbers in stack)
                            Console.Write(numbers + " ");
                        Console.WriteLine("\n");
                        Console.WriteLine("Выберите действие:\n1. Push\n2. Pop\n3. Min\n0. Выход");
                        string choose2 = Console.ReadLine();
                        switch (choose2)
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine("Введите элемент:");
                                int inputStack = Convert.ToInt32(Console.ReadLine());
                                stack.Push(inputStack);
                                list.Add(inputStack);
                                break;
                            case "2":
                                stack.Pop();
                                break;
                            case "3":
                                Console.Clear();
                                Console.WriteLine("Минимальное значение в стэке:");
                                Console.WriteLine(list.Min());
                                Console.ReadLine();
                                break;
                            case "0":
                                d = false;
                                break;
                            default:
                                Console.WriteLine("Введено некорректное значение!");
                                break;
                        }
                    }
                    break; 
                case "3":
                    Console.Clear();
                    Console.WriteLine("Введите размер массива:");
                    int size = Convert.ToInt32(Console.ReadLine());
                    int[] array = new int[size];
                    Console.Clear();
                    Console.WriteLine("Заполните массив:");
                    for (int i = 0; i < size; i++)
                    {
                        Console.WriteLine($"Введите элемент {i+1}/{size}");
                        array[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    bool checkLegit = false;
                    int window = 0;
                    while (checkLegit == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите размер окна:");
                        window = Convert.ToInt32(Console.ReadLine());
                        if (window > size)
                        {
                            Console.WriteLine("Размер окна не может быть больше размера массива, нажмите ENTER и введите ещё раз!");
                            Console.ReadLine();
                        }
                        else if (window < 1)
                        {
                            Console.WriteLine("Размер окна не может быть меньше 1, нажмите ENTER и введите ещё раз!");
                            Console.ReadLine();
                        }
                        else
                            checkLegit = true;
                    }
                    Console.Clear();
                    Console.WriteLine("Ваш массив:");
                    for ( int i = 0; i < size; i++)
                        Console.Write(array[i] + " ");
                    Console.WriteLine();
                    if (window == size)
                    {
                        Console.WriteLine("Максимальное значение в окне: " + array.Max());
                    }
                    else
                    {
                        LinkedList<int> windows = new LinkedList<int>(); // дек для отслеживания текущего окна
                        List<int> maxValues = new List<int>();

                        // Первоначальное заполнение дека первым окном
                        for (int i = 0; i < window; i++)
                        {
                            windows.AddLast(array[i]);
                        }
                        maxValues.Add(windows.Max()); // добавляем максимум первого окна
                        int flag2 = 0;
                        // Постепенное сдвигание окна и вывод максимумов
                        for (int i = window - 1; i < array.Length; i++)
                        {

                            windows.RemoveFirst(); // удаляем первый элемент окна
                            windows.AddLast(array[i]); // добавляем новый элемент в окно
                            if (flag2 != 0)
                            {
                                maxValues.Add(windows.Max());
                            }
                            flag2++;
                            Console.Clear();
                            Console.WriteLine("Массив: ");
                            for (int j = 0; j < array.Length; j++)
                            {
                                if (j >= i - window + 1 && j <= i)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                Console.Write(array[j] + " ");
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();

                            Console.Write("Максимумы в окнах: ");
                            foreach (int max in maxValues)
                            {
                                Console.Write(max + " ");
                            }
                            Console.WriteLine();

                            Thread.Sleep(1500); 
                        }
                    }
                    Console.WriteLine();
                    break;
                case "4":
                    Console.WriteLine("Введите длину массива:");
                    int count = int.Parse(Console.ReadLine());
                    int[] arr = new int[count];
                    Console.WriteLine("Исходный массив: ");
                    for (int i = 0; i < count; i++)
                    {
                        arr[i] = random.Next(1, count - 1);
                        Console.Write(arr[i] + " ");
                    }
                    Console.WriteLine("\nПовторяющиеся числа: ");
                    for (int i = 0; i < arr.Length; i++)//проходим по всему массиву
                    {
                        if (arr[Math.Abs(arr[i])] > 0)//если  значение элемента массива положительно, то переходим к другому элементу, 
                        {                                                     //индексом которого является это значение и умножаем на -1
                            arr[Math.Abs(arr[i])] *= -1;
                        }
                        else //если элемент уже отрицательный, то это дубликат
                        {
                            Console.Write(Math.Abs(arr[i]) + " ");
                        }
                    }
                    break;
                case "5":

                    Console.WriteLine("Введите кол-во строк в матрице: ");
                    int n = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите кол-во столбцов в матрице: ");
                    int m = int.Parse(Console.ReadLine());

                    int[,] matrix = new int[n, m];
                    Console.WriteLine("Исходная матрица: ");
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            matrix[i, j] = random.Next(-10, 10);
                            Console.Write("{0}\t", matrix[i, j]);
                        }
                        Console.Write("\n");
                    }

                    bool[] row = new bool[matrix.GetLength(0)];//храним, есть ли нули в строке
                    bool[] column = new bool[matrix.GetLength(1)];//храним, есть ли нули в столбце

                    //ищем нули в элементах матрицы и заполняем массивы
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j] == 0)
                            {
                                row[i] = true;
                                column[j] = true;
                            }
                        }
                    }

                    //зануляем строки и столбцы согласно заполненным массивам
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (row[i] || column[j])
                            {
                                matrix[i, j] = 0;
                            }
                        }
                    }
                    Console.WriteLine("Новая матрица: ");
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            Console.Write("{0}\t", matrix[i, j]);
                        }
                        Console.Write("\n");
                    }
                    break;
                case "0":
                    a = false;
                    break;
                default:
                    Console.WriteLine("Введено некорректное значение!");
                    break;
            }
            if (a)
                Console.ReadLine();
        }
    }
}