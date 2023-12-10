using lab_3.Task_5.Data.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_5.Data
{
    public class BankAccount
    {
        private IFinancialSavings _financialSavings { get; set; }
        
        private string CardNumber { get; set; }
        private string UserName { get; set; }
        public double Balance { get; private set; }
        public double Currency { get; private set; }
        public double Deposit { get; private set; }
        public double Shares { get; private set; }

        public void SetFinancialSavingsStrategy(IFinancialSavings financialSavings)
        {
            _financialSavings = financialSavings;
        }

        public void MakeSavings(double amount)
        {
            if (_financialSavings == null)
                throw new InvalidOperationException("Saving strategy must be chosen");
            _financialSavings.MakeSavings(amount, this);
        }

        public void BuyCurrency(double amount, double exchangeRate)
        {
            Balance -= amount;
            Currency += amount * exchangeRate;
        }
        public void AddToDeposit(double amount)
        {
            Balance -= amount;
            Deposit += amount;
        }
        public void BuyShares(double amount)
        {
            Balance -= amount;
            Shares += amount;
        }
    }
}
