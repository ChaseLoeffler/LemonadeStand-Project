using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        // member variables (HAS A)
        public string name;
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;

        // constructor (SPAWNER)
        public Player(string name)
        {
            inventory = new Inventory();
            wallet = new Wallet();
            recipe = new Recipe();
            this.name = name;
        }

        // member methods (CAN DO)
        public void DisplayCashAmount()
        {
            Console.WriteLine($"You currently have {this.wallet.Money} dollars in your wallet.");
        }
    }
}
