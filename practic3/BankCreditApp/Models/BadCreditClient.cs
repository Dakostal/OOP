namespace BankCreditApp.Models;

public class BadCreditClient : Client
{
    public override decimal MaxLoan => 100_000m;
    public override decimal InterestRate => 0.25m;
}