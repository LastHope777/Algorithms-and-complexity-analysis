using pracrice3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pracrice3
{
    //Создание презентаций
    class Presentation
    {
        public double bestPrice;

        //с повторениями
        public double withRepeats(List<Slide_presentation> items, int maxWeight, int maxNegativeWeight) 
        {
            double[] A = new double[maxWeight + 1]; // вес
            double[] N = new double[maxWeight + 1]; // штрафы

            for (int w = 1; w <= maxWeight; w++)
            {
                A[w] = A[w - 1];
                N[w] = N[w - 1];

                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].weigth <= w && N[w - items[i].weigth] + items[i].negative_price <= maxNegativeWeight)
                    {
                        double newPrice = A[w - items[i].weigth] + items[i].price;
                        double newNegativePrice = N[w - items[i].weigth] + items[i].negative_price;

                        if (newPrice > A[w])
                        {
                            A[w] = newPrice;
                            N[w] = newNegativePrice;
                        }
                    }
                }
            }
            return bestPrice = A[maxWeight];
        }
        // без повторений
        public double withoutRepeats(List<Slide_presentation> items, int maxWeight, int maxNegativeWeight)
        {
            int n = items.Count;
            double[,] A = new double[maxWeight + 1, n]; // вес
            double[,] N = new double[maxWeight + 1, n]; // штрафы

            for (int w = 0; w <= maxWeight; w++)
            {
                A[w, 0] = 0;
                N[w, 0] = 0;
            }

            for (int j = 0; j < n; j++)
            {
                A[0, j] = 0;
                N[0, j] = 0;
            }

            for (int j = 1; j < n; j++)
            {
                for (int w = 1; w <= maxWeight; w++)
                {
                    if (items[j].weigth > w)
                    {
                        A[w, j] = A[w, j - 1];
                        N[w, j] = N[w, j - 1];
                    }
                    else
                    {
                        double option1Price = A[w, j - 1];
                        double option1NegativePrice = N[w, j - 1];

                        double option2Price = A[w - items[j].weigth, j - 1] + items[j].price;
                        double option2NegativePrice = N[w - items[j].weigth, j - 1] + items[j].negative_price;

                        if (option2Price > option1Price && option2NegativePrice <= maxNegativeWeight)
                        {
                            A[w, j] = option2Price;
                            N[w, j] = option2NegativePrice;
                        }
                        else
                        {
                            A[w, j] = option1Price;
                            N[w, j] = option1NegativePrice;
                        }
                    }
                }
            }
            return bestPrice = A[maxWeight, n - 1];
        }
    }
    class Slide_presentation //Класс для слайдов в презентации
    {
        public string name { get; set; } 

        public int weigth { get; set; }

        public double price { get; set; }

        public double negative_price { get; set; }

        public Slide_presentation(string _name, int _weigth, double _price, double negative_price)
        {
            name = _name;
            weigth = _weigth;
            price = _price;
            this.negative_price = negative_price;
        }
    }


    //Создание слайдов
    class Slides 
    {
        public double bestPrice;

        public double withRepeats(List<ObjectsOnSlides> objects, int maxWeight)
        {
            double[] A = new double[maxWeight + 1];
            for (int w = 1; w <= maxWeight; w++)
            {
                A[w] = A[w - 1];
                for (int i = 0; i < objects.Count; i++)
                {
                    if (objects[i].weigth <= w)
                    {
                        A[w] = Math.Max(A[w], A[w - objects[i].weigth] + objects[i].price);
                    }
                }
            }
            return bestPrice = A[maxWeight];
        }

        public double withoutRepeats(List<ObjectsOnSlides> objests, int maxWeight) 
        {
            int n = objests.Count;
            double[,] A = new double[maxWeight + 1, n];

            for (int w = 0; w <= maxWeight; w++) //Делаем 0 в первом столбце
            {
                A[w, 0] = 0;
            }
            //A[w,i] - оптимальная стоимость первых i предметов для объёма w
            for (int j = 0; j < n; j++) //Делаем 0 в первой строке
            {
                A[0, j] = 0;
            }

            for (int j = 1; j < n; j++)
            {
                for (int w = 1; w <= maxWeight; w++)
                {
                    if (objests[j].weigth > w)
                    {
                        A[w, j] = A[w, j - 1];
                    }
                    else
                    {
                        A[w, j] = Math.Max(A[w, j - 1], A[w - objests[j].weigth, j - 1] + objests[j].price);
                    }
                }
            }
            return bestPrice = A[maxWeight, n - 1];
        }
    }
    class ObjectsOnSlides 
    {
        public string name { get; set; } 

        public int weigth { get; set; }

        public double price { get; set; }

        public ObjectsOnSlides(string _name, int _weigth, double _price)
        {
            name = _name;
            weigth = _weigth;
            price = _price;
        }
    }
    class Program
    {

        private static List<Slide_presentation> slides;
        private static Presentation presentation = new Presentation();
        private static List<ObjectsOnSlides> objects;
        private static Slides slide = new Slides();
        static void Main(string[] args)
        {
            bool a = true;
            while (a)
            {
                Console.Clear();
                Console.WriteLine("Выберите режим:\n1 - Заполнение презентации\n2 - Заполнение слайда");
                string choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        { 
                            Console.Clear();
                            slides = new List<Slide_presentation>();

                            slides.Add(new Slide_presentation("Слайд только из текста", 1, 1000, 3));
                            slides.Add(new Slide_presentation("Стайд с текстом и одной картинкой", 1, 900, 2));
                            slides.Add(new Slide_presentation("Слайд с одной картинкой", 1, 500, 1));
                            slides.Add(new Slide_presentation("Слайд с двумя картинками", 1, 650, 1));
                            slides.Add(new Slide_presentation("Слайд с текстом и двумя картинками", 1, 800, 1));
                            Console.WriteLine("Список возможных слайдов: ");
                            foreach (Slide_presentation it in slides)
                            {
                                Console.WriteLine("Название: " + it.name + "  Вес: " + it.weigth + "  Цена:" + it.price + "  Штраф:" + it.negative_price);
                            }
                            Console.Write("\nВведите количество слайдов в презентации: ");
                            int weight = int.Parse(Console.ReadLine());
                            Console.WriteLine("Выберите способ решения: \n 1 - С повторениями \n 2 - Без повторений");
                            Console.Write("Ваш выбор: ");
                            string selected = Console.ReadLine();
                            Console.WriteLine();
                            int maxNegativeWeight = 0;

                            //Формула для количества возможных штрафов
                            if (weight < 9)
                                maxNegativeWeight = 5;
                            else
                                maxNegativeWeight = weight * 1 / 2;

                            switch (selected)
                            {
                                case "1":
                                    Console.WriteLine("Максимальная стоимость слайдов: " + presentation.withRepeats(slides, weight, maxNegativeWeight));
                                    break;
                                case "2":
                                    Console.WriteLine("Максимальная стоимость слайдов: " + presentation.withoutRepeats(slides, weight, maxNegativeWeight));
                                    break;
                                default:
                                    Console.WriteLine("Введено некорректное значение!");
                                    Console.ReadLine();
                                    break;
                            }
                            Console.ReadLine();
                            break;
                        }
                        case "2":
                        {
                            Console.Clear();
                            objects = new List<ObjectsOnSlides>();

                            objects.Add(new ObjectsOnSlides("Диаграмма", 2, 5000));
                            objects.Add(new ObjectsOnSlides("Текст", 1, 2000));
                            objects.Add(new ObjectsOnSlides("Картинка", 3, 3500));
                            objects.Add(new ObjectsOnSlides("Смешная картинка", 5, 8000));
                            objects.Add(new ObjectsOnSlides("Таблица", 2, 4500));
                            Console.WriteLine("Список предметов: ");
                            foreach (ObjectsOnSlides it in objects)
                            {
                                Console.WriteLine("Название: " + it.name + "  Вес: " + it.weigth + "  Цена:" + it.price);
                            }
                            Console.Write("\nВведите максимальный \"вес\" слайда: ");
                            int weight = int.Parse(Console.ReadLine());
                            Console.WriteLine("Выберите способ решения: \n 1 - С повторениями \n 2 - Без повторений");
                            Console.Write("Ваш выбор: ");
                            string selected = Console.ReadLine();
                            Console.WriteLine();
                            switch (selected)
                            {
                                case "1":
                                    Console.WriteLine("Максимальная стоимость слайдов: " + slide.withRepeats(objects, weight));
                                    break;
                                case "2":
                                    Console.WriteLine("Максимальная стоимость слайдов: " + slide.withoutRepeats(objects, weight));
                                    break;
                                default:
                                    Console.WriteLine("Введено некорректное значение!");
                                    Console.ReadLine();
                                    break;
                            }
                            Console.ReadLine();
                            break;
                        }
                        default:
                            Console.WriteLine("Введено некорректное значение!");
                            Console.ReadLine();
                            break;
                }
            }
        }
    }

}
 //Время работы экспоненциально от длины входа. Чтобы записать числа для W, длина входа будет n + logW
 //Из-за битов, например 11 - это 3, а 111 - это уже 7
 //Так у всех алгоритмов, которые работают в зависимости от того, что дали на вход
 //      0    1   2   3   4
 //   0  0    0   0   0
 //   1  0   
 //   2  0
 // 1 столбик, смотрим, только первый предмет, второй столбик 1+2 комбинации, третий столбик 3 с 1 и 2 комб и т.д.