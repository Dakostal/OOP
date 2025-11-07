using NUnit.Framework;
using ATM.Models;
using System;

namespace Tests;

[TestFixture]
public class AtmTests
{
    [SetUp]
    public void Setup()
    {
        // Очищаем список счетов
        AccountManager.Accounts.Clear();
        // Сбрасываем TotalBalance через рефлексию (так как set protected)
        typeof(Account).GetProperty("TotalBalance")!.SetValue(null, 0m);
    }

    [Test]
    public void Deposit_LargeAmountOnCurrent_Adds2000ToDebit()
    {
        var current = AccountManager.CreateAccount<CurrentAccount>();
        var debit = AccountManager.CreateAccount<DebitAccount>();
        current.Deposit(1_500_000);
        Assert.AreEqual(2000, debit.Balance, "Дебетовый счет должен получить +2000.");
    }

    [Test]
    public void Withdraw_Over30k_ThrowsException()
    {
        var account = AccountManager.CreateAccount<CurrentAccount>(100_000);
        Assert.Throws<InvalidOperationException>(() => account.Withdraw(30_001));
    }

    [Test]
    public void Withdraw_DebitWithLargeNegativeCredit_ThrowsException()
    {
        var debit = AccountManager.CreateAccount<DebitAccount>(10_000);
        var credit = AccountManager.CreateAccount<CreditAccount>(-25_000);
        Assert.Throws<InvalidOperationException>(() => debit.Withdraw(100));
    }

    [Test]
    public void Transfer_UpdatesBalances()
    {
        var current = AccountManager.CreateAccount<CurrentAccount>(50_000);
        var debit = AccountManager.CreateAccount<DebitAccount>(10_000);
        current.Transfer(debit, 20_000);
        Assert.AreEqual(30_000, current.Balance);
        Assert.AreEqual(30_000, debit.Balance);
    }

    [Test]
    public void TotalBalance_ReflectsAllAccounts()
    {
        AccountManager.CreateAccount<CurrentAccount>(10_000);
        AccountManager.CreateAccount<DebitAccount>(20_000);
        Assert.AreEqual(30_000, Account.TotalBalance);
    }

    [TestCase(100, ExpectedResult = 100)]
    [TestCase(500_000, ExpectedResult = 500_000)]
    public decimal Deposit_ValidAmount_UpdatesBalance(decimal amount)
    {
        var account = AccountManager.CreateAccount<CurrentAccount>();
        account.Deposit(amount);
        return account.Balance;
    }

    [Test]
    public void Deposit_NegativeAmount_ThrowsException()
    {
        var account = AccountManager.CreateAccount<CurrentAccount>();
        Assert.Throws<ArgumentException>(() => account.Deposit(-100));
    }

    [Test]
    public void Withdraw_InsufficientFunds_ThrowsException()
    {
        var account = AccountManager.CreateAccount<CurrentAccount>(100);
        Assert.Throws<InvalidOperationException>(() => account.Withdraw(200));
    }

    [Test]
    public void Transfer_NullAccount_ThrowsException()
    {
        var account = AccountManager.CreateAccount<CurrentAccount>(1000);
        Assert.Throws<ArgumentNullException>(() => account.Transfer(null, 100));
    }

    [Test]
    public void CreditAccount_CanHaveNegativeBalance()
    {
        var credit = AccountManager.CreateAccount<CreditAccount>();
        credit.Withdraw(10_000);
        Assert.AreEqual(-10_000, credit.Balance);
    }
}