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

        public void SubtractRecipeAmountFromInventory(int pitchersMade)
        {
            while (pitchersMade > 0)
            {
                if (player.inventory.lemons.Count <= 0 || player.inventory.sugarCubes.Count <= 0 || player.inventory.iceCubes.Count <= 0)
                {
                    Console.WriteLine("Can not use more ingredients than you have");
                    break;
                }
                for (int i = 0; i < player.recipe.numberOfLemons; i++)
                {
                    player.inventory.lemons.RemoveAt(0);
                }

                for (int i = 0; i < player.recipe.numberOfIceCubes; i++)
                {
                    player.inventory.iceCubes.RemoveAt(0);
                }

                for (int i = 0; i < player.recipe.numberOfSugarCubes; i++)
                {
                    player.inventory.sugarCubes.RemoveAt(0);
                }
            }
        }
        public void StartStore()
        {
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
        }

        public void RecipeEditor()
        {
            bool loop = true;
            while (loop)
            {
                player.recipe.DisplayRecipe();
                player.recipe.ChangeRecipe();

                if (player.recipe.numberOfLemons > player.inventory.lemons.Count || player.recipe.numberOfIceCubes > player.inventory.iceCubes.Count || player.recipe.numberOfSugarCubes > player.inventory.sugarCubes.Count)
                {
                    Console.WriteLine("You do not have enough ingredients for you to use this recipe. (Consider editing your recipe)");
                    continue;
                }
                else
                {
                    loop = false;
                }

            }
        }

        public void StartDay()
        {
            CreateNewDay(1);

            Console.WriteLine($"Day: {currentDay+1}");

            days[currentDay].DaysPossibleWeather();

            player.inventory.DisplayInventory();

            player.DisplayCashAmount();

            StartStore();

            RecipeEditor();

            player.recipe.ChangePricePerCup();

        }



        public void RunGame()
        {
            UserInterface.DisplayIntroMessage();
            StartDay();
            
            

        }


    }
}
