using System;
using System.Collections.Generic;
namespace structure_lab1
{
    public class Node
    {
        public int MyItems;
        public Node Next;
        public Node(int item)
        {
            MyItems = item;
            Next = null;
        }
    }


    class Program
    {
        public static Node GetRandomNode(Node head, Random random, int length)
        {
            Node current = head;
            // Выбор случайного узла
            int randomIndex = random.Next(length);
            current = head;
            for (int i = 0; i < randomIndex; i++)
            {
                if (current.Next != null)
                    current = current.Next;
                else break;
            }

            return current;
        }
        // Метод для печати элементов списка
        public static void PrintList(Node head)
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.MyItems);
                current = current.Next;
            }
        }

        // Метод для копирования списка с сохранением последовательности узлов
        public static Node CopyList(Node head)
        {
            if (head == null)
            {
                return null;
            }

            Dictionary<Node, Node> originalToCopyMap = new Dictionary<Node, Node>();
            Node current = head;
            Node copiedHead = new Node(head.MyItems);
            Node copiedCurrent = copiedHead;

            // Создаем копии узлов и устанавливаем связи между ними
            while (current != null)
            {
                originalToCopyMap.Add(current, copiedCurrent);
                if (current.Next != null)
                {
                    copiedCurrent.Next = new Node(current.Next.MyItems);
                }
                current = current.Next;
                copiedCurrent = copiedCurrent.Next;
            }

            // Устанавливаем связи в скопированном списке
            current = head;
            copiedCurrent = copiedHead;
            while (current != null)
            {
                if (current.Next != null)
                {
                    copiedCurrent.Next = originalToCopyMap[current.Next];
                }
                current = current.Next;
                copiedCurrent = copiedCurrent.Next;
            }

            return copiedHead;
        }
    
    static void Main(string[] args)
        {

            LinkedList<int> list = new LinkedList<int>();
            bool a = true;
            while (a)
            {
                Console.Clear();
                Console.Write("1. ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Добавить ");
                Console.ResetColor();
                Console.WriteLine("элемент в список;");
                Console.WriteLine("2. Показать список;");
                Console.Write("3. ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Удалить ");
                Console.ResetColor();
                Console.WriteLine("элемент из списка;");
                Console.WriteLine("4. Сортировка относительно рандомного числа");
                Console.WriteLine("5. Нахождение k-ого с конца элемента");
                Console.WriteLine("6. Клонирование нового списка");
                Console.WriteLine("0. Выход.");
                string choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Введите элемент:");
                        list.AddLast(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "2":
                        Console.Clear();
                        foreach (int i in list)
                        {
                            Console.WriteLine(i);
                        }
                        if (list.Count == 0)
                            Console.WriteLine("Список пуст");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine($"Введите номер элемента, начиная с 0 (Последний элемент: {list.Count -1}):");
                        int index = 0;
                        int number = Convert.ToInt32(Console.ReadLine());
                        var currentNode = list.First;
                        if (number >=0 && number < list.Count)
                        {
                            while (currentNode != null)
                            {
                                Console.WriteLine(currentNode.Value);
                                if (index == number)
                                {
                                    list.Remove(currentNode);
                                }
                                currentNode = currentNode.Next;
                                index++;
                            }
                        }
                        else
                            Console.WriteLine("Введён некорректный номер!");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Random rnd = new Random();
                        var pivot = rnd.Next(1, 100);
                        LinkedList<int> smallerList = new LinkedList<int>();
                        LinkedList<int> greaterOrEqualList = new LinkedList<int>();
                        Console.WriteLine($"Рандомное число: {pivot}");
                        var currentNode2 = list.First;
                        while (currentNode2 != null)
                        {
                            if (currentNode2.Value < pivot)
                            {
                                smallerList.AddLast(currentNode2.Value);
                            }
                            else
                            {
                                greaterOrEqualList.AddLast(currentNode2.Value);
                            }
                            currentNode2 = currentNode2.Next;
                        }


                        list.Clear();
                        foreach (int value in smallerList)
                        {
                            list.AddLast(value);
                        }
                        foreach (int value in greaterOrEqualList)
                        {
                            list.AddLast(value);
                        }
                        Console.WriteLine("Список отсортирован!");                        
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Введите номер элемента с конца (индексация начинается с 0):");
                        int k = Convert.ToInt32(Console.ReadLine());
                        var currentNode3 = list.First;
                        int CountOfElements = list.Count;
                        int c = 0;
                        while (currentNode3 != null)
                        {
                            
                            if (c == CountOfElements - k - 1)
                            {
                                Console.WriteLine($"Искомый элемент: {currentNode3.Value}");
                            }
                            currentNode3 = currentNode3.Next;
                            c++;
                        }
                        Console.ReadLine();
                        break;
                    case "6": 
                        Console.Clear();
                        Node head = null;
                        Node current = null;
                        Random rand = new Random();
                        Console.WriteLine("Введите количество элементов списка:");
                        int count;
                        while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
                        {
                            Console.WriteLine("Пожалуйста, введите положительное целое число.");
                        }
                        Console.WriteLine("Заполнение списка:");
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"Введите элемент {i + 1}:");
                            int input;
                            while (!int.TryParse(Console.ReadLine(), out input))
                            {
                                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                            }

                            Node newNode = new Node(input);

                            if (head == null)
                            {
                                head = newNode;
                                current = head;
                            }
                            else
                            {
                                // Выбор случайного узла для связывания
                                Node randomNode = GetRandomNode(head, rand, count);
                                newNode.Next = randomNode.Next;
                                randomNode.Next = newNode;
                            }
                        }

                        // Вывод элементов списка
                        Console.WriteLine("Элементы списка:");
                        current = head;
                        while (current != null)
                        {
                            Console.WriteLine(current.MyItems);
                            current = current.Next;
                        }

                        Node copiedList = CopyList(head);
                        Console.WriteLine("Элементы скопированного списка:");
                        PrintList(copiedList);
                        Console.ReadLine();
                    break;
                    case "0":
                        Console.Clear();
                        a = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Введено некорректное значение!");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}