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
        Random rand;
        //Constructor
        public Weather()
        {
            weatherConditions = new List<string> {"Sunny","Cloudy","Rainy"};
            forcast = new List<string> {"Hot and Sunny.","Warm and Cloudy","Cold and Rainy"};
            rand = new Random();
            condition = "";
            temperature = 0;
            
        }
        //Member Methods (CAN DO)

        public void PredictWeather()
        {
            condition = forcast[rand.Next(3)];
            Console.WriteLine($"The weather looks like its going to be{condition}");
        }

        public void ActualWeather()
        {
            if(condition == "Hot and Sunny")
            {
                temperature = 90;
                Console.WriteLine($"The weather was {temperature} degrees and {weatherConditions[0]}");
            }
            else if (condition == "Warm and Cloudy")
            {
                temperature = 65;
                Console.WriteLine($"The weather was {temperature} degrees and {weatherConditions[1]}");
            }
            else if (condition == "Cold and Rainy")
            {
                temperature = 40;
                Console.WriteLine($"The weather was {temperature} degrees and {weatherConditions[2]}");
            }
        }

    }
}
