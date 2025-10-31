namespace ATM.Models;

public abstract class Account
{
    public decimal Balance { get; protected set; }
    public static decimal TotalBalance { get; private set; }

    protected Account(decimal initial = 0)
    {
        Balance = initial;
        TotalBalance += initial;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Сумма должна быть > 0");
        Balance += amount;
        TotalBalance += amount;

        if (this is CurrentAccount && amount > 1_000_000)
        {
            var debit = AccountManager.GetDebitAccount();
            if (debit != null)
            {
                debit.Balance += 2000;
                TotalBalance += 2000;
            }
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 30000) throw new InvalidOperationException("Макс 30 000 за сеанс");
        if (amount > Balance) throw new InvalidOperationException("Недостаточно средств");

        var credit = AccountManager.GetCreditAccount();
        if (this is DebitAccount && credit != null && credit.Balance < -20000)
            throw new InvalidOperationException("Дебетовый счёт заблокирован");

        Balance -= amount;
        TotalBalance -= amount;
    }

    public void Transfer(Account to, decimal amount)
    {
        Withdraw(amount);
        to.Deposit(amount);
    }
}