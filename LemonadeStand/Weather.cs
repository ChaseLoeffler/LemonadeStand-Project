using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Weather
    {   // Member Variables (HAS A)
        public string condition;
        public int temperature;
        private List<string> weatherConditions;
        private List<string> forcast;
        public Random rand;
        //Constructor
        public Weather()
        {
            weatherConditions = new List<string> {"Sunny","Cloudy","Rainy"};
            forcast = new List<string> {"Hot and Sunny","Warm and Cloudy","Cold and Rainy","Hot and Sunny","Warm and Cloudy"};
            rand = new Random();
            condition = "";
            temperature = 0;
            
        }
        //Member Methods (CAN DO)

        public void PredictWeather()
        {
            condition = forcast[rand.Next(5)];
            Console.WriteLine($"The weather today looks like its going to be {condition}\n");
        }

        public void ActualWeather()
        {
            if(condition == "Hot and Sunny")
            {
                temperature = rand.Next(85, 95);
                Console.WriteLine($"The weather was {weatherConditions[0]} and the temperature was {temperature} degrees fahrenheit.\n");
            }
            else if (condition == "Warm and Cloudy")
            {
                temperature = rand.Next(60,85);
                Console.WriteLine($"The weather was {weatherConditions[1]} and the temperature was {temperature} degrees fahrenheit.\n");
            }
            else if (condition == "Cold and Rainy")
            {
                temperature = rand.Next(40,55);
                Console.WriteLine($"The weather was {weatherConditions[2]} and the temperature was {temperature} degrees fahrenheit.\n");
            }
        }

    }
}
