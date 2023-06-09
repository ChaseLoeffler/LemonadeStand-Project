﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Recipe
    {
        // member variables (HAS A)
        public int numberOfLemons;
        public int numberOfSugarCubes;
        public int numberOfIceCubes;
        public double pricePerCup;


        // constructor (SPAWNER)
        public Recipe()
        {
            numberOfLemons = 2;
            numberOfSugarCubes = 4;
            numberOfIceCubes = 10;
            pricePerCup = 1;
        }

        //Member Methods (CAN DO)
        public void DisplayRecipe()
        {
            Console.WriteLine($"Your recipe currently consists of:\n{numberOfLemons} lemons per pitcher\n{numberOfSugarCubes} sugar cubes per pitcher\n{numberOfIceCubes} ice cubes per pitcher (One pitcher makes 8 cups of lemonade.)");
        }

        public void ChangeRecipe()
        {
            Console.WriteLine("Do you want to edit your recipe? (Capital Y for yes Capital N for no.");
            bool loop = true;
            while (loop)
            {
               string answer = Console.ReadLine();
                if (answer == "Y")
                {
                    Console.WriteLine("How many Lemons do you want to use?");
                    string userInput = Console.ReadLine();
                    int userInpuInt = Convert.ToInt32(userInput);
                    numberOfLemons = userInpuInt;

                    Console.WriteLine("How many Sugar cubes do you want to use?");
                    string userInput1 = Console.ReadLine();
                    int userInpuInt1 = Convert.ToInt32(userInput1);
                    numberOfSugarCubes = userInpuInt1;

                    Console.WriteLine("How many Ice cubes do you want to use?");
                    string userInput2 = Console.ReadLine();
                    int userInpuInt2 = Convert.ToInt32(userInput2);
                    numberOfIceCubes = userInpuInt2;
                    
                    loop = false;
                }

                if (answer == "N")
                {
                    loop = false;
                }

                if (answer != "N" && answer != "Y")
                {
                    Console.WriteLine("Invaid response. Please try again.");
                    continue;
                }

            }
            ChecksRecipe();
        }

        public void ChecksRecipe()
        {
            if (numberOfIceCubes <= 0 || numberOfLemons <= 0 || numberOfSugarCubes <= 0)
            {
                Console.WriteLine("You Have to use at least 1 of each ingredient in your Lemonade.\n");
                ChangeRecipe();
            }
        }


        public void ChangePricePerCup()
        {
            Console.WriteLine("How much do you want to charge per cup of Lemonade?");
            string userInput = Console.ReadLine();
            double userInputdouble = Convert.ToDouble(userInput);
            pricePerCup = userInputdouble;
        }

    }
}
