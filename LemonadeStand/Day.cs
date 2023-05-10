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
        public Random rand;
        //Constructor
        public Day()
        {
            weather = new Weather();
            customers = new List<Customer>();
            rand = new Random();
        }
        //Member Methods (CAN DO)
        public void DaysPossibleWeather()
        {
            Console.WriteLine();
            weather.PredictWeather();
        }

        public void DaysActualWeather()
        {
            Console.WriteLine();
            weather.ActualWeather();
        }

        public void CreateCustomers(int numOfCustomers)
        {
            for (int i = 0; i < numOfCustomers; i++)
            {
                Customer customer = new Customer();
                customers.Add(customer);
            }
        }
    }
}
