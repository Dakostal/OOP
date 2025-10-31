namespace TransportApp.Models;

public class Taxi : PassengerTransport
{
    public decimal DistanceKm { get; }
    public decimal PricePerKm { get; } = 30m;
    public decimal BaseFare { get; } = 100m;

    public Taxi(decimal distanceKm)
    {
        DistanceKm = distanceKm;
    }

    public override decimal CalculateRevenue()
    {
        return BaseFare + DistanceKm * PricePerKm;
    }
}