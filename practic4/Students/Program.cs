using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество студентов: ");
        if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
        {
            Console.WriteLine("Ошибка: введите положительное число.");
            return;
        }

        string[] lastNames = new string[count];
        string[] firstNames = new string[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Введите фамилию студента {i + 1}: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ошибка: фамилия не может быть пустой.");
                return;
            }
            lastNames[i] = input;

            Console.Write($"Введите имя студента {i + 1}: ");
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ошибка: имя не может быть пустой.");
                return;
            }
            firstNames[i] = input;

            Console.WriteLine($"Сохранено: фамилия = {lastNames[i]}, имя = {firstNames[i]}");
        }

        Console.WriteLine("\nВведенные данные:");
        Console.WriteLine("Фамилии: " + string.Join(", ", lastNames));
        Console.WriteLine("Имена: " + string.Join(", ", firstNames));

        string[] combined = new string[count * 2];
        for (int i = 0, j = 0, k = 0; i < combined.Length; i++)
        {
            if (i % 2 == 0)
                combined[i] = firstNames[j++];
            else
                combined[i] = lastNames[k++];
        }

        Console.WriteLine("\nОбъединенный массив:");
        for (int i = 0; i < combined.Length; i++)
        {
            Console.WriteLine($"Индекс {i}: {combined[i] ?? "null"}");
        }
    }
}