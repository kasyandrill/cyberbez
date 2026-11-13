using System;
using System.Security.Cryptography;

namespace CyberSecurity_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("   ЛАБОРАТОРНА РОБОТА №1: Генерація випадкових чисел");
                Console.WriteLine("=========================================================");
                Console.WriteLine("1 - Завдання 2: Псевдовипадкові числа (клас Random)");
                Console.WriteLine("2 - Завдання 3: Криптографічно стійкі числа (RandomNumberGenerator)");
                Console.WriteLine("0 - Вихід");
                Console.WriteLine("=========================================================");
                Console.Write("Оберіть пункт меню: ");

                string? choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        RunPseudoRandomTask();
                        break;
                    case "2":
                        RunCryptoRandomTask();
                        break;
                    case "0":
                        Console.WriteLine("Завершення роботи...");
                        return;
                    default:
                        Console.WriteLine("Невірний вибір! Спробуйте ще раз.");
                        break;
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися до меню...");
                Console.ReadKey();
            }
        }

        // Завдання 2: Звичайний Random
        static void RunPseudoRandomTask()
        {
            Console.WriteLine("=== Генерація псевдовипадкових чисел (клас Random) ===\n");

            // 1. Однакові початкові значення (seed = 42)
            Console.WriteLine("1. Два генератори з ОДНАКОВИМ початковим значенням (seed = 42):");
            Random rndSame1 = new Random(42);
            Random rndSame2 = new Random(42);

            Console.Write("Генератор 1: ");
            PrintSequence(rndSame1, 7);

            Console.Write("Генератор 2: ");
            PrintSequence(rndSame2, 7);

            Console.WriteLine(new string('-', 60));

            // 2. Різні початкові значення (seed = 42 та seed = 100)
            Console.WriteLine("2. Два генератори з РІЗНИМИ початковими значеннями (seed 42 та 100):");
            Random rndDiff1 = new Random(42);
            Random rndDiff2 = new Random(100);

            Console.Write("Генератор 1 (seed 42):  ");
            PrintSequence(rndDiff1, 7);

            Console.Write("Генератор 2 (seed 100): ");
            PrintSequence(rndDiff2, 7);
        }

        // Завдання 3: Криптографічно стійкий RandomNumberGenerator
        static void RunCryptoRandomTask()
        {
            Console.WriteLine("=== Криптографічно стійка генерація (RandomNumberGenerator) ===\n");

            // Проводимо 4 послідовні спроби генерації
            for (int attempt = 1; attempt <= 4; attempt++)
            {
                Console.Write($"Спроба #{attempt}: ");
                PrintCryptoSequence(7);
            }
        }

        static void PrintSequence(Random rnd, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{rnd.Next(1, 100),4} ");
            }
            Console.WriteLine();
        }

        static void PrintCryptoSequence(int count)
        {
            for (int i = 0; i < count; i++)
            {
                // RandomNumberGenerator.GetInt32 не має параметра seed
                int secureNumber = RandomNumberGenerator.GetInt32(1, 100);
                Console.Write($"{secureNumber,4} ");
            }
            Console.WriteLine();
        }
    }
}