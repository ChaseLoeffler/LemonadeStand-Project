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
        public string predictedForecast;
        Random rand;
        //Constructor
        public Weather()
        {
            weatherConditions = new List<string> {"Sunny","Cloudy","Rainy"};
            forcast = new List<string> {"Hot and Sunny.","Warm and Cloudy","Cold and Rainy"};
            rand = new Random();
            condition = "";
            temperature = 0;
            predictedForecast = "";
        }
        //Member Methods (CAN DO)

        public void PredictWeather()
        {
            predictedForecast = forcast[rand.Next(3)];
            Console.WriteLine($"The weather looks like its going to be{predictedForecast}");
        }

    }
}
