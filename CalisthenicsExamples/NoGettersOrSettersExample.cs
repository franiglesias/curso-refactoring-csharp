// Translated from CalisthenicsExamples/no-getters-or-setters.ts
// Keeps simple balance operations and a runningBalance method
using System;

namespace CalisthenicsExamples
{
    public class BankAccount
    {
        private decimal balance;

        public BankAccount(decimal balance)
        {
            this.balance = balance;
        }

        public decimal RunningBalance()
        {
            return this.balance;
        }

        public void Deposit(decimal amount)
        {
            this.balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            this.balance -= amount;
        }
    }
}
