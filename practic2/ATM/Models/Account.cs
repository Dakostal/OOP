namespace ATM.Models;

public abstract class Account
{
    public decimal Balance { get; protected set; }
    public static decimal TotalBalance { get; protected set; }

    protected Account(decimal initialBalance = 0)
    {
        Balance = initialBalance;
        TotalBalance += initialBalance;
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Сумма пополнения должна быть положительной.");
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

    public virtual void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Сумма снятия должна быть положительной.");
        if (amount > 30_000) throw new InvalidOperationException("Нельзя снять более 30 000 за сеанс.");
        if (amount > Balance) throw new InvalidOperationException("Недостаточно средств на счете.");

        if (this is DebitAccount)
        {
            var credit = AccountManager.GetCreditAccount();
            if (credit != null && credit.Balance < -20_000)
                throw new InvalidOperationException("Операции с дебетовым счетом запрещены.");
        }

        Balance -= amount;
        TotalBalance -= amount;
    }

    public void Transfer(Account to, decimal amount)
    {
        if (to == null) throw new ArgumentNullException(nameof(to));
        Withdraw(amount);
        to.Deposit(amount);
    }
}