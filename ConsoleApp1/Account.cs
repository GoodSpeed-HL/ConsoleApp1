using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Account
    {
        public int Balance { set; get; }

        public Account(int balance)
        {
            Balance = balance;
        }

        public string GetBalance()
        {
            return String.Format("current balance is {0}", Balance);
        }

        public void Withdraw(int amount)
        {
            Balance -= amount;
        }

        public void Deposit(int amount)
        {
            Balance += amount;
        }
    }
}
