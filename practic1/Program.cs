using System;
using System.Text;

namespace AnimalsProgram;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var lion = new Animal("Лев Алекс", 5, 4, AnimalType.Carnivore, Habitat.Land, Continent.Africa, true);
        var eagle = new Animal("Орёл", 3, 2, AnimalType.Carnivore, Habitat.Air, Continent.Asia, false);
        var dolphin = new Animal("Дельфин", 7, 0, AnimalType.Carnivore, Habitat.Water, Continent.NorthAmerica, true);
        var frog = new Animal("Лягушка", 2, 4, AnimalType.Omnivore, Habitat.Amphibious, Continent.SouthAmerica, false);
        var unknown = new Animal();

        lion.Age = 6;

        Console.WriteLine("=== ЖИВОТНЫЕ ===");
        Console.WriteLine(lion);
        Console.WriteLine(eagle);
        Console.WriteLine(dolphin);
        Console.WriteLine(frog);
        Console.WriteLine(unknown);

        Console.WriteLine($"\n{lion.Name} издаёт звук: {lion.GetSound()}");
        Console.WriteLine($"Может ли {eagle.Name} летать? {eagle.CanFly()}");
        Console.WriteLine($"Может ли {dolphin.Name} плавать? {dolphin.CanSwim()}");
        Console.WriteLine($"Есть ли хвост у {frog.Name}? {frog.ExistsTail()}");

        var lion2 = new Animal("Лев Алекс", 5, 4, AnimalType.Carnivore, Habitat.Land, Continent.Africa, true);
        Console.WriteLine($"\nlion == lion2: {lion == lion2}");
        Console.WriteLine($"lion != dolphin: {lion != dolphin}");

        Console.WriteLine("\n=== ФИГУРЫ ===");
        var circle = new Circle(5);
        var rect = new Rectangle(4, 6);
        var tri = new Triangle(3, 8);

        Console.WriteLine($"Площадь круга (r=5): {circle.Square:F2}");
        Console.WriteLine($"Площадь прямоугольника (4x6): {rect.Square:F2}");
        Console.WriteLine($"Площадь треугольника (осн=3, выс=8): {tri.Square:F2}");

        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }
}