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
        //Constructor
        public Game()
        {
            player = new Player("Player");
            days = new List<Day>();
            currentDay = 0;
            
        }
        //Member Methods (CAN DO)

        public void StartDay()
        {
            days[currentDay].DaysPossibleWeather();
            player.inventory.DisplayInventory();
            player.DisplayCashAmount();

        }



        public void RunGame()
        {
            UserInterface.DisplayIntroMessage();
            
            

        }


    }
}
