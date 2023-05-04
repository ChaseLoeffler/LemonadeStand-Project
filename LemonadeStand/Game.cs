using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Game
    {   // Member Variables (HAS A)
        private Player player;
        private List<Day> days;
        private int currentDay;
        private Store store;
        //Constructor
        public Game()
        {
            player = new Player("Player");
            days = new List<Day>();
            currentDay = 0;
            store = new Store();
        }
        //Member Methods (CAN DO)

        public void CreateNewDay(int numOfDays)
        {
            for (int i = 0; i < numOfDays; i++)
            {
                Day day = new Day();
                days.Add(day);
            }
        }

        public void StartDay()
        {
            CreateNewDay(1);
            Console.WriteLine($"Day: {currentDay+1}");
            days[currentDay].DaysPossibleWeather();
            player.inventory.DisplayInventory();
            player.DisplayCashAmount();
            bool loop = true;
            while (loop)
            {
                string answer = Store.AskToStore();
                if (answer == "Y")
                {
                    Console.WriteLine("Great.");
                    store.SellLemons(player);
                    store.SellCups(player);
                    store.SellIceCubes(player);
                    store.SellSugarCubes(player);
                    loop = false;
                }
                if (answer == "N")
                {
                    Console.WriteLine("Okay, Have a nice day.\n");
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Invaild rsponse. Please try again.");
                    continue;
                }
               
                
            }
            player.recipe.DisplayRecipe();
            player.recipe.ChangeRecipe();
            player.recipe.ChangePricePerCup();

        }



        public void RunGame()
        {
            UserInterface.DisplayIntroMessage();
            StartDay();
            
            

        }


    }
}
