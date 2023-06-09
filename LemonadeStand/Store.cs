﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        // member variables (HAS A)
        private double pricePerLemon;
        private double pricePerSugarCube;
        private double pricePerIceCube;
        private double pricePerCup;

        // constructor (SPAWNER)
        public Store()
        {
            pricePerLemon = .5;
            pricePerSugarCube = .1;
            pricePerIceCube = .01;
            pricePerCup = .25;
        }

        // member methods (CAN DO)
        public void SellLemons(Player player)
        {
            Console.WriteLine($"Lemons cost {pricePerLemon}");
            int lemonsToPurchase = UserInterface.GetNumberOfItems("lemons");
            double transactionAmount = CalculateTransactionAmount(lemonsToPurchase, pricePerLemon);
            if(player.wallet.Money >= transactionAmount)
            {
                player.wallet.PayMoneyForItems(transactionAmount);
                player.inventory.AddLemonsToInventory(lemonsToPurchase);
            }
        }

        public void SellSugarCubes(Player player)
        {
            Console.WriteLine($"Sugar Cubes cost {pricePerSugarCube}");
            int sugarToPurchase = UserInterface.GetNumberOfItems("sugar");
            double transactionAmount = CalculateTransactionAmount(sugarToPurchase, pricePerSugarCube);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddSugarCubesToInventory(sugarToPurchase);
            }
        }

        public void SellIceCubes(Player player)
        {
            Console.WriteLine($"Ice Cubes cost {pricePerIceCube}");
            int iceCubesToPurchase = UserInterface.GetNumberOfItems("ice cubes");
            double transactionAmount = CalculateTransactionAmount(iceCubesToPurchase, pricePerIceCube);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddIceCubesToInventory(iceCubesToPurchase);
            }
        }

        public void SellCups(Player player)
        {
            Console.WriteLine($"Cups cost {pricePerCup}");
            int cupsToPurchase = UserInterface.GetNumberOfItems("cups");
            double transactionAmount = CalculateTransactionAmount(cupsToPurchase, pricePerCup);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddCupsToInventory(cupsToPurchase);
            }
        }

        private double CalculateTransactionAmount(int itemCount, double itemPricePerUnit)
        {
            double transactionAmount = itemCount * itemPricePerUnit;
            return transactionAmount;
        }

        private void PerformTransaction(Wallet wallet, double transactionAmount)
        {
            wallet.PayMoneyForItems(transactionAmount);
        }

        public static string AskToStore()
        {
            Console.WriteLine("Would you like to purchase any items today?(Remember you'll need at least 8 cups, 1 pitcher pours 8 cups of Lemonade.)\n(Capital Y for yes, Capital N for no)");
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}
