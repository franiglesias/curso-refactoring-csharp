namespace CursoRefactoring.Calisthenics;

public class BankAccount
{
    private double balance;

    public BankAccount(double balance)
    {
        this.balance = balance;
    }

    public double GetBalance()
    {
        return balance;
    }

    public void SetBalance(double amount)
    {
        balance = amount;
    }
}

public class BankAccountExample
{
    public static void RunExample()
    {
        var account = new BankAccount(1000);
        var current = account.GetBalance();
        account.SetBalance(current - 200);
    }
}