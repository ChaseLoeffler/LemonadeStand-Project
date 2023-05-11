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
        //Constructor
        public Customer()
        {
            wallet = new Wallet();
            rand = new Random();
        }
        //Member Methods (CAN DO)
        public bool WantsLemonade(string conditon)
        {
            if (conditon == "Hot and Sunny")
            {
                return true;
            }
            if (conditon == "Warm and Cloudy")
            {
                int randomNum = (int)rand.NextInt64(1,4);

                if (randomNum == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (conditon == "Cold and Rainy")
            {
                int randomNum = (int)rand.NextInt64(1,5);

                if (randomNum == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ChecksPrice(double priceOfObject, int maxWillingToPay)
        {
            if (priceOfObject <= maxWillingToPay)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void BuysLemonade(double priceOfObject)
        {
            this.wallet.PayMoneyForItems(priceOfObject);
        }


    }
}
