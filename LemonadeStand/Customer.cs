using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Customer
    {   // Member Variables (HAS A)
        public Random rand;
        public Wallet wallet;
        public int priceOfObject;
        //Constructor
        public Customer()
        {
            wallet = new Wallet();
            rand = new Random();
            priceOfObject = 0;
        }
        //Member Methods (CAN DO)
        public bool WantsLemonade()
        {
            int randomNum = (int)rand.NextInt64(10);
            if (randomNum <= 5)
            {
               return true;
            }
            else
            {
                return false;
            }
        }
        public void BuysLemonade()
        {
            this.wallet.PayMoneyForItems(priceOfObject);
        }


    }
}
