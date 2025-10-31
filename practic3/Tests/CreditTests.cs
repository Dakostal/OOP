using NUnit.Framework;
using BankCreditApp.Models;

namespace Tests;

[TestFixture]
public class CreditTests
{
    [Test]
    public void BankEmployee_HighLimit_LowRate()
    {
        var emp = new BankEmployee();
        var (amount, rate) = emp.GetCreditOffer(10_000_000m);
        Assert.AreEqual(5_000_000m, amount);
        Assert.AreEqual(0.08m, rate);
    }

    [Test]
    public void RegularCitizen_StandardOffer()
    {
        var citizen = new RegularCitizen();
        var (amount, rate) = citizen.GetCreditOffer(800_000m);
        Assert.AreEqual(800_000m, amount);
        Assert.AreEqual(0.14m, rate);
    }

    [Test]
    public void BadCreditClient_LowLimit_HighRate()
    {
        var bad = new BadCreditClient();
        var (amount, rate) = bad.GetCreditOffer(500_000m);
        Assert.AreEqual(100_000m, amount);
        Assert.AreEqual(0.25m, rate);
    }

    [Test]
    public void Pensioner_PreferentialRate()
    {
        var pensioner = new Pensioner();
        var (amount, rate) = pensioner.GetCreditOffer(300_000m);
        Assert.AreEqual(300_000m, amount);
        Assert.AreEqual(0.10m, rate);
    }

    [Test]
    public void AllClients_Polymorphism_Works()
    {
        Client[] clients = {
            new BankEmployee(),
            new RegularCitizen(),
            new BadCreditClient(),
            new Pensioner()
        };

        decimal[] expectedMax = { 5_000_000m, 1_000_000m, 100_000m, 500_000m };
        decimal[] expectedRates = { 0.08m, 0.14m, 0.25m, 0.10m };

        for (int i = 0; i < clients.Length; i++)
        {
            Assert.AreEqual(expectedMax[i], clients[i].MaxLoan);
            Assert.AreEqual(expectedRates[i], clients[i].InterestRate);
        }
    }

    // Дополнительный тест: вывод программы
    [Test]
    public void TransportProgram_OutputsCorrectTotal()
    {
        var output = CaptureConsoleOutput(() =>
        {
            var transports = new PassengerTransport[]
            {
                new Bus(40, 10),
                new Taxi(15.5m),
                new Train(120, 30)
            };
            decimal total = 0;
            foreach (var t in transports) total += t.CalculateRevenue();
            Console.WriteLine($"Общая выручка: {total} руб.");
        });

        Assert.IsTrue(output.Contains("Общая выручка: 10165 руб."));
    }

    // Вспомогательный метод
    private string CaptureConsoleOutput(Action action)
    {
        var sb = new StringBuilder();
        var writer = new StringWriter(sb);
        var original = Console.Out;
        Console.SetOut(writer);

        action();

        Console.SetOut(original);
        return sb.ToString().Trim();
    }
}