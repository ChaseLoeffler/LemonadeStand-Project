﻿using System;
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
        private double totalProfitOrLoss;
        public Random rand;
        //Constructor
        public Game()
        {
            player = new Player("Player");
            days = new List<Day>();
            currentDay = 0;
            totalProfitOrLoss = 0;
            store = new Store();
            rand = new Random();
        }
        //Member Methods (CAN DO)

        public void CustomersWalkingBy(double priceOfObject, int numberOfCups)
        {
            foreach (Customer customer in days[currentDay].customers)
            {
                do
                {
                    Console.WriteLine("A customer is walking by.\n");
                    bool wants = customer.WantsLemonade(days[currentDay].weather.condition);
                    if (wants == true)
                    {
                        int maxWillingToPay = 0;
                        if (days[currentDay].weather.condition == "Hot and Sunny")
                        {
                            maxWillingToPay = rand.Next(5, 11);
                            bool okayWithPaying = customer.ChecksPrice(priceOfObject, maxWillingToPay);
                            if (okayWithPaying == true)
                            {
                                Console.WriteLine("The customer perchased Lemonade.\n");
                                customer.BuysLemonade(priceOfObject);
                                player.wallet.AcceptMoney(priceOfObject);
                                --numberOfCups;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("The customer did not buy your Lemonade.\n");
                                break;
                            }
                        }
                        if (days[currentDay].weather.condition == "Warm and Cloudy")
                        {
                            maxWillingToPay = rand.Next(3, 6);
                            bool okayWithPaying = customer.ChecksPrice(priceOfObject, maxWillingToPay);
                            if (okayWithPaying == true)
                            {
                                Console.WriteLine("The customer perchased Lemonade.\n");
                                customer.BuysLemonade(priceOfObject);
                                player.wallet.AcceptMoney(priceOfObject);
                                --numberOfCups;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("The customer did not buy your Lemonade.\n");
                                break;
                            }
                        }
                        if (days[currentDay].weather.condition == "Cold and Rainy")
                        {
                            maxWillingToPay = rand.Next(0, 2);
                            bool okayWithPaying = customer.ChecksPrice(priceOfObject, maxWillingToPay);
                            if (okayWithPaying == true)
                            {
                                Console.WriteLine("The customer perchased Lemonade.\n");
                                customer.BuysLemonade(priceOfObject);
                                player.wallet.AcceptMoney(priceOfObject);
                                --numberOfCups;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("The customer did not buy your Lemonade.\n");
                                break;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("The customer did not want lemonade\n");
                        break;
                    }
                } while (numberOfCups > 0);
                if (numberOfCups == 0)
                {
                    Console.WriteLine("You have sold out of Lemonade. You pack up your things for the day and leave.\n");
                    break;
                }

            }
        }

        public void CreateNewDay(int numOfDays)
        {
            for (int i = 0; i < numOfDays; i++)
            {
                Day day = new Day();
                days.Add(day);
            }
        }

        public void DisplayProfitOrLoss()
        {
            double profitOrLoss = UserInterface.ProfitOrLossOfDay(player.wallet.Money);
            Console.WriteLine($"Todays profit or loss is {profitOrLoss} dollars.\n");
            totalProfitOrLoss += profitOrLoss;
            Console.WriteLine($"Total profit or loss is {totalProfitOrLoss} dollars.\n");
        }

        public void EndGamesProfitOrLoss()
        {
            Console.WriteLine("The Game is Over!\n");
            double profitOrLoss = UserInterface.ProfitOrLossOfDay(player.wallet.Money);
            totalProfitOrLoss += profitOrLoss;
            Console.WriteLine($"Total profit or loss of the whole game was {totalProfitOrLoss} dollars.\n");
        }

        public int MakingPitchers(int pitchers)
        {
            bool loop = true;
            while (loop)
            {
                int possiblelemons = (player.inventory.lemons.Count / player.recipe.numberOfLemons);
                int possibleIceCubes = (player.inventory.iceCubes.Count / player.recipe.numberOfIceCubes);
                int possibleSugarCubes = (player.inventory.sugarCubes.Count / player.recipe.numberOfSugarCubes);
                int possibleCups = (player.inventory.cups.Count / 8);
                int amountOfPossiblePitchers = Math.Min(Math.Min(possibleSugarCubes,possibleCups),Math.Min(possiblelemons,possibleIceCubes));
                pitchers = amountOfPossiblePitchers;
                int amountOfPitchers = UserInterface.GetNumberOfPitchers();
                if (amountOfPitchers > amountOfPossiblePitchers)
                {
                    Console.WriteLine($"You do not have enough materials (Cups,Lemons,Sugar Cubes, etc..) to make that many pitchers.\nYou have Enough to make a total of {amountOfPossiblePitchers} Pitchers.\n");
                    continue;
                }
                else
                {
                    SubtractRecipeAmountFromInventory(amountOfPitchers);
                    loop = false;
                }
            }
            return pitchers;
        }

        public void SubtractRecipeAmountFromInventory(int pitchersMade)
        {
            while (pitchersMade > 0)
            {
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
                for (int i = 0; i < 8; i++)
                {
                    player.inventory.cups.RemoveAt(0);
                }
                --pitchersMade;
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
                    break;
                }
                if (answer == "N")
                {
                    Console.WriteLine("Okay, Have a nice day.\n");
                    break;
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

        public void CustomersOfTheDay()
        {
            if (days[currentDay].weather.condition == "Hot and Sunny.")
            {
                days[currentDay].CreateCustomers(rand.Next(30,35));
            }
            if (days[currentDay].weather.condition == "Warm and Cloudy")
            {
                days[currentDay].CreateCustomers(rand.Next(15,30));
            }
            if (days[currentDay].weather.condition == "Cold and Rainy")
            {
                days[currentDay].CreateCustomers(rand.Next(5,15));
            }
        }

        public void StartDay()
        {
            CreateNewDay(1);

            Console.WriteLine($"Day: {currentDay + 1}");

            days[currentDay].DaysPossibleWeather();

            player.inventory.DisplayInventory();

            player.DisplayCashAmount();

            StartStore();

            RecipeEditor();

            int pitchers = MakingPitchers(0);

            player.recipe.ChangePricePerCup();

            CustomersOfTheDay();

            CustomersWalkingBy(player.recipe.pricePerCup,pitchers*=8);

            Console.WriteLine("The Day is Finsihed!\n");

            DisplayProfitOrLoss();

            ++currentDay;

        }



        public void RunGame()
        {
            UserInterface.DisplayIntroMessage();
            while (currentDay < 7)
            {
                StartDay();
                if (this.player.wallet.Money == 0)
                {
                    Console.WriteLine("You Have gone Broke!");
                    break;
                }
            }
            EndGamesProfitOrLoss();

            Console.WriteLine("Thank you for Playing!");

        }


    }
}
