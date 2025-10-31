using TransportApp.Models;

class Program
{
    static void Main()
    {
        var transports = new PassengerTransport[]
        {
            new Bus(40, 10),
            new Taxi(15.5m),
            new Train(120, 30)
        };

        decimal totalRevenue = 0;
        foreach (var t in transports)
        {
            decimal rev = t.CalculateRevenue();
            Console.WriteLine($"{t.GetType().Name}: {rev} руб.");
            totalRevenue += rev;
        }

        Console.WriteLine($"Общая выручка: {totalRevenue} руб.");
    }
}