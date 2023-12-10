using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_5.Data.Strategy
{
    public class DepositFinancialSavings : IFinancialSavings
    {
        public void MakeSavings(double amountToSave, BankAccount bankAccount)
        {
            bankAccount.AddToDeposit(amountToSave);
        }
    }
}
