namespace BankCreditApp.Models;

public class RegularCitizen : Client
{
    public override decimal MaxLoan => 1_000_000m;
    public override decimal InterestRate => 0.14m;
}