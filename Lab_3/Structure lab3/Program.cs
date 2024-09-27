using System;
using System.Collections.Generic;
using System.Linq;
public class SubstringSearch
{
    public static int NaiveSearch(string text, string pattern) 
    {
        int n = text.Length;
        int m = pattern.Length;

        for (int i = 0; i <= n - m; i++)
        {
            int j;
            for (j = 0; j < m; j++)
            {
                if (text[i + j] != pattern[j])
                    break;
            }
            if (j == m)
                return i;
        }
        return -1;
    }

    public static int KMPSearch(string text, string pattern) 
    {
        int n = text.Length;
        int m = pattern.Length;
        int[] lps = ComputeLPSArray(pattern);

        int i = 0; // индекс в строке text
        int j = 0; // индекс в строке pattern

        while (i < n)
        {
            if (pattern[j] == text[i])
            {
                j++;
                i++;
            }
            if (j == m)
            {
                return i - j; 
            }
            else if (i < n && pattern[j] != text[i])
            {
                if (j != 0)
                    j = lps[j - 1];
                else
                    i = i + 1;
            }
        }
        return -1; 
    }

    private static int[] ComputeLPSArray(string pattern) 
    {
        int m = pattern.Length;
        int[] lps = new int[m];
        int len = 0;
        int i = 1;

        while (i < m)
        {
            if (pattern[i] == pattern[len])
            {
                len++;
                lps[i] = len;
                i++;
            }
            else
            {
                if (len != 0)
                    len = lps[len - 1];
                else
                {
                    lps[i] = 0;
                    i++;
                }
            }
        }
        return lps;
    }
}
public class PalindromeSubstrings
{
    public static List<string> GetAllPalindromicSubstrings(string s) 
    {
        List<string> result = new List<string>();
        int n = s.Length;
        bool[,] dp = new bool[n, n];

        for (int i = 0; i < n; i++)
        {
            dp[i, i] = true;
            result.Add(s[i].ToString());
        }

        for (int len = 2; len <= n; len++)
        {
            for (int start = 0; start <= n - len; start++)
            {
                int end = start + len - 1;
                if (len == 2 && s[start] == s[end])
                {
                    dp[start, end] = true;
                    result.Add(s.Substring(start, len));
                }
                else if (s[start] == s[end] && dp[start + 1, end - 1])
                {
                    dp[start, end] = true;
                    result.Add(s.Substring(start, len));
                }
            }
        }

        return result;
    }
}

    
    class Node
    {
        public char Symbol;
        public int Frequency;
        public Node Left, Right;
    }


    class HuffmanEncoder 
{ 
    public void HuffmanCompression(string text)
    {
        // Подсчет частоты символов
        Dictionary<char, int> frequencies = new Dictionary<char, int>();
        foreach (char c in text)
        {
            if (frequencies.ContainsKey(c))
                frequencies[c]++;
            else
                frequencies[c] = 1;
        }

        // Построение дерева Хаффмана
        List<Node> nodes = new List<Node>();
        foreach (var kvp in frequencies)
            nodes.Add(new Node { Symbol = kvp.Key, Frequency = kvp.Value });

        while (nodes.Count > 1)
        {
            nodes.Sort((x, y) => x.Frequency.CompareTo(y.Frequency));
            Node left = nodes[0];
            nodes.RemoveAt(0);
            Node right = nodes[0];
            nodes.RemoveAt(0);
            nodes.Add(new Node { Frequency = left.Frequency + right.Frequency, Left = left, Right = right });
        }

        // Генерация кодов Хаффмана
        Dictionary<char, string> codes = new Dictionary<char, string>();
        GenerateCodes(nodes[0], "", codes);

        // Вывод закодированного текста
        Console.WriteLine("Закодированный текст:");
        foreach (char c in text)
            Console.Write(codes[c]);
        Console.WriteLine();
    }

    // Рекурсивный метод для генерации кодов Хаффмана
    static void GenerateCodes(Node node, string code, Dictionary<char, string> codes)
    {
        if (node == null)
            return;
        if (node.Left == null && node.Right == null)
            codes[node.Symbol] = code;
        GenerateCodes(node.Left, code + "0", codes);
        GenerateCodes(node.Right, code + "1", codes);
    }
}
public class Graph
{
    private int V; // Количество вершин
    private List<List<int>> adj; // Список смежности

