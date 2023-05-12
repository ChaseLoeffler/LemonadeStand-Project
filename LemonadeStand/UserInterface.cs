using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    static class UserInterface
    {
        public static int GetNumberOfItems(string itemsToGet)
        {
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;

            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                Console.WriteLine("How many " + itemsToGet + " would you like to buy?");
                Console.WriteLine("Please enter a positive integer (or 0 to cancel):");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }

            return quantityOfItem;
        }

        public static int GetNumberOfPitchers()
        {
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;

            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                Console.WriteLine("Each pitcher pours 8 cups. How many pitchers would you like to make?");
                Console.WriteLine("Please enter a positive integer (or 0 to cancel):");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }

            return quantityOfItem;
        }

        public static void DisplayIntroMessage()
        {
            Console.WriteLine("Hello, Welcome to the Lemonade stand Game.\nYour goal is to make as much money selling lemonade in a week (7 in game days).\nEach day you will be told the days weather forecast.\n" +
                "Keep noted of what the weather is likely to be as customers will be more likely to buy lemonade on hot sunny days and\nless likely on cold cloudy days. Adjust the price accordingly.\nAs well each day you will be able to buy the necessary " +
                "items needed to make your lemonade. Spend your money wisely.\nThe game ends when you are out of funds or finished the week. Good luck!\n");
        }
    }
}
