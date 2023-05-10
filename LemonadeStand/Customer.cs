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
        public bool WantsLemonade(string conditon)
        {
            if (conditon == "Hot and Sunny")
            {
                int randomNum = (int)rand.NextInt64(1,2);

                if (randomNum == 1)
                {
                     return true;
                }
                else
                {
                     return false;
                }
            }
            if (conditon == "Warm and Cloudy")
            {
                int randomNum = (int)rand.NextInt64(1,3);

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

        public void ChecksPrice(int maxWillingToPay)
        {
            if (priceOfObject <= maxWillingToPay)
            {
                BuysLemonade(priceOfObject);
            }

        }

        public void BuysLemonade(int priceOfObject)
        {
            this.wallet.PayMoneyForItems(priceOfObject);
        }


    }
}
