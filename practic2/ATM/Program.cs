using ATM.Models;

var current = AccountManager.Create<CurrentAccount>(100_000);
var debit = AccountManager.Create<DebitAccount>(10_000);
var credit = AccountManager.Create<CreditAccount>(-15_000);

current.Deposit(1_500_000);
Console.WriteLine($"Дебетовый: {debit.Balance}");
Console.WriteLine($"Общий баланс: {Account.TotalBalance}");