using ATM.Models;

class Program
{
    static void Main()
    {
        var current = AccountManager.CreateAccount<CurrentAccount>(100_000);
        var debit = AccountManager.CreateAccount<DebitAccount>(10_000);
        var credit = AccountManager.CreateAccount<CreditAccount>(-15_000);

        Console.WriteLine("Начальные балансы:");
        Console.WriteLine($"Текущий: {current.Balance}, Дебетовый: {debit.Balance}, Кредитный: {credit.Balance}");
        Console.WriteLine($"Общий баланс: {Account.TotalBalance}");

        current.Deposit(1_500_000);
        Console.WriteLine("\nПосле пополнения текущего на 1_500_000:");
        Console.WriteLine($"Дебетовый (должно +2000): {debit.Balance}");
        Console.WriteLine($"Общий баланс: {Account.TotalBalance}");

        current.Transfer(debit, 20_000);
        Console.WriteLine("\nПосле перевода 20_000 с текущего на дебетовый:");
        Console.WriteLine($"Текущий: {current.Balance}, Дебетовый: {debit.Balance}");
    }
}