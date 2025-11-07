namespace ATM.Models;

public sealed class CurrentAccount : Account
{
    public CurrentAccount() : base(0) { } // Пустой конструктор
    public CurrentAccount(decimal initialBalance) : base(initialBalance) { }
}