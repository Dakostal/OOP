using NUnit.Framework;
using TransportApp.Models;

namespace Tests;

[TestFixture]
public class TransportTests
{
   [Test]
    public void Bus_Revenue_WithDiscounts_CalculatesCorrectly()
    {
        var bus = new Bus(40, 10);
        Assert.AreEqual(2250m, bus.CalculateRevenue()); // 30*50 + 10*25
    }

    [Test]
    public void Taxi_Revenue_ByDistance_IsCorrect()
    {
        var taxi = new Taxi(20m);
        Assert.AreEqual(700m, taxi.CalculateRevenue()); // 100 + 20*30
    }

    [Test]
    public void Train_Revenue_WithChildren_IsCorrect()
    {
        var train = new Train(100, 25);
        Assert.AreEqual(10500m, train.CalculateRevenue()); // 75*120 + 25*60
    }

    [Test]
    public void TotalRevenue_SumOfAllTransports()
    {
        var transports = new PassengerTransport[]
        {
            new Bus(50, 15),    // 35*50 + 15*25 = 2125
            new Taxi(10),       // 100 + 300 = 400
            new Train(80, 20)   // 60*120 + 20*60 = 8400
        };

        decimal total = 0;
        foreach (var t in transports) total += t.CalculateRevenue();
        Assert.AreEqual(10925m, total);
    }

    [Test]
    public void Bus_NoDiscounts_FullPrice()
    {
        var bus = new Bus(30, 0);
        Assert.AreEqual(1500m, bus.CalculateRevenue());
    }
    
}