    public Graph(int v)
    {
        V = v;
        adj = new List<List<int>>();
        for (int i = 0; i < v; ++i)
            adj.Add(new List<int>());
    }

    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
    }

    private bool IsCyclicUtil(int v, bool[] visited, bool[] recStack)
    {
        if (recStack[v])
            return true;

        if (visited[v])
            return false;

        visited[v] = true;
        recStack[v] = true;

        foreach (var neighbour in adj[v])
        {
            if (IsCyclicUtil(neighbour, visited, recStack))
                return true;
        }

        recStack[v] = false;
        return false;
    }

    public bool IsCyclic()
    {
        bool[] visited = new bool[V];
        bool[] recStack = new bool[V];

        for (int i = 0; i < V; i++)
        {
            if (IsCyclicUtil(i, visited, recStack))
                return true;
        }

        return false;
    }
}
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Выберите опцию:");
            Console.WriteLine("1. Найти подстроку в строке");
            Console.WriteLine("2. Найти все палиндромные подстроки в строке");
            Console.WriteLine("3. Сжать текст с использованием алгоритма Хаффмана");
            Console.WriteLine("4. Проверить наличие циклов в графе");
            Console.WriteLine("5. Выйти из программы");

            string choose = Console.ReadLine();

            switch (choose)
            {
                case "1":
                    Console.WriteLine("Выберите алгоритм:");
                    Console.WriteLine("1 - Наивный");
                    Console.WriteLine("2 - Кнута-Морриса-Пратта");
                    string choose2 = Console.ReadLine();
                    switch(choose2)
                    {
                        case "1":
                            Console.WriteLine("Введите строку:");
                            string text = Console.ReadLine();
                            Console.WriteLine("Введите подстроку для поиска:");
                            string substring = Console.ReadLine();
                            int index = SubstringSearch.NaiveSearch(text, substring);
                            if (index != -1)
                                Console.WriteLine($"Подстрока найдена в позиции {index}");
                            else
                                Console.WriteLine("Подстрока не найдена");
                            break;
                            case "2":
                            Console.WriteLine("Введите строку:");
                            string text1 = Console.ReadLine();
                            Console.WriteLine("Введите подстроку для поиска:");
                            string substring1 = Console.ReadLine();
                            int index1 = SubstringSearch.KMPSearch(text1, substring1);
                            if (index1 != -1)
                                Console.WriteLine($"Подстрока найдена в позиции {index1}");
                            else
                                Console.WriteLine("Подстрока не найдена");
                            break;
                            break;
                    }
                    
                    break;
                case "2":
                    Console.WriteLine("Введите строку:");
                    string inputString = Console.ReadLine();
                    List<string> palindroms = PalindromeSubstrings.GetAllPalindromicSubstrings(inputString);
                    Console.WriteLine("Палиндромные подстроки:");
                    foreach (var palindrom in palindroms)
                    {
                        Console.WriteLine(palindrom);
                    }
                    break;
                case "3":
                    Console.WriteLine("Введите текст для сжатия:");
                    string originalText = Console.ReadLine();
                    HuffmanEncoder huffman = new HuffmanEncoder();
                    huffman.HuffmanCompression(originalText);
                    break;
                case "4":
                    Console.WriteLine("Введите количество вершин в графе:");
                    int tops = int.Parse(Console.ReadLine());
                    Graph graph = new Graph(tops);
                    Console.WriteLine("Введите количество ребер:");
                    int edge = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите ребра в формате 'начальная_вершина конечная_вершина':");
                    for (int i = 0; i < edge; i++)
                    {
                        string[] data = Console.ReadLine().Split(' ');
                        graph.AddEdge(int.Parse(data[0]), int.Parse(data[1]));
                    }
                    if (graph.IsCyclic())
                        Console.WriteLine("В графе есть цикл");
                    else
                        Console.WriteLine("В графе нет циклов");
                    break;
                case "5":
                    Console.WriteLine("Программа завершена.");
                    return;
            }
        }
    }
}