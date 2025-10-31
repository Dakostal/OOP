namespace BankCreditApp.Models;

public class BankEmployee : Client
{
    public override decimal MaxLoan => 5_000_000m;
    public override decimal InterestRate => 0.08m;
}