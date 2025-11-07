namespace ATM.Models;

public sealed class CreditAccount : Account
{
    public CreditAccount() : base(0) { } // Пустой конструктор
    public CreditAccount(decimal initialBalance) : base(initialBalance) { }
}