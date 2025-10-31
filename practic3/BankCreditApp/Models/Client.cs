namespace BankCreditApp.Models;

public abstract class Client
{
    public abstract decimal MaxLoan { get; }
    public abstract decimal InterestRate { get; }

    public (decimal amount, decimal rate) GetCreditOffer(decimal requested)
    {
        decimal amount = Math.Min(requested, MaxLoan);
        return (amount, InterestRate);
    }
}