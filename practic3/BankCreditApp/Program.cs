using BankCreditApp.Models;

class Program
{
    static void Main()
    {
        var clients = new Client[]
        {
            new BankEmployee(),
            new RegularCitizen(),
            new BadCreditClient(),
            new Pensioner()
        };

        decimal[] requests = { 3_000_000m, 800_000m, 200_000m, 400_000m };

        for (int i = 0; i < clients.Length; i++)
        {
            var (amount, rate) = clients[i].GetCreditOffer(requests[i]);
            Console.WriteLine($"{clients[i].GetType().Name}: " +
                              $"Одобрено: {amount:N0} руб., ставка: {rate:P1}");
        }
    }
}