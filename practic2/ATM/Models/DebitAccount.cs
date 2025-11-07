namespace ATM.Models;

public sealed class DebitAccount : Account
{
    public DebitAccount() : base(0) { } // Пустой конструктор
    public DebitAccount(decimal initialBalance) : base(initialBalance) { }
}