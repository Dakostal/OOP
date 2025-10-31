namespace ATM.Models;

public static class AccountManager
{
    private static readonly List<Account> Accounts = new();

    public static T Create<T>(decimal initial = 0) where T : Account, new()
    {
        var acc = new T();
        acc.GetType().GetProperty("Balance")!.SetValue(acc, initial);
        Accounts.Add(acc);
        Account.TotalBalance += initial;
        return acc;
    }

    public static DebitAccount? GetDebitAccount() => Accounts.OfType<DebitAccount>().FirstOrDefault();
    public static CreditAccount? GetCreditAccount() => Accounts.OfType<CreditAccount>().FirstOrDefault();
}