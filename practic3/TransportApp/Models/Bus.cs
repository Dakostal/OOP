namespace TransportApp.Models;

public class Bus : PassengerTransport
{
    public int TotalPassengers { get; }
    public int DiscountedPassengers { get; }
    public decimal TicketPrice { get; } = 50m;
    public decimal DiscountedPrice { get; } = 25m;

    public Bus(int total, int discounted)
    {
        TotalPassengers = total;
        DiscountedPassengers = discounted;
    }

    public override decimal CalculateRevenue()
    {
        int fullPay = TotalPassengers - DiscountedPassengers;
        return fullPay * TicketPrice + DiscountedPassengers * DiscountedPrice;
    }
}