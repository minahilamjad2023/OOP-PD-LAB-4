using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.BL
{
    public class Balance
    {
        private double balanceAmount;

        public Balance(double balanceAmount)
        {
            this.balanceAmount = balanceAmount;
        }

        public void setBalance(double balanceAmount)
        {
             this.balanceAmount = balanceAmount;
        }

        public double getBalance()
        {
            return balanceAmount;
        }
    }
}
