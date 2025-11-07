namespace ATM.Models;

public static class AccountManager
{
    public static readonly List<Account> Accounts = new();

    public static T CreateAccount<T>(decimal initialBalance = 0) where T : Account, new()
    {
        var account = new T();
        account.GetType().GetProperty("Balance")!.SetValue(account, initialBalance);
        Accounts.Add(account);
        // TotalBalance обновляется в конструкторе Account
        return account;
    }

    public static DebitAccount? GetDebitAccount() => Accounts.OfType<DebitAccount>().FirstOrDefault();
    public static CreditAccount? GetCreditAccount() => Accounts.OfType<CreditAccount>().FirstOrDefault();
}