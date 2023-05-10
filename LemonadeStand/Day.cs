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

        public void CustomersWalkingBy(double priceOfObject,int numberOfCups)
        {
            foreach (Customer customer in customers)
            {
                do
                {
                    Console.WriteLine("A customer is walking by.");
                    bool wants = customer.WantsLemonade(weather.condition);
                    if (wants == true)
                    {
                        int maxWillingToPay = 0;
                        if (weather.condition == "Hot and Sunny")
                        {
                            maxWillingToPay = rand.Next(5, 11);
                            bool okayWithPaying = customer.ChecksPrice(priceOfObject, maxWillingToPay);
                            if (okayWithPaying == true)
                            {
                                Console.WriteLine("A customer perchased Lemonade.\n");
                                customer.BuysLemonade(priceOfObject);
                                --numberOfCups;
                                break;
                            }
                        }
                        if (weather.condition == "Warm and Cloudy")
                        {
                            maxWillingToPay = rand.Next(3, 6);
                            bool okayWithPaying = customer.ChecksPrice(priceOfObject, maxWillingToPay);
                            if (okayWithPaying == true)
                            {
                                Console.WriteLine("A customer perchased Lemonade.\n");
                                customer.BuysLemonade(priceOfObject);
                                --numberOfCups;
                                break;
                            }
                        }
                        if (weather.condition == "Cold and Rainy")
                        {
                            maxWillingToPay = rand.Next(0,2);
                            bool okayWithPaying = customer.ChecksPrice(priceOfObject, maxWillingToPay);
                            if (okayWithPaying == true)
                            {
                                Console.WriteLine("A customer perchased Lemonade.\n");
                                customer.BuysLemonade(priceOfObject);
                                --numberOfCups;
                                break;
                            }
                        }

                    }
                } while (numberOfCups > 0);
                if (numberOfCups == 0)
                {
                    Console.WriteLine("You have sold out of Lemonade. You pack up your things for the day and leave.");
                    break;
                }

            }
        }
    }
}
