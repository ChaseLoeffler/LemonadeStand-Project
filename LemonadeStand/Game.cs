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

        public double CustomersWalkingBy(double priceOfObject, int numberOfCups)
        {
            double lemonadeSold = 0;
            foreach (Customer customer in days[currentDay].customers)
            {
                do
                {
                    Console.WriteLine("A customer is walking by.\n");
                    bool wants = customer.WantsLemonade(days[currentDay].weather.condition);
                    if (wants == true)
                    {
                        int maxWillingToPay;
                        if (days[currentDay].weather.condition == "Hot and Sunny")
                        {
                            maxWillingToPay = rand.Next(5, 11);
                            bool okayWithPaying = customer.ChecksPrice(priceOfObject, maxWillingToPay);
                            if (okayWithPaying == true)
                            {
                                Console.WriteLine("The customer purchased Lemonade.\n");
                                customer.BuysLemonade(priceOfObject);
                                player.wallet.AcceptMoney(priceOfObject);
                                --numberOfCups;
                                ++lemonadeSold;
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
                                Console.WriteLine("The customer purchased Lemonade.\n");
                                customer.BuysLemonade(priceOfObject);
                                player.wallet.AcceptMoney(priceOfObject);
                                --numberOfCups;
                                ++lemonadeSold;
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
                                Console.WriteLine("The customer purchased Lemonade.\n");
                                customer.BuysLemonade(priceOfObject);
                                player.wallet.AcceptMoney(priceOfObject);
                                --numberOfCups;
                                ++lemonadeSold;
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
                    Console.WriteLine($"You have sold out of Lemonade. You pack up your things for the day and leave.\n");
                    break;
                }
            }
                return lemonadeSold;
        }

        public void CreateNewDay(int numOfDays)
        {
            for (int i = 0; i < numOfDays; i++)
            {
                Day day = new Day();
                days.Add(day);
            }
        }

        public void DisplayProfitOrLoss(double cupsSold)
        {
            double profitOrLoss = cupsSold *= player.recipe.pricePerCup;
            Console.WriteLine($"Todays profit or loss is ${profitOrLoss}.\n");
            totalProfitOrLoss += profitOrLoss;
            Console.WriteLine($"Total profit or loss is ${totalProfitOrLoss}.\n"); 
        }

        public void EndGamesProfitOrLoss()
        {
            Console.WriteLine("The Game is Over!\n");
            Console.WriteLine($"You finished the game with ${player.wallet.Money} in your wallet.\nTotal profit or loss of the whole game was ${totalProfitOrLoss}.\n");
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
                int amountOfPitchers = UserInterface.GetNumberOfPitchers();
                pitchers = amountOfPitchers;
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
                    Console.WriteLine("Great.\n");
                    store.SellLemons(player);
                    store.SellCups(player);
                    store.SellIceCubes(player);
                    store.SellSugarCubes(player);
                    if (player.recipe.numberOfLemons > player.inventory.lemons.Count || player.recipe.numberOfIceCubes > player.inventory.iceCubes.Count || player.recipe.numberOfSugarCubes > player.inventory.sugarCubes.Count || player.inventory.cups.Count < 8)
                    {
                        Console.WriteLine("You do not have enough materials to make a pitcher of lemonade.\n Please buy any necessary materials form the store.");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Okay, Have a nice day.\n");
                        break;
                    }
                }
                if (answer == "N")
                {
                    if (player.recipe.numberOfLemons > player.inventory.lemons.Count || player.recipe.numberOfIceCubes > player.inventory.iceCubes.Count || player.recipe.numberOfSugarCubes > player.inventory.sugarCubes.Count || player.inventory.cups.Count < 8)
                    {
                        Console.WriteLine("You do not have enough materials to make a pitcher of lemonade.\n Please vist the store.");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Okay, Have a nice day.\n");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invaild rsponse. Please try again.\n");
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
                    Console.WriteLine("You do not have enough ingredients for you to use this recipe. (Consider editing your recipe)\n");
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
            if (days[currentDay].weather.condition == "Hot and Sunny")
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

        public int IfPlayerMakesNoPitchers(int pitchers)
        {
            bool loop = true;
            while (loop)
            {
                if (pitchers == 0)
                {
                    Console.WriteLine("You did not make any pitchers.\n Do you want to make a pitcher (Y yes N no)\n");
                    string response = Console.ReadLine();
                    if (response == "Y")
                    {
                        pitchers = MakingPitchers(0);
                        if(pitchers == 0)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (response == "N")
                    {
                        Console.WriteLine("Okay you will continue the day unable to make Lemonade.\n");
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
                return pitchers;
        }

        public void StartDay()
        {
            CreateNewDay(1);
            totalProfitOrLoss -= player.wallet.Money;
            Console.WriteLine($"Day: {currentDay + 1}\n");

            days[currentDay].DaysPossibleWeather();

            player.inventory.DisplayInventory();

            player.DisplayCashAmount();

            StartStore();

            RecipeEditor();

            int pitchers = MakingPitchers(0);

            pitchers = IfPlayerMakesNoPitchers(pitchers);

            player.recipe.ChangePricePerCup();

            days[currentDay].DaysActualWeather();
            totalProfitOrLoss += player.wallet.Money;
            CustomersOfTheDay();

            double cupsSold = CustomersWalkingBy(player.recipe.pricePerCup,pitchers*=8);

            Console.WriteLine($"The Day is Finsihed!\nYou sold a total of {cupsSold} cups of Lemonade.\n");

            DisplayProfitOrLoss(cupsSold);

            ++currentDay;
        }



        public void RunGame()
        {
            UserInterface.DisplayIntroMessage();
            while (currentDay < 7)
            {
                if (this.player.wallet.Money <= 0)
                {
                    Console.WriteLine("You Have gone Broke!");
                    break;
                }
                StartDay();
            }
            EndGamesProfitOrLoss();

            Console.WriteLine("Thank you for Playing!");

        }


    }
}
