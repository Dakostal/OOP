namespace BankCreditApp.Models;

public class Pensioner : Client
{
    public override decimal MaxLoan => 500_000m;
    public override decimal InterestRate => 0.10m;
}