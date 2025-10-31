namespace TransportApp.Models;

public class Train : PassengerTransport
{
    public int TotalPassengers { get; }
    public int Children { get; }
    public decimal AdultTicket { get; } = 120m;
    public decimal ChildTicket { get; } = 60m;

    public Train(int total, int children)
    {
        TotalPassengers = total;
        Children = children;
    }

    public override decimal CalculateRevenue()
    {
        int adults = TotalPassengers - Children;
        return adults * AdultTicket + Children * ChildTicket;
    }
}