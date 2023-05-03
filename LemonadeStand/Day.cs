using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Day
    {   // Member Variables (HAS A)
        public Weather weather;
        public List<Customer> customers;
        //Constructor
        public Day()
        {
            weather = new Weather();
            customers = new List<Customer>();
        }
        //Member Methods (CAN DO)
        public void DaysPossibleWeather()
        {
            weather.PredictWeather();
        }

        public void DaysActualWeather()
        {
            weather.ActualWeather();
        }
    }
}
